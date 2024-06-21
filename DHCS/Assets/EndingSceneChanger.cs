using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingSceneChanger : MonoBehaviour
{
  public void LoadGame() 
    {
        SceneManager.LoadScene("OP");
    }

   public void ExitGame() 
    {
        Application.Quit();
    }


}
