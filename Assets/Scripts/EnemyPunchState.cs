using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunchState : MonoBehaviour
{
    [SerializeField] EnemyBehaviour myBehaviourScript;
    public float yMarginForAttacks;
    private bool canPunch;
    [SerializeField] float punchingRange;
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

        bool playerInPunchingRange = (xDistToPlayer < punchingRange && yDistToPlayer < yMarginForAttacks);

        if (xDistToPlayer > 4.5)
        {
            myBehaviourScript.currentBehaviour = EnemyBehaviour.BehaviourState.Shoot;
        }
        else if (playerInPunchingRange && canPunch)
        {
            myBehaviourScript.FacePlayer();
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
}
