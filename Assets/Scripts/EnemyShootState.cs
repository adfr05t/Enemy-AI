using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootState : MonoBehaviour
{
    [SerializeField] EnemyBehaviour myBehaviourScript;
    public float yMarginForAttacks;
    [SerializeField] GameObject bullet;
    private SpriteRenderer rend;
    private bool canShoot;
    [SerializeField] private float cooldownLength;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        canShoot = true;
    }


    public void UpdateState()
    {
        Vector3 playerPos = myBehaviourScript.playerTransform.position;

        float xDistToPlayer = Mathf.Abs(playerPos.x - transform.position.x);

        if (xDistToPlayer < myBehaviourScript.punchingRange)
        {
            myBehaviourScript.currentBehaviour = EnemyBehaviour.BehaviourState.Punch;
        }
        else if (xDistToPlayer > myBehaviourScript.shootingRange)
        {
            myBehaviourScript.currentBehaviour = EnemyBehaviour.BehaviourState.Patrol;
        }

        if ((transform.position.y > playerPos.y - yMarginForAttacks && transform.position.y < playerPos.y + yMarginForAttacks) && canShoot)
        {
            myBehaviourScript.FacePlayer();
            Shoot();
        }
        else
        {
            Vector2 targetPos = new Vector2(transform.position.x, playerPos.y);
            myBehaviourScript.MoveToPosition(targetPos);
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0.01f), Quaternion.identity);

        // Set direction for bullet
        if (rend.transform.localScale.x == 1)
        {
            newBullet.GetComponent<Bullet>().xDir = 1;
        }
        else
        {
            newBullet.GetComponent<Bullet>().xDir = -1;
        }

        canShoot = false;
        StartCoroutine(ShootCooldown());
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(cooldownLength);
        canShoot = true;
    }
}
