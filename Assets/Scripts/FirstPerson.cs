using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [Header("Variables Movimiento")]
    CharacterController controller;
    private Camera cam;
    
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float nivelGravedad;
    private Vector3 movimientoVertical; 
    [SerializeField] private float alturaSalto;
    

    [Header("Variables DeteccionDeSuelo")]
    [SerializeField] private Transform piesPlayer;
    [SerializeField] private float radioDeteccion;
    [SerializeField] private LayerMask queEsSuelo;

    Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;

        
        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);


        if (input.sqrMagnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);


            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }

        Gravedad();
        DeteccionSuelo();

    }

    private void Gravedad()
    {
        
        movimientoVertical.y += nivelGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);

    }

    private void DeteccionSuelo()
    {
        
        Collider[] collsDetectados = Physics.OverlapSphere(piesPlayer.position, radioDeteccion, queEsSuelo);
        
        if (collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
            Salto();

        }
    }

    private void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * nivelGravedad * alturaSalto);
        }
    }
}
