using UnityEngine;

public class RangedEnemy : EnemyInformation
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    public override void Attack()
    {
        // distance is calculated in the main class which represent 
        // the distance from the player, so the statement checks if 
        // the enemy in the player range.
            Debug.Log("Attacks with projectile");
    }
}
