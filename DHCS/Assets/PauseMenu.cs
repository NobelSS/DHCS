using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject soundMenu;
    private bool isPause = false;

    public Slider musicSlider, fxSlider;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPause)
        {
            Pause();
            isPause = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPause && !soundMenu.activeSelf && !pauseMenu.activeSelf)
        {
            Resume();
            isPause = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && soundMenu.activeSelf)
        {
            soundMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }

    
    public void Pressed()
    {
        Debug.Log("Pressed!");
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Audio()
    {
        pauseMenu.SetActive(false);
        soundMenu.SetActive(true);
    }

    

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);   
    }

    public void FXVolume()
    {
        AudioManager.Instance.FXVolume(fxSlider.value);
    }
}
