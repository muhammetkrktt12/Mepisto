using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject informationpage;
    public static int order;
    bool ordercanincrease;
    private void Start()
    {
        StartCoroutine(InformationActivate());
        ordercanincrease = false;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ordercanincrease) 
        { 
            order += 1;
            Debug.Log(order);
        }

    }
    IEnumerator InformationActivate()
    {
        yield return new WaitForSeconds(4);
        informationpage.SetActive(true);
        ordercanincrease = true;
    }
}

