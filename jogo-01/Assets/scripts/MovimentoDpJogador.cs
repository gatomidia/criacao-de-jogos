using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDpJogador : MonoBehaviour
{

    private Rigidbody2D rigidbory2D;

    public float velocidadeDoJogador;
    
    void Awake() {
        rigidbory2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        MovimentarJogador();
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
    }
}
