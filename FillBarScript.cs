using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarScript : MonoBehaviour
{
    public Image barFill;
   [SerializeField] private float maxCan = 100;
    public float currentCan;
    float damage = 10;
    public GameObject panel;
    private void Start()
    {
        currentCan = maxCan;
    }

    public void GuncelCan()
    {

        currentCan -= damage;
        currentCan = Mathf.Clamp(currentCan, 0, maxCan);
        if(currentCan <=0)
        {
            //panel.SetActive(true);
            Time.timeScale = 0f;
        }
        UpdateCanBar();
    }

    private void UpdateCanBar()
    {

        float kalan = currentCan / maxCan;
        barFill.fillAmount = kalan;
    }
}
