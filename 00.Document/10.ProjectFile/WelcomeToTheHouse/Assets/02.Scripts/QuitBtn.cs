using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitBtn : ButtonFunc
{
    bool sw= false;

    void Update()
    {
        sw = GetTurnOn();
        if (sw == true)
        {
            sw = false;
            Application.Quit();
        }
    }
}
