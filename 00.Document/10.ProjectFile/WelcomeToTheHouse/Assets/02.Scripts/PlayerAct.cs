using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAct : MonoBehaviour
{
    public GameObject paper;
    GameObject paperTemp;

    public GameObject passwordTable;
    GameObject passwordTableTemp;

    public GameObject magicSquare;
    GameObject magicSquareTemp;

    public GameObject clockQuiz;
    GameObject clockQuizTemp;

    bool[] isAction;

    GameObject player;

    void Start()
    {
        isAction = new bool[10];

        for (int i = 0; i < isAction.Length; ++i)
            isAction[i] = false;

        player = GameObject.Find("Player");
    }

    void Update()
    {
        StandOnPaper();
        PhotoFrameOnPasswordTable();
        StandOnMagicSquare();
        SmallSafeOnClockQuiz();
        GetFlashlight();
    }

    public void PlayerAction(int _id)
    {
        Debug.Log("PlayerActionId : " + _id);

        isAction[_id] = true;
    }

    void StandOnPaper()
    {
        if (isAction[1] == true)
        {
            Debug.Log("StandOnPaper");

            paperTemp = Instantiate(paper) as GameObject;

            paperTemp.transform.position = new Vector3(-0.783f, 1.151f, -2.515f);
            paperTemp.transform.localScale = new Vector3(0.003576209f * 2, 0.007152418f, 0.002384139f * 2);
            paperTemp.transform.rotation = Quaternion.Euler(0f, -90.0f, 0f);

            GameObject stand = GameObject.Find("NightstandDetail01");
            stand.tag = "Untagged";
            stand.layer = 0;

            isAction[1] = false;
        }
    }

    void PhotoFrameOnPasswordTable()
    {
        if (isAction[2] == true)
        {
            Debug.Log("PhotoFrameOnPasswordTable");

            passwordTableTemp = Instantiate(passwordTable) as GameObject;

            passwordTableTemp.transform.position = new Vector3(-0.915f, 2.631f, -2.806f);
            passwordTableTemp.transform.localScale = new Vector3(10.0f, 6.0f, 1.5f);
            passwordTableTemp.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            passwordTableTemp.tag = "Untagged";
            passwordTableTemp.layer = 0;

            GameObject photoFrame = GameObject.Find("Paint_01");
            photoFrame.tag = "Untagged";
            photoFrame.layer = 0;

            isAction[2] = false;
        }
    }

    void StandOnMagicSquare()
    {
        if (isAction[3] == true)
        {
            Debug.Log("StandOnMagicSquare");

            magicSquareTemp = Instantiate(magicSquare) as GameObject;

            magicSquareTemp.transform.position = new Vector3(2.088736f, 1.433698f, -2.562197f);
            magicSquareTemp.transform.localScale = new Vector3(0.03929003f, 0.03929402f, 0.0445646f);
            magicSquareTemp.transform.rotation = Quaternion.Euler(-0.8200001f, 0f, 0f);

            magicSquareTemp.tag = "Untagged";
            magicSquareTemp.layer = 0;

            GameObject stand = GameObject.Find("Cabinet");
            stand.tag = "Untagged";
            stand.layer = 0;

            isAction[3] = false;
        }
    }

    void SmallSafeOnClockQuiz()
    {
        if (isAction[4] == true)
        {
            Debug.Log("SmallSafeOnClockQuiz");

            clockQuizTemp = Instantiate(clockQuiz) as GameObject;

            clockQuizTemp.transform.position = new Vector3(1.003f, 1.105f, -1.055f);
            clockQuizTemp.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
            clockQuizTemp.transform.rotation = Quaternion.Euler(0f, 3.346f, 0f);

            clockQuizTemp.tag = "Untagged";
            clockQuizTemp.layer = 0;

            GameObject smallSafe = GameObject.Find("Box03");
            smallSafe.tag = "Untagged";
            smallSafe.layer = 0;

            isAction[4] = false;
        }
    }

    void GetFlashlight()
    {
        if (isAction[5] == true)
        {
            Debug.Log("GetFlashlight");

            player.GetComponent<Player>().FlashlightOn();

            isAction[5] = false;
        }
    }
}