﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject audioOnIcon;
    public GameObject audioOffIcon;
     
	// Use this for initialization
	void Start () {
        SetSoudState();

       
    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

	}

    public void SkipIntro(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("runner");
    }

    //MUTE SOUND BUTTON

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }

        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }

        SetSoudState();
        

    }

    private void SetSoudState()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            audioOnIcon.SetActive(true);
            audioOffIcon.SetActive(false);
        }
        else
        {
            AudioListener.volume = 0;
            audioOnIcon.SetActive(false);
            audioOffIcon.SetActive(true);
        }
    }
}
