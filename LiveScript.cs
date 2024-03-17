using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveScript : MonoBehaviour
{
   
    private int npcCan = 3; // NPC'nin toplam can�
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
            npcCan--; // NPC'nin can�n� azalt
            Debug.Log("NPC'nin can�: " + npcCan);

            if (npcCan <= 0)
            {
                // NPC �ld�
                Debug.Log("NPC �ld�!");
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
