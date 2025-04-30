using UnityEngine;

public class Espinho : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.PerderVida(); // Tira 1 vida
        }
    }
}