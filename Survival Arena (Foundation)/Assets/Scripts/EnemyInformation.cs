using UnityEngine;

public abstract class EnemyInformation : MonoBehaviour 
{
    //protected int damage;
    //protected string enemyName;

    protected float distance;

    // the maximum enemy range to interact with player
    [SerializeField] protected float maxDistance;
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected Transform player;

    private Rigidbody enemyRb;

    protected virtual void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    protected virtual void FixedUpdate()
    {
        // Methods which makes the enemy to follow the player
        FollowPlayer();
    }

    protected void Damage()
    {
        //Debug.Log($"{name} damaged player by {damage} damage points.");
    }

    protected virtual void FollowPlayer()
    {
        // Checks if ther is player and rigidbody on the scene
        if (player == null || enemyRb == null)
            return;
        
        distance = Vector3.Distance(transform.position, player.position);

        // Enemy will stop when they are in the their own range to the player, and also will attack the player
        if (distance <= maxDistance)
        {
            enemyRb.linearVelocity = new Vector3(0f, enemyRb.linearVelocity.y, 0f);
            Attack();
            return;
        }

        // Find the direction at which the enemy will move towards (player position)
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        direction.Normalize();

        // Move the enemy using linear velocity mulitplied bu the speed.
        enemyRb.linearVelocity = new Vector3(direction.x * moveSpeed, enemyRb.linearVelocity.y, direction.z * moveSpeed);
    }

    public abstract void Attack();
}