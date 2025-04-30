using UnityEngine;

public class PlataformaHorizontal : MonoBehaviour
{
    public float velocidade = 2f;
    public float distancia = 3f;
    private Vector3 posicaoInicial;
    private Vector3 ultimaPosicao;

    void Start()
    {
        posicaoInicial = transform.position;
        ultimaPosicao = posicaoInicial;
    }

    void Update()
    {
        float movimento = Mathf.Sin(Time.time * velocidade) * distancia;
        Vector3 novaPosicao = new Vector3(posicaoInicial.x + movimento, posicaoInicial.y, posicaoInicial.z);

        // Mover jogador manualmente se estiver em cima
        Vector3 delta = novaPosicao - transform.position;
        MoverJogador(delta);

        transform.position = novaPosicao;
        ultimaPosicao = transform.position;
    }

    void MoverJogador(Vector3 delta)
    {
        foreach (Collider2D col in Physics2D.OverlapBoxAll(transform.position, GetComponent<Collider2D>().bounds.size, 0))
        {
            if (col.CompareTag("Player"))
            {
                col.transform.position += delta;
            }
        }
    }

    // Nenhuma necessidade de SetParent
    private void OnCollisionEnter2D(Collision2D collision) { }
    private void OnCollisionExit2D(Collision2D collision) { }
}