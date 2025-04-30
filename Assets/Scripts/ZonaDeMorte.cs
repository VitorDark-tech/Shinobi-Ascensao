using UnityEngine;

public class ZonaDeMorte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            GameManager.instance.PerderVida();
        }
    }
}