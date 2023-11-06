using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
   public GameObject restart;
   public GameObject playmenu;
    
   public void PlayLevel(string levelName)
   {
      SceneManager.LoadScene(levelName);
   }

    
    void Update()
    {
        
    }
}
