using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image Cursorgage;


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
    }


    void Update()
    {
        Cursorgage.fillAmount = gageAmount;


        ray = Camera.main.ScreenPointToRay(Cameracenter);

        RaycastHit hitcoll;

        //layermark를 사용------------ 
        if (Physics.Raycast(ray,out hitcoll, rayLong, 1<<8))
        {
            gageAmount += gageTime * Time.deltaTime;


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
                //if (hitcoll.collider.CompareTag("Item"))
                //{

                //}
                //
                //if (hitcoll.collider.CompareTag("FakeItem"))
                //{

                //}
            }

        }
        else
        {
            gageAmount = 0;
        }

    }
}
