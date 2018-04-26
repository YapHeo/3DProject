using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : ButtonFunc
{
    bool sw = false;

    void Update()
    {
        sw = GetTurnOn();
        if (sw == true)
        {
            sw = false;
            SceneManager.LoadScene("Stage1");
        }
           
    }
}
