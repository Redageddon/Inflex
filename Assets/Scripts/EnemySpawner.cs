using UnityEngine;

public class EnemySpawner : Object
{
    public static void CreateEnemy(GameObject enemy, int enemyNumber, float speed)
    {
        var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
        enemyInstance.name = "Enemy" + enemyNumber;
        enemyInstance.GetComponent<HitObject>().CurrentEnemy = enemyNumber;
        enemyInstance.GetComponent<HitObject>().Speed = speed;
        enemyInstance.SetActive(true);
    }
}