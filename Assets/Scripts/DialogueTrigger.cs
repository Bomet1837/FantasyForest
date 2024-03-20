using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScrpit;
    private bool playerDetected;
//detect trigger with player 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScrpit.ToggleIndicator(playerDetected);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScrpit.ToggleWindow(playerDetected);
            dialogueScrpit.ToggleIndicator(playerDetected);
        }
    }
//if detected show indicator 
//if not die indictator
//while detected if we interact with dialogues
    void Update()
    {
        if(playerDetected && Input.GetKeyDown(KeyCode.Y))
        { 
            dialogueScrpit.ToggleWindow(playerDetected);
            dialogueScrpit.StartDialogue();
        }
    }
}