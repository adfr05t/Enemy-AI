using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour myBehaviourScript;
    [SerializeField] private float patrolUpperYLimit;
    [SerializeField] private float patrolLowerYLimit;
    [SerializeField] private float patrolSpeed;
    public bool movingUpwards = false;


    public void UpdateState()
    {
        Vector3 playerPos = myBehaviourScript.playerTransform.position;
        float xDistToPlayer = Mathf.Abs(playerPos.x - transform.position.x);

        if (xDistToPlayer < myBehaviourScript.shootingRange)
        {
            myBehaviourScript.currentBehaviour = EnemyBehaviour.BehaviourState.Shoot;
        }

        else if (movingUpwards)
        {
            transform.Translate(0, 1 * patrolSpeed * Time.deltaTime, 0);
            if (transform.position.y >= patrolUpperYLimit)
            {
                movingUpwards = false;
            }
        }
        else if (!movingUpwards)
        {
            transform.Translate(0, -1 * patrolSpeed * Time.deltaTime, 0);
            if (transform.position.y <= patrolLowerYLimit)
            {
                movingUpwards = true;
            }
        }
    }
}
