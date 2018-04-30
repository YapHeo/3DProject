using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gasgage : MonoBehaviour
{
    [SerializeField]
    Image gage;

    [SerializeField]
    Image progressbar;


    float timeloss = 0.0033f;

    void Update()
    {
        progressbar.fillAmount += Time.deltaTime * timeloss;

        if (progressbar.fillAmount == 1 )
        {
            SceneManager.LoadScene("Over");
        }
    }
}
