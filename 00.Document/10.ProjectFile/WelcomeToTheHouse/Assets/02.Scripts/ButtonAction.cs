using UnityEngine;
using System.Collections;

public class ButtonAction : ButtonFunc
{
    public string ButtonValue;
    public LockCodeCtrl CodeController;
    private AudioSource btnSound;

    void Start()
    {
        btnSound = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!turnON)
        {
           return;
        }
        OnBtnDown();
    }   

    void OnBtnDown()
    {
        CodeController.addKeyInput(ButtonValue);
        btnSound.Play();
        turnON = false;
    }
}