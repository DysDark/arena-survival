using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemyInformation[] enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(EnemyInformation enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.Attack();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

