using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject ekmenupanel;
    bool panelactive;


    private void Update()
    {
        if (panelactive && Input.GetKeyDown(KeyCode.Escape))
        {
            EkMenuKapat();
        }
    }
    public void Oyna()
    {
        SceneManager.LoadScene(2);
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
    public void EkMenu()
    {
      ekmenupanel.SetActive(true);
      panelactive = true;
      panel.SetActive(false);
    }

    public void EkMenuKapat()
    {
        panelactive = false;
        ekmenupanel.SetActive(false);
        panel.SetActive(true);
    }
    public void LoadSearching()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadWalkingToCastle()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadBigBoss()
    {
        SceneManager.LoadScene(5);
    }
}
