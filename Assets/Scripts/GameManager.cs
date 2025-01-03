using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject jugador;

    public GameObject enemigo;

    public float vidaJugador = 1000;

    public float vidaEnemigo = 500;

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
        if (vidaJugador <= 0)
        {
            {
                Destroy(jugador);
            }
        }
    }

   

}


