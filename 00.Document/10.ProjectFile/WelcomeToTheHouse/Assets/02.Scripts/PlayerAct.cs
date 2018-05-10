using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAct : MonoBehaviour
{
    public GameObject paper;
    GameObject paperTemp;

    public GameObject passwordTable;
    GameObject passwordTableTemp;

    bool[] isAction;

    void Start()
    {
        isAction = new bool[10];

        for (int i = 0; i < isAction.Length; ++i)
            isAction[i] = false;
    }

    void Update()
    {
        StandOnPaper();
        PhotoFrameOnPasswordTable();
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

            GameObject photoFrame = GameObject.Find("Paint_01");
            photoFrame.tag = "Untagged";
            photoFrame.layer = 0;

            isAction[2] = false;
        }
    }
}