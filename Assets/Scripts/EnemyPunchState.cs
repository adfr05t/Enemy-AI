using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunchState : MonoBehaviour
{
    [SerializeField] EnemyBehaviour myBehaviourScript;
    public float yMarginForAttacks;
    private bool canPunch;
    [SerializeField] float punchingRangeMin, punchingRangeMax;
    [SerializeField] private float cooldownLength;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        canPunch = true;
    }


    public void UpdateState()
    {
        Vector3 playerPos = myBehaviourScript.playerTransform.position;

        // calc if enemy is within punching distance
        float xDistToPlayer = Mathf.Abs(playerPos.x - transform.position.x);
        float yDistToPlayer = Mathf.Abs(playerPos.y - transform.position.y);

        bool playerInPunchingRange = (xDistToPlayer <= punchingRangeMax && xDistToPlayer >= punchingRangeMin && yDistToPlayer <= yMarginForAttacks); 


        if (playerInPunchingRange)
        {
            FacePlayer(playerPos.x);
            Punch();
        }
        else
        {
            Vector2 targetPos = new Vector2(transform.position.x, playerPos.y);
            myBehaviourScript.MoveToPosition(targetPos);
        }
    }

    void Punch()
    {
        // set anim trigger
        anim.SetTrigger("Punch");

        canPunch = false;
        StartCoroutine(PunchCooldown());
    }


    IEnumerator PunchCooldown()
    {
        yield return new WaitForSeconds(cooldownLength);
        canPunch = true;
    }

    void FacePlayer(float playerXPos)
    {
        if (transform.position.x < playerXPos)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
