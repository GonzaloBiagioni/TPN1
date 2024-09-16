using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloMovil : MonoBehaviour
{
    public float velocidad = 5f;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        if (transform.position.x < -7)
        {
            transform.position = posicionInicial;
        }
    }
}