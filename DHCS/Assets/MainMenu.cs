using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    // Update is called once per frame
    public Slider musicSlider, fxSlider;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && settingsMenu.activeSelf) 
        {
            settingsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void LoadGame() 
    {
        SceneManager.LoadScene("OP");
    }

    public void Audio() 
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void ExitGame() 
    {
        Application.Quit();
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
