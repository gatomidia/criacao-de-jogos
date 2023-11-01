using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimentoDpJogador : MonoBehaviour
{

    private Rigidbody2D rigidbory2D;
    private Animator objAnimator;

    [Header("Movimentação")]
    public float velocidadeDoJogador;
    
    [Header("Pulo")]
    public bool jogadorEstaTocandoNoChao;
    public float alturaDoPulo;
    public float tamanhoDoVerificadorDeChao;
    public Transform verificadorDeChao;
    public LayerMask camadaDoChao;

    public float vidasDoJogador;
    public bool jogadorEstaVivo;

    void Awake() {
        rigidbory2D = GetComponent<Rigidbody2D>();
        objAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start() {
        vidasDoJogador = 4;
        jogadorEstaVivo = true;
    }

    // Update is called once per frame
    void Update() {
        if(vidasDoJogador > 0 ) {
            MovimentarJogador();
            PuloDoJogador();
        } else {
            // Reinciar jogo
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void PuloDoJogador() {

        jogadorEstaTocandoNoChao = Physics2D.OverlapCircle(verificadorDeChao.position, tamanhoDoVerificadorDeChao, camadaDoChao);


        if(Input.GetButtonDown("Jump")) {
            if(jogadorEstaTocandoNoChao == true) {
                SFXManager.referencia.somDoPulo.Play();
                rigidbory2D.AddForce(new Vector2(0f, alturaDoPulo), ForceMode2D.Impulse);
            }
        }

        if(jogadorEstaTocandoNoChao == false) {
            objAnimator.Play("jogador-pulando");
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

        if(movimentoHorizontal == 0) {
            // Rodar animação de parado
            if(jogadorEstaTocandoNoChao == true) {
                objAnimator.Play("jogador-parado");
            }
        } else if(movimentoHorizontal != 0) {
            // Podemos fazer multiplas validações usando o "&&"
            // if(movimentoHorizontal != 0 && jogadorEstaTocandoNoChao == true) {

            if(jogadorEstaTocandoNoChao == true) {
                // Rodar a animação de andando
                objAnimator.Play("jogador-andando");
            }
        }
    }
}
