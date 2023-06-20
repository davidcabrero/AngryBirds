using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;

public class ObjetoDestruido : MonoBehaviour
{
    [SerializeField] float vidaRestante;
    private float vidaInicial;
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spriteRoto;
    [SerializeField] GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > vidaRestante)
        {
            Destroy(gameObject, 0.1f);
            if (explosionPrefab != null)
            {
                var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

        }
        else
        {
            vidaRestante -= collision.relativeVelocity.magnitude;
        }
        if (vidaRestante < vidaInicial / 2)
        {
            spriteRenderer.sprite = spriteRoto;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        vidaInicial = vidaRestante;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
