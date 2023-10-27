using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoComDano : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        if(outroObjeto.gameObject.CompareTag("Player")) {
            // Dizer que o jogador morreu ou perdeu vida
            outroObjeto.gameObject.GetComponent<VidaDoJogador>().MachucarJogador();
        }
    }
}
