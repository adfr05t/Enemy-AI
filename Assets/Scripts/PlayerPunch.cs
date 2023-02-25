using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [SerializeField] private Animator anim;


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Punch();
        }
    }


    void Punch()
    {
        anim.SetTrigger("Punch");
    }
}
