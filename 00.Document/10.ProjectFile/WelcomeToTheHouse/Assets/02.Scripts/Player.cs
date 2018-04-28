using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    Image Cursorgage;

    [SerializeField]
    Image idleLook;

    [SerializeField]
    Image Cursor;

    // 인벤 정보
    public GameObject inventory;
    GameObject inven;

    Vector3 Cameracenter;
    float gageAmount;


    Ray ray;

    //ray사거리
    float rayLong = 60.0f;
    //게이지 차는 속도
    float gageTime = 0.75f;

    //이동속도
    float movespeed = 5.0f;

    void Start()
    {
        Cameracenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

        if(SceneManager.GetActiveScene().name == "Stage1")
        {
            inven = Instantiate(inventory) as GameObject;
            inven.transform.position = new Vector3(Cameracenter.x, Cameracenter.y, -1);
        }
    }


    void Update()
    {
        Cursorgage.fillAmount = gageAmount;


        ray = Camera.main.ScreenPointToRay(Cameracenter);

        RaycastHit hitcoll;

        //layermark를 사용------------ 
        if (Physics.Raycast(ray, out hitcoll, rayLong, 1 << 8))
        {
            gageAmount += gageTime * Time.deltaTime;
            Cursor.gameObject.SetActive(true);
            idleLook.gameObject.SetActive(false);

            if (gageAmount >= 1)
            {
                //바라본대상이 버튼일 때
                if (hitcoll.collider.CompareTag("Button"))
                {
                    hitcoll.collider.GetComponent<ButtonFunc>().SetTurnOn(true);

                }
                //바라본 대상이 웨이 포인트일때
                if (hitcoll.collider.CompareTag("WayPoint"))
                {
                    float step = movespeed * Time.deltaTime;


                    transform.position = Vector3.MoveTowards(transform.position, hitcoll.transform.localPosition, step);

                }
                //item 일때
                if (hitcoll.collider.CompareTag("Item"))
                {
                    // AddItem(hitcoll.collider.gameObject.getid() 형태로 변경
                    inven.GetComponent<Inventory>().AddItem(0);

                    // 인벤 위치 수정 필요 플레이어와 아이템 거리를 사용한 코드로 변경이 필요
                    inven.transform.position = new Vector3(hitcoll.collider.gameObject.transform.position.x, hitcoll.collider.gameObject.transform.position.y, hitcoll.collider.gameObject.transform.position.z);
                    //if (hitcoll.collider.transform.position.z < 0)
                    //{

                    //}
                    //else if (hitcoll.collider.transform.position.z > 0)
                    //{

                    //}
                    //else
                    //{

                    //}
                    //inven.transform.position = new Vector3(transform.position.x,transform.position.y,);
                    Destroy(hitcoll.collider.gameObject);
                }
                if (hitcoll.collider.CompareTag("InvenClose"))
                {
                    inven.transform.position = new Vector3(Cameracenter.x, Cameracenter.y, -1);
                }
                //
                //if (hitcoll.collider.CompareTag("FakeItem"))
                //{

                //}
            }

        }
        else
        {
            gageAmount = 0;
            Cursor.gameObject.SetActive(false);
            idleLook.gameObject.SetActive(true);
        }
    }
}
