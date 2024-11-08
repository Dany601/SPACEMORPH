using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullar : MonoBehaviour
{
    [SerializeField] private float velocidadmov;
    [SerializeField] private Transform[] puntosmov;
    [SerializeField] private float distanciamin;
    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        numeroAleatorio = Random.Range(0, puntosmov.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        girar();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosmov[numeroAleatorio].position, velocidadmov * Time.deltaTime);

        if(Vector2.Distance(transform.position, puntosmov[numeroAleatorio].position) < distanciamin)
        {
            numeroAleatorio = Random.Range(0, puntosmov.Length);
            girar();
        }
    }

    private void girar()
    {
        if(transform.position.x < puntosmov[numeroAleatorio].position.x && transform.position.y < puntosmov[numeroAleatorio].position.y)
        {
            spriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
        }
    }


}
