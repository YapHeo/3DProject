using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Logo : MonoBehaviour
{

    public Image Gage;

    void Start()
    {

    }


    void Update()
    {

        Gage.fillAmount += Time.deltaTime * 0.166f;


        if (Gage.fillAmount == 1)
        {
            SceneManager.LoadScene("Title");
        }

    }
}
