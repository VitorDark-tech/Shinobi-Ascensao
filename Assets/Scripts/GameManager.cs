using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int vidas = 3;
    public int moedas = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o GameManager entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PerderVida();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            ColetarMoeda();
        }
    }

    public void PerderVida()
    {
        vidas--;
        HUDController.instance.AtualizarVidas(vidas);

        moedas = 0; // Zerar moedas sempre que perder uma vida
        HUDController.instance.AtualizarMoedas(moedas);

        if (vidas <= 0)
        {
            vidas = 3;    // Resetar vidas
            moedas = 0;   // Resetar moedas
            HUDController.instance.AtualizarVidas(vidas);
            HUDController.instance.AtualizarMoedas(moedas);
        }

        SceneManager.LoadScene("Level1"); // Sempre volta para Level1
    }

    public void ColetarMoeda()
    {
        moedas++;
        HUDController.instance.AtualizarMoedas(moedas);
    }
}