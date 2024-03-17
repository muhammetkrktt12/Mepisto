using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Animator animator;
    public float animationDuration = 3f; // �lk animasyonun s�resi
    public int collectedItemCount = 0;

    private bool teleportActivated = false; // Teleport aktivasyonu

    private void OnTriggerEnter(Collider other)
    {
        // �arp��an nesnenin etiketini kontrol eder
        if (other.CompareTag("collect"))
        {
            // Collect'i yok et
            Destroy(other.gameObject);

            // ItemCount'u artt�r
            collectedItemCount++;

            // E�er toplam 5 item topland�ysa ve teleport hen�z aktif de�ilse
            if (collectedItemCount >= 5 && !teleportActivated)
            {
                // Teleportu aktif et
                teleportActivated = true;

                // Teleport animasyonunu ba�lat
                animator.SetBool("Teleport", true);

                // �lk animasyonun tamamlanmas�n� bekleyin
                Invoke("LoadNextScene", animationDuration);
            }
        }
    }

    // Yeni sahneye ge�en metod
    private void LoadNextScene()
    {
        // Aktif sahnenin index numaras�n� al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Bir sonraki sahnenin index numaras�n� hesapla
        int nextSceneIndex = currentSceneIndex + 1;

        // Bir sonraki sahneye ge�
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Teleport animasyonunu sonland�ran metod
    private void EndTeleportAnimation()
    {
        animator.SetBool("Teleport", false);
    }
}