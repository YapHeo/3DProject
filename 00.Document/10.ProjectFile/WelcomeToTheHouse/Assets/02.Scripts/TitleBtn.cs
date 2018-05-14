using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleBtn : ButtonFunc
{    
    void Update()
    {
        if (!turnON)
        {
            return;
        }
        SceneManager.LoadScene("Title");
    }
}
