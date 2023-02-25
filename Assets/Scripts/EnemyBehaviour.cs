using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public enum BehaviourState { NotAttacking, Shoot, Punch };
    public BehaviourState currentBehaviour;
    
    [SerializeField] private EnemyShootState shootState;
    [SerializeField] private EnemyPunchState punchState;
    [SerializeField] private EnemyNotAttackingState notAttackingState;

    public Transform playerTransform;

    [SerializeField] private float speed;



    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
      //  currentBehaviour = BehaviourState.NotAttacking;
    }

    void Update()
    {
        switch (currentBehaviour)
        {
            case BehaviourState.NotAttacking:
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

        // Make transform pos z = y for sprite ordering
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        FacePlayer();
    }

    void FacePlayer()
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
