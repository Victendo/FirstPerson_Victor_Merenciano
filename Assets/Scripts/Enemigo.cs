using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float danhoAtaque;
    [SerializeField] Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
    

    private NavMeshAgent agent;
    private FirstPerson player;
    private Animator anim;
    private bool ventanaAbierta = false;
    private bool danhoRealizado = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();


        player = GameObject.FindObjectOfType<FirstPerson>();
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();

        if(ventanaAbierta)
        {
            DetectarJugador();
        }

    }

    private void DetectarJugador()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);

        if ((collsDetectados.Length > 0))
        {
            for (int i = 0; i < collsDetectados.Length; i++)
            {
                if (collsDetectados[i].tag == "Player")
                {
                    collsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoAtaque);
                }
            }
            danhoRealizado = true;
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
