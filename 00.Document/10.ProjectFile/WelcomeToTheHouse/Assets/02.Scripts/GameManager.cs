using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //private void Awake()
    //{    
    //    DontDestroyOnLoad(transform.gameObject);
    //}

    string sceneName;
    GameObject Lantern;
    GameObject Talk;
    GameObject Inventory;

    void Start()
    {
        sceneName = Application.loadedLevelName;
    }

    //1 인벤토리열고 랜턴 켜기
    //2 피를 바라보면 이동하기
    //3 문을 바라봐서 본게임 시작

    void Update()
    {
        if (sceneName == "Tutorial")
        {

        }
        
    }




}
