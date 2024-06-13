using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    // Update is called once per frame
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
}
