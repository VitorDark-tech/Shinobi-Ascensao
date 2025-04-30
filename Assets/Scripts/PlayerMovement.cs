using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    public AudioClip somDePulo; // <- Som de pulo
    private AudioSource audioSource; // <- Componente de áudio

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Virar o personagem para a direção do movimento
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Direita
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Esquerda
        }

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            audioSource.PlayOneShot(somDePulo); // Toca o som de pulo
        }

        // Animações
        bool estaCorrendo = Mathf.Abs(moveInput) > 0.1f;
        anim.SetBool("Correndo", estaCorrendo);

        bool estaPulando = !isGrounded;
        anim.SetBool("Pulando", estaPulando);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}