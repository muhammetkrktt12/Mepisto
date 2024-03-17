using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator animator;
    public float animationDuration = 3f; // Ýlk animasyonun süresi
    public int collectedItemCount = 0;

    private bool teleportActivated = false; // Teleport aktivasyonu

    private void OnTriggerEnter(Collider other)
    {
        // Çarpýþan nesnenin etiketini kontrol eder
        if (other.CompareTag("collect"))
        {
            // Collect'i yok et
            Destroy(other.gameObject);

            // ItemCount'u arttýr
            collectedItemCount++;

            // Eðer toplam 5 item toplandýysa ve teleport henüz aktif deðilse
            if (collectedItemCount >= 5 && !teleportActivated)
            {
                // Teleportu aktif et
                teleportActivated = true;

                // Teleport animasyonunu baþlat
                animator.SetBool("Teleport", true);

                // Ýlk animasyonun tamamlanmasýný bekleyin
                Invoke("LoadNextScene", animationDuration);
            }
        }
    }

    // Yeni sahneye geçen metod
    private void LoadNextScene()
    {
        // Aktif sahnenin index numarasýný al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Bir sonraki sahnenin index numarasýný hesapla
        int nextSceneIndex = currentSceneIndex + 1;

        // Bir sonraki sahneye geç
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Teleport animasyonunu sonlandýran metod
    private void EndTeleportAnimation()
    {
        animator.SetBool("Teleport", false);
    }
}