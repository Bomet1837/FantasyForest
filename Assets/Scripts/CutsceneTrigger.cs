using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject cutsceneObject;
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            cutsceneObject.SetActive(true);
            Invoke("quitGame", 4f);
        }
    }
    
    public void NextStage()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("lvl_1");
    }
    private void quitGame()
    {
        Application.Quit();
       // if (Application.isEditor)
       // {
       //     UnityEditor.EditorApplication.isPlaying = false;
       // }
    }
    
    
}
