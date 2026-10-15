using UnityEngine;

public class MeleeEnemy : EnemyInformation
{

    private void Start()
    {

    }

    public override void Attack()
    {
        Debug.Log("Attacks with a sword");
    }
}
