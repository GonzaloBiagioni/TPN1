using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public float intervaloGeneracion = 3.5f; 

    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = intervaloGeneracion;
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            GenerarObstaculo();
            tiempoRestante = intervaloGeneracion;
        }
    }

    void GenerarObstaculo()
    {
        int tipoObstaculo = Random.Range(0, ObjectPool.instancia.objectPrefabs.Length);
        GameObject obstaculo = ObjectPool.instancia.GetObject(tipoObstaculo);
        obstaculo.transform.position = spawnPoint.position;
    }
}