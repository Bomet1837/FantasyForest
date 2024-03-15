using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    private PlayerControls _isPlayable;
    
    [SerializeField]
    private GameObject _pauseMenu;
    private void Start()
    {
        _isPlayable = FindObjectOfType<PlayerControls>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPlayable == true)
            {
                _pauseMenu.SetActive(false);
            }
            else
            {
                _pauseMenu.SetActive(true);
            }
        }
    }
}
