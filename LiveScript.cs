using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveScript : MonoBehaviour
{
   
    private int npcCan = 3; // NPC'nin toplam caný
    NPCAI npcAI;
    [SerializeField]
    AudioClip audioClip;
    [SerializeField]
    AudioSource audioSource;

    private void Start()
    {
        npcAI = Object.FindObjectOfType<NPCAI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("spine"))
        {
            //audioSource.PlayOneShot(audioClip);
            npcCan--; // NPC'nin canýný azalt
            Debug.Log("NPC'nin caný: " + npcCan);

            if (npcCan <= 0)
            {
                // NPC öldü
                Debug.Log("NPC öldü!");
                npcAI.saldiriyiKes = false;
                npcAI.Death();
                Invoke("CanYenile", 3f);
                Destroy(gameObject);
            }
        }
    }

    void CanYenile()
    {
        npcCan = 3;
        npcAI.saldiriyiKes = true;
    }
}
