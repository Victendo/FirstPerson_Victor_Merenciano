using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float vidas;

    [Header("Detección del Suelo")]
    [SerializeField] private Transform pies;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;

    [Header("Movimiento")]
    [SerializeField] private float escalaGravedad;
    [SerializeField] private float velocidad;
    [SerializeField] private float alturaSalto;
    private Camera cam;
    
    private CharacterController controller;

    private Vector3 movimientoVertical;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;

        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);
        if(input.sqrMagnitude > 0)
        {
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;
            controller.Move(movimiento * 5 * Time.deltaTime);
        }
        AplicarGravedad();
        DeteccionSuelo();
    }

    private void AplicarGravedad()
    {
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }

    private void DeteccionSuelo()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(pies.position, radioDeteccion, queEsSuelo);

        if(collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
            Saltar();
        }
    }

    private void Saltar()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }
    }

    private bool EnSuelo()
    {
        bool resultado = Physics.CheckSphere(pies.position, radioDeteccion, queEsSuelo);
        return resultado;
    }

    public void RecibirDanho(float danhoRecibido)
    {
        Debug.Log("Danho realizado");
        vidas -= danhoRecibido;
        if (vidas <= 0)
        {
            {
                Destroy(gameObject);
                Debug.Log("Jugador muerto");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pies.position, radioDeteccion);
    }




}
