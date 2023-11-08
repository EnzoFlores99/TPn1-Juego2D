using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
   //metodo para reproducir una escena con el nombre de la misma
   public void PlayLevel(string levelName)
   {
      //carga la escena de acuerdo a su nombre
      SceneManager.LoadScene(levelName);
   }
    
    void Update()
    {
        
    }
}
