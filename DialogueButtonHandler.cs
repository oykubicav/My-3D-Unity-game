using UnityEngine;

public class DialogueButtonHandler : MonoBehaviour
{
    public DialogueManager dialogueManager;
     public GameObject talklook;
     

private void Start()
    {
        talklook.gameObject.SetActive(false);
        
    }
    public void StartDialogue()
    {
        dialogueManager.StartDialogue();
         talklook.gameObject.SetActive(false);// Hide the buttons after starting dialogue
    }

    public void CancelDialogue()
    {
        dialogueManager.CancelDialogue();
          talklook.gameObject.SetActive(false);// Hide the buttons after canceling dialogue
    }
}

