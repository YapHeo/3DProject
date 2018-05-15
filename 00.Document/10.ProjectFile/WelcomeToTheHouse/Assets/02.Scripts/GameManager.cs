using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    string sceneName;

    GameObject Lantern;
    GameObject Talk;

    GameObject inven;

    GameObject player;

    [SerializeField]
    GameObject Inventory;

    //[SerializeField]
    //GameObject Player;

    Text dialog;

    bool onlyOne = false;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        Lantern = GameObject.Find("Light");
        Talk = GameObject.Find("Text");
        player = GameObject.Find("Player");

        dialog = Talk.GetComponent<Text>();

        if (sceneName == "Tutorial")
        {
            Lantern.SetActive(false);

            inven = Instantiate(Inventory) as GameObject;
            inven.transform.position = new Vector3(1, 2, -1.2f);

            player.GetComponent<Player>().SettempId(2);

            Debug.Log("Tutorial");
        }

        if (sceneName == "Stage")
        {
            inven = Instantiate(Inventory) as GameObject;

            Lantern.SetActive(true);

            player.GetComponent<Player>().SettempId(-1);

            //인벤 좌표좀 설정해줘
            // inven.transform.position = 

            Debug.Log("Stage");
        }
    }

    //1 인벤토리열고 랜턴 켜기
    //2 피를 바라보면 이동하기
    //3 문을 바라봐서 본게임 시작

    void Update()
    {   
        if (sceneName == "Tutorial" && !onlyOne)
        {
            inven.GetComponent<Inventory>().AddItem(2);
            onlyOne = true;
        }
    }

    public void NoInvenClose()
    {
        dialog.text = "너무 어두워서 랜턴을 사용해야 할 것 같아..";
    }
    public void FlashlightOn()
    {
        Lantern.SetActive(true);

        dialog.text = "근처에 핏자국이 보인다 따라가보자..";

        Destroy(GameObject.Find("TutorialCol"));
    }
}
