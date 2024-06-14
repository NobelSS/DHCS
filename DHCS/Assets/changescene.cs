using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class changescene : MonoBehaviour
{

   public GameObject Trigger;

   void Update()
   {
    
   if(Trigger.activeSelf)
   {
     AudioManager.Instance.PlayMusic("music");
     SceneManager.LoadScene("Tutorial");
   }

   }



    


    
 
}
