using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WaterEffect : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Volume efecto;
    // Start is called before the first frame update
    void Start()
    {
        efecto = GetComponent<Volume>();
    }

    // Update is called once per frame
    void Update()
    {
        if(efecto.profile.TryGet(out LensDistortion distortion))
        {
            FloatParameter xValue = new FloatParameter(1 + Mathf.Cos(velocidad * Time.deltaTime) / 2);
            FloatParameter yValue = new FloatParameter(1+ Mathf.Sin(velocidad * Time.deltaTime) / 2);
            distortion.xMultiplier.SetValue(xValue);
            distortion.yMultiplier.SetValue(yValue);
        }
    }
}
