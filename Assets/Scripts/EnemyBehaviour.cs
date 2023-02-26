using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public enum BehaviourState { Patrol, Shoot, Punch };
    public BehaviourState currentBehaviour;
    
    [SerializeField] private EnemyShootState shootState;
    [SerializeField] private EnemyPunchState punchState;
    [SerializeField] private EnemyPatrolState notAttackingState;
    public float shootingRange;
    public float punchingRange;
    [SerializeField] private float speed;
    public Transform playerTransform;


    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        currentBehaviour = BehaviourState.Patrol;
    }

    void Update()
    {
        switch (currentBehaviour)
        {
            case BehaviourState.Patrol:
                notAttackingState.UpdateState();
                break;

            case BehaviourState.Shoot:
                shootState.UpdateState();
                break;

            case BehaviourState.Punch:
                punchState.UpdateState();
                break;
        }
    }

    public void MoveToPosition(Vector2 targetPos)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        FacePlayer();
    }

    public void FacePlayer()
    {
        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
