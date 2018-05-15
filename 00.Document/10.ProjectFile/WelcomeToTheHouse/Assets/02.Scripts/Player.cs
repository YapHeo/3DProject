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
    GameObject act;

    Vector3 Cameracenter;
    float gageAmount;
    int tempId = -1;


    Ray ray;    

    //ray사거리
    [SerializeField]
    float rayLong = 60;
    //게이지 차는 속도
    float gageTime = 0.75f;

    //이동목적지설정 초기값
    Vector3 targetPos = new Vector3(-1.0f, 2.0f, -1.0f);
    
    //이동속도
    float movespeed = 0.4f;

    bool movingState = false;

    string sceneName;

    void Start()
    {
        Cameracenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        //0514 실험 끝나고 삭제
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            inven = Instantiate(inventory) as GameObject;
            inven.transform.position = new Vector3(-1, 2, -1);

            act = GameObject.Find("PlayerAct");
        }
        else if (SceneManager.GetActiveScene().name == "Stage")
        {
            inven = Instantiate(inventory) as GameObject;
            inven.transform.position = new Vector3(Cameracenter.x, Cameracenter.y, -1);

            act = GameObject.Find("PlayerAct");
        }

        sceneName = Application.loadedLevelName;

    }

    void Update()
    {

        if (sceneName == "Stage" || sceneName == "Tutorial")
        {
            rayLong = 2;
        }
 

        Cursorgage.fillAmount = gageAmount;

        ray = Camera.main.ScreenPointToRay(Cameracenter);

        //그외에 나머지 coll
        RaycastHit hitcoll;
        //이동용 rayhit
        RaycastHit movecoll;

        //이동에 대한 정보------
        float step = movespeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (transform.position == targetPos)
        {
            movingState = false;
        }
        if (Physics.Raycast(ray, out movecoll, 100, 1 << 8))
        {
            if (movecoll.collider.CompareTag("Nothing"))
            {
                gageAmount = 0;
                Cursor.gameObject.SetActive(false);
                idleLook.gameObject.SetActive(true);
            }
            if (movecoll.collider.CompareTag("WayPoint"))
            {
                targetPos = new Vector3(movecoll.transform.position.x, transform.position.y, movecoll.transform.position.z);
                movingState = true;
            }
        }

        //layermark를 사용------------ 
        if (Physics.Raycast(ray, out hitcoll, rayLong, 1 << 8))
        {   
            if (hitcoll.collider.CompareTag("Nothing") || movecoll.collider.CompareTag("WayPoint") || movingState)
            {
                gageAmount = 0;
                Cursor.gameObject.SetActive(false);
                idleLook.gameObject.SetActive(true);
                
            }
            else
            {
                gageAmount += gageTime * Time.deltaTime;
                Cursor.gameObject.SetActive(true);
                idleLook.gameObject.SetActive(false);

            }

            if (gageAmount >= 1)
            {
                //바라본대상이 단순 버튼식 오브젝트일 때
                if (hitcoll.collider.CompareTag("Button"))
                {
                    hitcoll.collider.GetComponent<ButtonFunc>().SetTurnOn(true);
                }
                // 상호작용이 필요한 아이템
                if (hitcoll.collider.CompareTag("InteractionItem"))
                {
                    // 이거 개천재(tempId)
                    tempId = hitcoll.collider.GetComponent<Item>().GetInteractionId();

                    Debug.Log("InteractionID : " + hitcoll.collider.GetComponent<Item>().GetInteractionId());

                    // 인벤 위치 수정 필요 플레이어와 아이템 거리를 사용한 코드로 변경이 필요
                    inven.transform.position = new Vector3((transform.position.x + hitcoll.collider.gameObject.transform.position.x) / 2.0f,
                        (transform.position.y + hitcoll.collider.gameObject.transform.position.y) / 2.0f, (transform.position.z + hitcoll.collider.gameObject.transform.position.z) / 2.0f);
                }
                // 인벤에 들어가는거
                if (hitcoll.collider.CompareTag("InvenItem"))
                {
                    inven.GetComponent<Inventory>().AddItem(hitcoll.collider.GetComponent<Item>().GetSpriteId());

                    Debug.Log("SpriteID : " + hitcoll.collider.GetComponent<Item>().GetSpriteId());

                    Destroy(hitcoll.collider.gameObject);
                }
                // 슬롯과 상호작용
                if (hitcoll.collider.CompareTag("Slot"))
                {             
                    // 이거 개천재(tempId)
                    if (tempId == hitcoll.collider.GetComponent<Slot>().GetID())
                    {
                        Debug.Log("InteractionID == SpriteID : " + tempId + " == " + hitcoll.collider.GetComponent<Slot>().GetID());

                        hitcoll.collider.GetComponentInChildren<SpriteRenderer>().sprite = null;
                        hitcoll.collider.GetComponent<Slot>().SetID(-1);

                        inven.transform.position = new Vector3(Cameracenter.x, Cameracenter.y, -1);

                        act.GetComponent<PlayerAct>().PlayerAction(tempId);
                    }
                }
                // 인벤 닫기
                if (hitcoll.collider.CompareTag("InvenClose"))
                {
                    inven.transform.position = new Vector3(Cameracenter.x, Cameracenter.y, -1);
                }
                if (gageAmount > 1)
                {
                    gageAmount = 0;
                }
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
