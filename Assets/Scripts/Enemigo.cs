using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vidas;
    [SerializeField] private float danhoAtaque;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;

    private NavMeshAgent agent;
    private FirstPerson player;
    private Animator anim;
    private bool ventanaAbierta = false;
    private bool danhoRealizado = false;
    private Rigidbody[] huesos;

    public float Vidas { get => vidas; set => vidas = value; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();
        player = GameObject.FindObjectOfType<FirstPerson>();

        CambiarEstadoHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();

        if(ventanaAbierta && danhoRealizado == false)
        {
            DetectarJugador();
        }

    }

    private void DetectarJugador()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);

        if (collsDetectados.Length > 0)
        {

            for(int i = 0; i < collsDetectados.Length; i++)
            {
                if (collsDetectados[i].tag == "Player")
                {
                    if (ventanaAbierta)
                    {
                        GameManager.Instance.RecibirDanho(danhoAtaque);
                    }
                }
            }
            
        }
    }

    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attacking", true);
        }
    }

    public void Morir()
    {
        agent.enabled = false;
        anim.enabled = false;
        CambiarEstadoHuesos(false);
        Destroy(gameObject, 10);
    }

    private void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }

    #region Eventos de animacion
    private void FinAtaque()
    {
        agent.isStopped = false;
        danhoRealizado = false;
        anim.SetBool("attacking", false);
    }

    private void AbrirVentanaAtaque()
    {
        ventanaAbierta = true;
    }

    private void CerrarVentanaAtaque()
    {
        ventanaAbierta = false;
    }
    #endregion








}
