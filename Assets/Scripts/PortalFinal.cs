using UnityEngine;
using UnityEngine.SceneManagement; 

public class PortalFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Parabéns! Você terminou o jogo!");

            // Fecha o jogo se for Build
            Application.Quit();

            // Se estiver testando no Editor da Unity, não fecha, só mostra mensagem
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}