using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleBtn : ButtonFunc
{
    bool sw = false;
    
    void Update()
    {
        sw = GetTurnOn();
        if (sw == true)
        {
            sw = false;
            SceneManager.LoadScene("Title");
        }
    }
}
