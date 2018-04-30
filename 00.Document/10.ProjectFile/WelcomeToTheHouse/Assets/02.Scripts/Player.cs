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
    int tempId = -1;


    Ray ray;

    //ray사거리
    [SerializeField]
    float rayLong;
    //게이지 차는 속도
    float gageTime = 0.75f;

    //이동목적지설정 초기값
    Vector3 targetPos = Vector3.up;
    //이동속도
    float movespeed = 0.2f;

    void Start()
    {
        Cameracenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

        if(SceneManager.GetActiveScene().name == "Stage1" || SceneManager.GetActiveScene().name == "TempJH")
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

        //이동에 대한 정보------
        float step = movespeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

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
                    targetPos = new Vector3(hitcoll.transform.position.x, transform.position.y, hitcoll.transform.position.z);                   
                }

                //item 일때
                if (hitcoll.collider.CompareTag("Item"))
                {
                    // 인벤 위치 수정 필요 플레이어와 아이템 거리를 사용한 코드로 변경이 필요
                    //inven.transform.position = new Vector3(hitcoll.collider.gameObject.transform.position.x, hitcoll.collider.gameObject.transform.position.y, hitcoll.collider.gameObject.transform.position.z);
                }

                // 상호작용이 필요한 아이템
                if (hitcoll.collider.CompareTag("InteractionItem"))
                {
                    tempId = hitcoll.collider.GetComponent<Item>().GetSpriteId();
                    Debug.Log("상호상호!!");
                    // 인벤 위치 수정 필요 플레이어와 아이템 거리를 사용한 코드로 변경이 필요
                    inven.transform.position = new Vector3(hitcoll.collider.gameObject.transform.position.x, hitcoll.collider.gameObject.transform.position.y, hitcoll.collider.gameObject.transform.position.z);
                }
                // 인벤에 들어가는거
                if (hitcoll.collider.CompareTag("InvenItem"))
                {
                    inven.GetComponent<Inventory>().AddItem(hitcoll.collider.GetComponent<Item>().GetSpriteId());
                    Destroy(hitcoll.collider.gameObject);
                }

                // 슬롯과 상호작용
                if (hitcoll.collider.CompareTag("Slot"))
                {
                    if(tempId == hitcoll.collider.GetComponent<Slot>().GetID())
                    {
                        Destroy(hitcoll.collider.gameObject);
                    }
                }

                // 인벤 닫기
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
