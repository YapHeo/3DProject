using UnityEngine;
using System.Collections;

public class ButtonAction : ButtonFunc
{
    public string ButtonValue;              
    public LockCodeCtrl CodeController;                                            
    private AudioSource btnSound;

    bool sw = false;
    bool btn = false;

    float interval = 1.0f;
    float time = 0;

    void Start()
    {
        btnSound = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        sw = GetTurnOn();
        if (sw)
        {

            time += Time.deltaTime;

            if (time > interval)
            {
                time = 0;
                OnBtnDown();
                return;
            }
        }

        sw = false;

    }

    void OnBtnDown()
    {
        if (btn)
        {
            CodeController.addKeyInput(ButtonValue);
            btnSound.Play();
        }
    }

}
