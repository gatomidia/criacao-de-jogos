using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public string proximaFase;

    void OnEnable() {
        SceneManager.LoadScene(proximaFase);
    }
}
