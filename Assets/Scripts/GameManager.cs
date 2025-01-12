using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject jugador;

    public GameObject enemigo;

    public float vidaJugador = 1000;

    public float vidaEnemigo = 500;

   
    [SerializeField] private TMP_Text textoVida;


    private void Start()
    {
        textoVida.SetText("Vida: " + vidaJugador.ToString());
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    public void RecibirDanho(float danhoRecibido)
    {
        vidaJugador -= danhoRecibido;
        textoVida.SetText("Vida: " + vidaJugador.ToString());
        if (vidaJugador <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
    }

   

}


