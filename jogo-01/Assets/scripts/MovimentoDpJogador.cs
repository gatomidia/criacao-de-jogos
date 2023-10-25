using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDpJogador : MonoBehaviour
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
        if(movimentoHorizontal == 0 && estaNoChao == true) {
            objAnimator.Play("jogador-parado");
        } else if(movimentoHorizontal != 0 && estaNoChao == true) {
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

        if(estaNoChao == false) {
            objAnimator.Play("jogador-pulando");
        }
    }

}





