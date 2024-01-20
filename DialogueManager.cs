using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class DialogueManager : MonoBehaviour
{
    public string[] lines;
    public float textSpeed;
    public TextMeshProUGUI dialogueText;
    private int index;
    private bool isDialogueTriggered = false;
    private bool hasDialogueEnded = false;
    public GameObject dialogueUI; // Reference to the UI canvas
    public GameObject talklook; 
    public GameObject continueButton;// Reference to the Yes and No buttons within the canvas

    private void Start()
    {
        dialogueText.text = string.Empty;
        dialogueUI.SetActive(false); // Hide the UI canvas initially
        talklook.SetActive(false);
        continueButton.SetActive(false);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDialogueTriggered)
        {
             ResetDialogue();
            dialogueUI.SetActive(true); // Show the prompt canvas
           talklook.SetActive(true);
            hasDialogueEnded = true; 
        }
    }
     private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isDialogueTriggered)
        { ResetDialogue();
            dialogueUI.SetActive(false); // Show the prompt canvas
           talklook.SetActive(false);
            hasDialogueEnded = true; }}
    private void ResetDialogue()
    {
        isDialogueTriggered = false;
        index = 0;
        dialogueText.text = string.Empty;
        dialogueUI.SetActive(false);
        talklook.SetActive(false);
        continueButton.SetActive(false);
        hasDialogueEnded = false;}

    public void StartDialogue()
    {   
        isDialogueTriggered = true;
         hasDialogueEnded = false;
        index = 0;
        StartCoroutine(TypeLine());
    }
     public void OnContinueButtonClicked()
    {
        if (dialogueText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }

    public void CancelDialogue()
    {   
        isDialogueTriggered = false;
        dialogueText.text = string.Empty;
        dialogueUI.SetActive(false); // Hide the UI canvas
        talklook.SetActive(false);
        continueButton.SetActive(true); // Hide the Yes and No buttons
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        continueButton.SetActive(true);
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueUI.SetActive(false);
            isDialogueTriggered = false;
             talklook.SetActive(false);
        continueButton.SetActive(false);
         hasDialogueEnded = true;
        }
    }
}
