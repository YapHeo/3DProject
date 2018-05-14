using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool sceneSW = false; 
    int stageNum = 0;

    //private void Awake()
    //{    
    //    DontDestroyOnLoad(transform.gameObject);
    //}

    void Start()
    {

    }

    void Update()
    {

    }

    public int GetStageNum()
    {
        return stageNum;
    }
    public void SetStageNum(int a)
    {
        stageNum = a;
    }

    public bool GetSceneSW()
    {
        return sceneSW;
    }
    public void SetSceneSW(bool ans)
    {
        sceneSW = ans;
    }

}
