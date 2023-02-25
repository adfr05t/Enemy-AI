using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int xDir;
    [SerializeField] private float speed;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(xDir * speed, 0);
    }


    void Update()
    {
        // Destroy bullet when offscreen
        if (transform.position.x < -9.5f || transform.position.x > 9.5f)
        {
            Destroy(gameObject);
        }
    }
}
