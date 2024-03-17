using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TextControl : MonoBehaviour
{

    // Start is called before the first frame update
    private void Update()
    {
        switch (UImanager.order)
        {

            case 1:
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 2:
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 3:
                gameObject.transform.GetChild(3).gameObject.SetActive(true);
                gameObject.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 4:
                gameObject.transform.GetChild(4).gameObject.SetActive(true);
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 5:
                gameObject.transform.GetChild(5).gameObject.SetActive(true);
                gameObject.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 6:
                gameObject.transform.GetChild(6).gameObject.SetActive(true);
                gameObject.transform.GetChild(5).gameObject.SetActive(false);
                break;
            case 7:
                SceneManager.LoadScene(1);
                break;
            default:
                
                break;
                



        }
    }
}
