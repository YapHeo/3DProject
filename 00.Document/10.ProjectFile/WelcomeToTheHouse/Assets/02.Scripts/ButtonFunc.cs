using UnityEngine;

public class ButtonFunc : MonoBehaviour
{
    bool turnON = false;

    void Start()
    {
        
    }
   
    void Update()
    {

    }

    public bool GetTurnOn()
    {
        return turnON;
    }

    public void SetTurnOn(bool ans)
    {
        turnON = ans;
    }


}
