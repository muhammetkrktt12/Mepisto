using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellController : MonoBehaviour
{
    public GameObject spellPrefab; // Büyü prefabý
    public Transform spellSpawnPoint; // Büyü spawn noktasý
    public float spellCooldown = 2f; // Büyü aralýðý

    private bool canCastSpell = true; // Büyü yapýlabilir durumu

    void Update()
    {
        // Fare sað tuþuna basýldýðýnda ve büyü yapýlabilir durumdaysa büyüyü çaðýr
        if (Input.GetMouseButtonDown(1) && canCastSpell)
        {
            CastSpell();
            canCastSpell = false;
            Invoke("ResetSpellCooldown", spellCooldown); // Büyü aralýðýný ayarla
        }
    }

    void CastSpell()
    {
        // Büyü prefabýný oluþtur ve spawn noktasýnda çaðýr
        if (spellPrefab != null && spellSpawnPoint != null)
        {
            Instantiate(spellPrefab, spellSpawnPoint.position, spellSpawnPoint.rotation);
        }
        else
        {
            Debug.LogError("Spell prefab veya spawn noktasý atanmamýþ!");
        }
    }

    void ResetSpellCooldown()
    {
        canCastSpell = true;
    }
}
