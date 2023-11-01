using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager referencia;

    public AudioSource somDaColeta;
    public AudioSource somDoDano;
    public AudioSource somDoPulo;


    void Awake() {
        referencia = this;
    }

}
