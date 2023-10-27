using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletarDepoisDeTempo : MonoBehaviour
{
    
    public float tempoParaEsteObjetoSerDeletado;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, tempoParaEsteObjetoSerDeletado);
    }
}
