using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PauseUI;
    public bool paused;
    
    void Start()
    {
        PauseUI.SetActive(false);
        paused = false;
    }

    void Update ()
    {
        if (Input.GetButtonDown("Start") && paused == false)
            Pausar();        
        else if (Input.GetButtonDown("Start") && paused == true)
            Resume();
    }

    public void Resume()
    {
        if (paused == true)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }

    public void Pausar()
    {
        Time.timeScale = 0;
        PauseUI.SetActive(true);
        paused = true;
    }

    /*public void Restart(string nome)
    {
        SceneManager.LoadScene("" + nome);
        paused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }*/

    /*public void MainMenu()
    {
        SceneManager.LoadScene("Principal");
        paused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
    }*/
}
