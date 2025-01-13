using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float tiempoVida;
    [SerializeField] private float radioExplosion;
    [SerializeField] private LayerMask queEsDanhable;

    [SerializeField] private AudioSource sonidoExplosion;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward.normalized * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, tiempoVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        //sonidoExplosion.Play();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioExplosion, queEsDanhable);
        
        if(collsDetectados.Length > 0)
        {
            foreach (Collider coll in collsDetectados)
            {
                coll.GetComponent<ParteDeEnemigo>().Explotar();
                coll.GetComponent<Rigidbody>().isKinematic = false;


                coll.GetComponent<Rigidbody>().AddExplosionForce(80, transform.position, radioExplosion, 15.5f, ForceMode.Impulse);
            }

        }
    }
}
