using UnityEngine;

public class RangedEnemy : EnemyInformation
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {

    }

    public override void Attack()
    {
        Debug.Log("Attacks with projectile");
    }
}
