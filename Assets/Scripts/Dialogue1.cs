using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
//fields
//window
    public GameObject window;
//indicator
    public GameObject indicator;
//Text Component 
    public TMP_Text dialogueText;
//Dialoge List 
    public List<string> dialogues;
//writing speed
    public float writingSpeed;
//index on dialogue
    private int index;
//character index
    private int charIndex;
//started boolean
    private bool started;
//wait for next boolean 
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }
    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }


//start dialogue
    public void StartDialogue()
    {
        if(started)
            return; 
//boolean to indictate we have started 
        started = true;
//show the window
        ToggleWindow(true);
//hide the indicator
        ToggleIndicator(false);
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
//start index at zero
        index = i;
//reset the character index
        charIndex = 0;
//clear the dialogue component text 
        dialogueText.text = string.Empty;
//start writing
        StartCoroutine(Writing());
    }

//end dialogue 
    public void EndDialogue()
    {
//hide the window
        ToggleWindow(false);

    }

//writing logic 
    IEnumerator Writing()
    {
        string currentDialogue = dialogues[index];
//Write the letters
        dialogueText.text += currentDialogue[charIndex];
//increase that character index 
        charIndex++;
//make sure you have reached the end of the sentence
        if(charIndex < currentDialogue.Length)
        {
//wait x seconds 
            yield return new WaitForSeconds(writingSpeed);
//restart the same process
            StartCoroutine(Writing());
        }
        else{
//end this sentence and wait for next one 
            waitForNext = true;
        }
    }
    private void Update()
    {
        if(!started)
            return;

        if(waitForNext && Input.GetKeyDown(KeyCode.T))
        {
            waitForNext = false;
            index++;
            if(index < dialogues.Count)
            {
                GetDialogue(index);
            }
            else
            {
                EndDialogue();
            }
        }
    }
}