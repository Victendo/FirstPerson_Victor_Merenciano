using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;
    int indiceArmaActual = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArmaConTeclado();
    }
    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambiarArma(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambiarArma(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CambiarArma(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CambiarArma(3);
        }
    }

    private void CambiarArma(int nuevoIndice)
    {
        armas[indiceArmaActual].SetActive(false);

        if (nuevoIndice >= 0 && nuevoIndice < armas.Length)
        {

            indiceArmaActual = nuevoIndice;

            armas[indiceArmaActual].SetActive(true);
        }
    }
}
