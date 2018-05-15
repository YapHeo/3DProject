using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamestart : ButtonFunc
{
    void Update()
    {
        if (!turnON)
        {
            return;
        }
        SceneManager.LoadScene("Stage");
    }

}
