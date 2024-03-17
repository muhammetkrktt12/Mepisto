using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterConttoller : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public float runSpeed = 10f; // Koþma hýzý
    public float rotationSpeed = 100f; // Dönme hýzý
    public float jumpForce = 20f;
    public float jumpForwardForce = 10f;

    private bool canCastSpell = true; // Spell yapýlabilir durumu

    private Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbody bileþeni alýnýyor
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Koþma tuþuna basýlýysa ve yürüme tuþlarýna basýlmýþsa
        if (Input.GetKey(KeyCode.LeftShift) && (verticalInput != 0))
        {
            // Koþma animasyonunu baþlat
            animator.SetBool("IsRunning", true);
            moveSpeed = runSpeed; // Koþma hýzýný ayarla
        }
        else
        {
            // Koþma animasyonunu durdur
            animator.SetBool("IsRunning", false);
            moveSpeed = 5f; // Yürüme hýzýný ayarla
        }

        // Yürüme animasyonunu baþlat
        animator.SetBool("IsWalking", verticalInput != 0);

        // Karakterin saða veya sola dönmesi için
        if (horizontalInput != 0)
        {
            // Dönme hareketini hesapla
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

            // Dönme hareketini uygula
            transform.Rotate(Vector3.up, rotationAmount);
        }

        // Sol fare týklamasýný kontrol ediyoruz
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }

        // Sað fare týklamasýný kontrol ediyoruz ve spell yapýlabilir durumdaysa büyü yap
        if (Input.GetMouseButtonDown(1) && canCastSpell)
        {
            animator.SetTrigger("Spell");
            canCastSpell = false; // Büyü yapýldýktan sonra bir sonraki büyüye izin verme
            Invoke("ResetSpellCooldown", 2f); // 2 saniye sonra büyü aralýðýný sýfýrla
        }

        //-------------------zýplama---------------------

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Zýplama animasyonunu baþlat
            animator.SetTrigger("Jump");

        }


    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.up * Time.deltaTime * jumpForce;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(5);
        }
    }


    void ResetSpellCooldown()
    {
        canCastSpell = true;
    }


}
