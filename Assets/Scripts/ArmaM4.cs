using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaM4 : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;

    private Camera cam;
    private float timer;

    [SerializeField] private AudioSource sonidoDisparo;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        timer = misDatos.cadenciaAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timer >= misDatos.cadenciaAtaque)
        {
            sonidoDisparo.Play();
            system.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);
                }

            }

            timer = 0;
        }
    }
}
