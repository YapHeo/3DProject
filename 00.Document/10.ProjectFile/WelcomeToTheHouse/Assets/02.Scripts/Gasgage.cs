using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gasgage : MonoBehaviour
{
    [SerializeField]
    GameObject gasBar;
    [SerializeField]
    GameObject gasgageBar;

    Image progressbarImg;

    float redValue;
    float greenValue;

    float timeloss = 0.0033f;

    float interval = 1f;
    float ttime = 0;

    string sceneName = "";

    bool soundSW = true;

    void Start()
    {
        progressbarImg = gasgageBar.GetComponent<Image>();
    }


    void Update()
    {
        sceneName = Application.loadedLevelName;

        if (sceneName == "Stage1")
        {
            gasBar.SetActive(true);
            gasgageBar.SetActive(true);

            progressbarImg.fillAmount += Time.deltaTime * timeloss;
        }

        //#1 색을 부드럽게 변경 + 심장소리 재생
        if (progressbarImg.fillAmount >= 0.8f)
        {
            redValue = Mathf.PingPong(Time.time * 150, 150);
            greenValue = 150 - Mathf.PingPong(Time.time * 150, 150);

            progressbarImg.color = new Color(redValue / 255, greenValue / 255, 3 / 255);

            if (soundSW)
            {
                GetComponent<AudioSource>().Play();
                soundSW = false;
            }

        }


        if (progressbarImg.fillAmount == 1)
        {
            SceneManager.LoadScene("Over");
        }
    }
}
