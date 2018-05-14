using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : ButtonFunc
{
    void Update()
    {
        if (!turnON)
        {
            return;
        }
        SceneManager.LoadScene("Tutorial");
    }
}