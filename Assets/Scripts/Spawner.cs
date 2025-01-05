using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemigo enemigoPrefab;
    void Start()
    {
        StartCoroutine(Spawnear());
    }

    private IEnumerator Spawnear()
    {
        while(true)
        {
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }

    
}
