using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour
{
    //referencia al boton de pausa
    [SerializeField] private GameObject buttonPause;
    //referencia al menu de pausa
    [SerializeField] private GameObject menuPause;
    //definimos un estado booleano, lo instanciamos como falso
    private bool gamePaused = false;

     //metodo para acceder a las escenas
    public void PlayLevel(string levelName)
   {
        //se carga la escena de acuerdo al nombre
      SceneManager.LoadScene(levelName);
   }
    private void Update()
    {//si se presiona la tecla escape
        if(Input.GetKeyDown(KeyCode.Escape))
        {    //si el juego esta pausado, true
            if(gamePaused)
            { //reanuda el juego llamando a la funcion
                Resume();
            }
            else
            {//pero si no esta pausado, pausa el juego llamando a la funcion
                Pause();
            }
        }
    }
    //metodo para pausar el juego
    public void Pause()
        {
            // se detiene el juego, se desactiva el boton de pausa y se muestra el menu de pausa
            gamePaused = true;
            Time.timeScale = 0f;
            buttonPause.SetActive(false);
            menuPause.SetActive(true);
        }

  //metodo para reanudar el juego
    public void Resume()
    {
        //se reanuda el juego, el tiempo vuelve a 1 y se muestra el boton de pausa pero no el menu de pausa
        gamePaused = false;
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }

//metodo para reiniciar el nivel
    public void restart()
    {
        //cuando se selecciona reiniciar, reinicia la escena
        gamePaused= false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //metodo para salir del juego
    public void Quit()
    {
        //mostramos por pantalla que se ejecuta
        Debug.Log("Se esta cerrando el juego");
        Application.Quit();
    }
}
