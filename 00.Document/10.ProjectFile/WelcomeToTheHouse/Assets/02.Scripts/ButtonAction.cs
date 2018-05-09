using UnityEngine;
using System.Collections;

public class ButtonAction : MonoBehaviour
{
    public string ButtonValue;              
    public LockCodeCtrl CodeController;                                            
    private AudioSource btnSound;

    void Start()
    {
        btnSound = gameObject.GetComponent<AudioSource>();
    }



    void OnMouseDown()
    {
        CodeController.addKeyInput(ButtonValue);
        btnSound.Play();
    }
}
