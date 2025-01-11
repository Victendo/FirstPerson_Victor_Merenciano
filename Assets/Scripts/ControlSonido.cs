using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSonido : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {

        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            CargarVolumen();
        }
        else
        {
            CargarVolumen();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarVolumen()
    {
        AudioListener.volume = volumeSlider.value;
        GuardarVolumen();
    }

    private void CargarVolumen()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void GuardarVolumen()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}
