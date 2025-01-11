using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuInicio;
    [SerializeField] private GameObject menuHistoria;
    [SerializeField] private GameObject menuOpciones;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void EntrarJuego()
    {
        SceneManager.LoadScene("FirstPerson");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void EntrarHistoria()
    {
        menuInicio.SetActive(false);
        menuHistoria.SetActive(true);
        menuOpciones.SetActive(false);
    }

    public void SalirHistoria()
    {
        menuInicio.SetActive(true);
        menuHistoria.SetActive(false);
        menuOpciones.SetActive(false);
    }

    public void EntrarOpciones()
    {
        menuInicio.SetActive(false);
        menuHistoria.SetActive(false);
        menuOpciones.SetActive(true);
    }

    public void SalirOpciones()
    {
        menuInicio.SetActive(true);
        menuHistoria.SetActive(false);
        menuOpciones.SetActive(false);
    }
}
