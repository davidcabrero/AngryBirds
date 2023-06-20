using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajaro : MonoBehaviour
{
    [SerializeField] Transform salidaPajaros;
    [SerializeField] float rangoEstiramiento;
    [SerializeField] float velocidadMaxima;

    Rigidbody2D cuerpoPajaro;

    Vector3 posicionPajaro;

    private void OnMouseDrag()
    {
        var puntoClicEnPantalla = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posicionPajaro = puntoClicEnPantalla - salidaPajaros.position;
        posicionPajaro.z = 0;
        if (posicionPajaro.magnitude > rangoEstiramiento)
        {
            posicionPajaro = posicionPajaro.normalized * rangoEstiramiento;
        }
        transform.position = posicionPajaro + salidaPajaros.position;
    }

    private void OnMouseUp()
    {
        cuerpoPajaro.bodyType = RigidbodyType2D.Dynamic;
        cuerpoPajaro.velocity = -posicionPajaro.normalized * velocidadMaxima * posicionPajaro.magnitude / rangoEstiramiento;
    }

    // Start is called before the first frame update
    void Start()
    {
        cuerpoPajaro = GetComponent<Rigidbody2D>();
        cuerpoPajaro.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

   
