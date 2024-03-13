using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMap : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
