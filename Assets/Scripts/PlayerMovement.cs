using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        MovePlayer(xInput, yInput);
    }


    void MovePlayer(float xInput, float yInput)
    {
        xInput *= speed * Time.deltaTime;
        yInput *= speed * Time.deltaTime;

        if (xInput < 0)
        {
            rend.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (xInput > 0)
        {
            rend.transform.localScale = new Vector3(1, 1, 1);
        }

        transform.Translate(xInput, yInput, 0);

        
    }
}
