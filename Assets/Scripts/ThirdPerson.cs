using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float smoothing;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadRotacion;
    CharacterController controller;
    private Camera cam;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
        if (input.sqrMagnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion,
                smoothing);
            transform.eulerAngles = new Vector3(0, anguloSuave, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
            anim.SetBool("Walking", true);
        }

        else
        {
            anim.SetBool("Walking", false);
        }


    }
}
