using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellController : MonoBehaviour
{
    public GameObject spellPrefab; // B�y� prefab�
    public Transform spellSpawnPoint; // B�y� spawn noktas�
    public float spellCooldown = 2f; // B�y� aral���

    private bool canCastSpell = true; // B�y� yap�labilir durumu

    void Update()
    {
        // Fare sa� tu�una bas�ld���nda ve b�y� yap�labilir durumdaysa b�y�y� �a��r
        if (Input.GetMouseButtonDown(1) && canCastSpell)
        {
            CastSpell();
            canCastSpell = false;
            Invoke("ResetSpellCooldown", spellCooldown); // B�y� aral���n� ayarla
        }
    }

    void CastSpell()
    {
        // B�y� prefab�n� olu�tur ve spawn noktas�nda �a��r
        if (spellPrefab != null && spellSpawnPoint != null)
        {
            Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Spell prefab veya spawn noktas� atanmam��!");
        }
    }

    void ResetSpellCooldown()
    {
        canCastSpell = true;
    }
}
