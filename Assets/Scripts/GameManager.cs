using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject jugador;

    public float vidaJugador = 100;

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
        Debug.Log("Danho realizado");
        vidaJugador -= danhoRecibido;
        if (vidaJugador <= 0)
        {
            {
                Destroy(jugador);
                Debug.Log("Jugador muerto");
            }
        }
    }

}


