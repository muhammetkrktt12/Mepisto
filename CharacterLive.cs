using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLive : MonoBehaviour
{

    private float maxCan = 100;
    private float currentCan;
    NPCAI npcAI;
    float damage = 10;
    FillBarScript barScript;
    private void Start()
    {
        npcAI = Object.FindObjectOfType<NPCAI>();
        currentCan = maxCan;
        barScript = Object.FindObjectOfType<FillBarScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            barScript.GuncelCan();

            if(barScript.currentCan<= 0)
            {
                npcAI.saldiriyiKes = true;
                npcAI.EtrafindaGez();
                Debug.Log("Karakter Öldü");

            }
        }
    }
}
