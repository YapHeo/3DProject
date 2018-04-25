using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonFunc : MonoBehaviour
{
    GameObject Gm;
    GameManager gm;

    void Start()
    {
        Gm = GameObject.Find("GameManager");
        gm = Gm.GetComponent<GameManager>();
    }
   
    void Update()
    {

    }

    public void TitleBtnOn()
    {
        SceneManager.LoadScene("Stage1");
    }



}
