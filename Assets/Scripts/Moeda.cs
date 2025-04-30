using UnityEngine;

public class Moeda : MonoBehaviour
{
    public AudioClip somDeColeta; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se quem tocou foi o jogador
        {
            GameManager.instance.ColetarMoeda(); // Atualiza as moedas no HUD

            AudioSource.PlayClipAtPoint(somDeColeta, transform.position); // <- Toca o som de coleta

            Destroy(gameObject); // Destroi a moeda coletada
        }
    }
}