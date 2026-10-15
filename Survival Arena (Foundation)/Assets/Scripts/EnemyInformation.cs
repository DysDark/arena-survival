using System;
using UnityEngine;

public abstract class EnemyInformation : MonoBehaviour 
{
    protected int damage;
    protected string enemyName;

    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected Transform player;

    private Rigidbody enemyRb;

    protected virtual void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        FollowPlayer();
    }

    public void Damage()
    {
        Debug.Log($"{name} damaged player by {damage} damage points.");
    }

    protected virtual void FollowPlayer()
    {
        if (player == null || enemyRb == null)
            return;
        
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
            direction.Normalize();

        Vector3 velocity = enemyRb.linearVelocity;
        velocity.x = direction.x * moveSpeed;
        velocity.z = direction.z * moveSpeed;

        enemyRb.linearVelocity = velocity;
    }

    public abstract void Attack();
}