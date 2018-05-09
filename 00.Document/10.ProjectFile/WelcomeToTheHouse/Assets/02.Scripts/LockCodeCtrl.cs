using UnityEngine;
using UnityEngine.UI;

public class LockCodeCtrl : MonoBehaviour
{
    [SerializeField]
    Text DisplayText;

    [SerializeField]
    GameObject GameObj;

    Animator animator;

    [SerializeField]
    string lockCode = "1234";

    public AudioSource AudioConfirm;
    public AudioSource AudioDenied;
    public bool noAudio = true;
    
    string DisplayDefault = "LOCKED";
    string DisplayOPEN = "OPEN";
    string inputCode;
    string codeSubmit = "RETURN";
    string codeClear = "CLEAR";


    void Start()
    {
        inputCode = "";
        writingText(DisplayDefault);
        animator = GameObj.GetComponent<Animator>();
    }

    public void writingText(string newText)
    {
        DisplayText.text = newText;
    }

    public void addKeyInput(string key)
    {

        if (key.Equals(codeSubmit))
        {
            submit();
            return;
        }

        if (key.Equals(codeClear))
        {
            clearInput();
            writingText(DisplayDefault);
            return;
        }
        inputCode += key;
        writingText(inputCode);
    }

    public void submit()
    {
        if (inputCode.Equals(lockCode))
        {
            writingText(DisplayOPEN);
            AudioConfirm.Play();
            animator.SetBool("Anim_Bool", true);
        }
        else
        {
            writingText(DisplayDefault);
            AudioDenied.Play();
        }
        
        clearInput();
    }

    public void clearInput()
    {
        inputCode = "";
    }


    private bool CheckCode()
    {
        if (lockCode.Equals(inputCode))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
