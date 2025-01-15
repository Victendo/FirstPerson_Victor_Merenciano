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

    public float numeroMuertes = 0;
    [SerializeField] private TMP_Text textoMuertes;


    private void Start()
    {

        textoVida.SetText("Vida: " + vidaJugador.ToString());
        textoMuertes.SetText("Muertes: " + numeroMuertes.ToString());
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

    public void AumentarVida()
    {
        vidaJugador = vidaJugador + 100;
        textoVida.SetText("Vida: " + vidaJugador.ToString());
    }

    public void AumentarMuertes()
    {
        numeroMuertes++;
        textoMuertes.SetText("Muertes: " + numeroMuertes.ToString());
    }

    



}


