using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogadorComTiro : MonoBehaviour
{
    private Rigidbody2D rigidbory2D;
    // Aula 02
    private Animator objAnimator;

    [Header("Movimento")]
    public float velocidadeDoJogador;
    
    [Header("Pulo")]

    // Aula 02
    public bool estaNoChao;
    public float alturaDoPulo;
    public float tamanhoDoVerificadorDeChao;
    public Transform verificadorDeChao;
    public LayerMask camadaDoChao;

    // Variável para controlar o estado de tiro
    private bool estouAtirando = false;
        // Tempo de espera entre tiros
    public float tempoTirador = 0.3f; // Altere para o tempo desejado
    private float tempoUltimoTiro = 0.0f;

    public Transform arcoEFecha;
    public GameObject objFlecha;
    public float forcaDaFlechada;

    
    void Awake() {
        rigidbory2D = GetComponent<Rigidbody2D>();
        objAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        MovimentarJogador();
        PuloDoJogador(); // Aula 02
        TiroJogador();
    }

    private void TiroJogador() {
    //    if (Input.GetButtonDown("Fire1") && !estouAtirando && Time.time - tempoUltimoTiro >= tempoTirador)
    //     {
    //         Debug.Log("Foi");
    //         estouAtirando = true;
    //         objAnimator.Play("jogador-atirando");

    //         // Atualiza o tempo do último tiro
    //         tempoUltimoTiro = Time.time;
    //     }

        // if (Input.GetButtonDown("Fire1") && !estouAtirando) {
        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("Foi");
            objAnimator.Play("jogador-atirando");
            GameObject temp = Instantiate(objFlecha);
            temp.transform.position = arcoEFecha.position;
            
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDaFlechada, 0);

            Destroy(temp.gameObject, 3f);

            // Define um temporizador para o próximo tiro
            tempoUltimoTiro = Time.time;
            estouAtirando = true;

        }
        // if (!objAnimator.GetCurrentAnimatorStateInfo(0).IsName("jogador-atirando")){
        //         Debug.Log("Acabou");
        //         // estouAtirando = false;
        // }

        // Verifica se já passaram 2 segundos desde o último tiro
        if (estouAtirando && Time.time - tempoUltimoTiro >= tempoTirador)
        {
            estouAtirando = false;
        }
       
    }

    private void MovimentarJogador() {
        /*
         1. Float: 1.3 4.5
         2. Boolean: true ou false
         3. Number: Numero inteiro: 1,2,3,5
         4. String: Texto
        */
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float eixoX = movimentoHorizontal * velocidadeDoJogador;

        float eixoY = rigidbory2D.velocity.y;

        rigidbory2D.velocity = new Vector2(eixoX, eixoY);

        if(movimentoHorizontal > 0) {
            // Jogador para a direito
            transform.localScale = new Vector3(1f, 1f, 1f);

        } else if(movimentoHorizontal < 0){
            // jogador para esquerda
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        // Aula 02
        // Parao
        if(movimentoHorizontal == 0 && estaNoChao == true && estouAtirando == false) {
            objAnimator.Play("jogador-parado");
        } else if(movimentoHorizontal != 0 && estaNoChao == true && estouAtirando == false) {
            objAnimator.Play("jogador-andando");
        }
    }

    // Aula 02  
    private void PuloDoJogador() {

        // A posição, tamanho e camada de verificação
        estaNoChao = Physics2D.OverlapCircle(verificadorDeChao.position, tamanhoDoVerificadorDeChao, camadaDoChao);

        if(Input.GetButtonDown("Jump") && estaNoChao == true) {
            // posição e modo de força
            rigidbory2D.AddForce(new Vector2(0f, alturaDoPulo), ForceMode2D.Impulse);
        }

        // if(estaNoChao == false) {
        //     objAnimator.Play("jogador-pulando");
        // }
    }

}
