using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    public float velocidade = 2f;
    public float altura = 3f;
    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        float movimento = Mathf.Sin(Time.time * velocidade) * altura;
        transform.position = new Vector3(posicaoInicial.x, posicaoInicial.y + movimento, posicaoInicial.z);
    }

    // REMOVER o SetParent para evitar deformação
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // não faz nada
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // não faz nada
    }
}