using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAct : MonoBehaviour
{
    public GameObject paper;
    GameObject paperTemp;

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
    }

    public void PlayerAction(int _id)
    {
        // 행동 관리 한번, 지속 관리
        Debug.Log("PlayerActionId : " + _id);

        isAction[_id] = true;
       
    }

    void StandOnPaper()
    {
        if(isAction[1] == true)
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
}
