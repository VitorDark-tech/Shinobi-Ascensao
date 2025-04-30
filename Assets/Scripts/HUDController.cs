using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;

    public TextMeshProUGUI textoVidas;
    public TextMeshProUGUI textoMoedas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // faz o HUD persistir entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AtualizarVidas(int vidas)
    {
        textoVidas.text = "Vidas: " + vidas;
    }

    public void AtualizarMoedas(int moedas)
    {
        textoMoedas.text = "Moedas: " + moedas;
    }
}