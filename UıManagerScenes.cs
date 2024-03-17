using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UıManagerScenes : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    public GameObject panel;
    public AudioListener listener;
    bool panelactive = false;

    
    private void Update()
    {
        if (!panelactive && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            panelactive = true;
        }
        if (panelactive && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            panelactive = false;
        }
    }
    public void Geri()
    {
        panelactive = false;
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Muted()
    {
        listener.GetComponent<AudioListener>().enabled = false;
    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
