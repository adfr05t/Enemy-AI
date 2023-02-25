using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNotAttackingState : MonoBehaviour
{
    [SerializeField] EnemyBehaviour myBehaviourScript;


    public void UpdateState()
    {
        Vector3 playerPos = myBehaviourScript.playerTransform.position;

        float xDistToPlayer = Mathf.Abs(playerPos.x - transform.position.x);



        if (xDistToPlayer < 7)
        {
            myBehaviourScript.currentBehaviour = EnemyBehaviour.BehaviourState.Shoot;
        }
    }
}
