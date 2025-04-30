using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float velocidadeRotacao = -30f; // Velocidade de rotação em graus por segundo

    void Update()
    {
        transform.Rotate(0, 0, velocidadeRotacao * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // NÃO faz SetParent aqui!
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Também NÃO faz nada aqui!
    }
}