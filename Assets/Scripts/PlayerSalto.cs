using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSalto : MonoBehaviour
{
    public float fuerzaSalto = 10f;
    private Rigidbody2D rb;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.velocity = Vector2.up * fuerzaSalto;
            enSuelo = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}