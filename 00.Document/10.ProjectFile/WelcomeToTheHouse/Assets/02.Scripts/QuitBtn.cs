using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitBtn : ButtonFunc
{
    void Update()
    {
        if (!turnON)
        {
            return;
        }
        Application.Quit();
    }
}
