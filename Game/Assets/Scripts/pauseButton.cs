using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour
{
    [SerializeField] private GameObject buttonPause;
    [SerializeField] private GameObject menuPause;
    private bool gamePaused = false;

    public void PlayLevel(string levelName)
   {
      SceneManager.LoadScene(levelName);
   }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
        {
            gamePaused = true;
            Time.timeScale = 0f;
            buttonPause.SetActive(false);
            menuPause.SetActive(true);
        }
    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        buttonPause.SetActive(true);
        menuPause.SetActive(false);
    }

    public void restart()
    {
        gamePaused= false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Debug.Log("Se esta cerrando el juego");
        Application.Quit();
    }
}
