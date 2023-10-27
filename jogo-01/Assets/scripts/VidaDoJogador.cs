using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaDoJogador : MonoBehaviour
{
    private Rigidbody2D rigidbory2D;

    private GameObject projetio;

    void Awake()
    {
        rigidbory2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MachucarJogador() {
        FindObjectOfType<MovimentoDpJogador>().vidasDoJogador = FindObjectOfType<MovimentoDpJogador>().vidasDoJogador - 1;


        // FindObjectOfType<MovimentoDpJogador>().jogadorEstaVivo = false;

        rigidbory2D.velocity = new Vector2(0f, 0f);
    }

    public void AdicionarVida() {
        FindObjectOfType<MovimentoDpJogador>().vidasDoJogador = FindObjectOfType<MovimentoDpJogador>().vidasDoJogador + 1;
    }

}
