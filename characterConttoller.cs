using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterConttoller : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    public float runSpeed = 10f; // Ko�ma h�z�
    public float rotationSpeed = 100f; // D�nme h�z�
    public float jumpForce = 20f;
    public float jumpForwardForce = 10f;

    private bool canCastSpell = true; // Spell yap�labilir durumu

    private Animator animator;
    private Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>(); // Rigidbody bile�eni al�n�yor
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Ko�ma tu�una bas�l�ysa ve y�r�me tu�lar�na bas�lm��sa
        if (Input.GetKey(KeyCode.LeftShift) && (verticalInput != 0))
        {
            // Ko�ma animasyonunu ba�lat
            animator.SetBool("IsRunning", true);
            moveSpeed = runSpeed; // Ko�ma h�z�n� ayarla
        }
        else
        {
            // Ko�ma animasyonunu durdur
            animator.SetBool("IsRunning", false);
            moveSpeed = 5f; // Y�r�me h�z�n� ayarla
        }

        // Y�r�me animasyonunu ba�lat
        animator.SetBool("IsWalking", verticalInput != 0);

        // Karakterin sa�a veya sola d�nmesi i�in
        if (horizontalInput != 0)
        {
            // D�nme hareketini hesapla
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

            // D�nme hareketini uygula
            transform.Rotate(Vector3.up, rotationAmount);
        }

        // Sol fare t�klamas�n� kontrol ediyoruz
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }

        // Sa� fare t�klamas�n� kontrol ediyoruz ve spell yap�labilir durumdaysa b�y� yap
        if (Input.GetMouseButtonDown(1) && canCastSpell)
        {
            animator.SetTrigger("Spell");
            canCastSpell = false; // B�y� yap�ld�ktan sonra bir sonraki b�y�ye izin verme
            Invoke("ResetSpellCooldown", 2f); // 2 saniye sonra b�y� aral���n� s�f�rla
        }

        //-------------------z�plama---------------------

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Z�plama animasyonunu ba�lat
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
