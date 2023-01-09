using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public Transform shooter;
    public ParticleSystem bullet;
    public float shootingRange = 25f;
    private Transform enemyPosition;
    void Update()
    {
        WhoIsClosestEnemy();
        Aim();
    }
    void WhoIsClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestEnemy = null;
        float max = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float enemyDis = Vector3.Distance(transform.position, e.transform.position);

            if (enemyDis < max)
            {
                closestEnemy = e.transform;
                max = enemyDis;
            }
        }

        enemyPosition = closestEnemy;
    }
    void Aim()
    {
        if (enemyPosition != null)
        {
            float enemyDis = Vector3.Distance(transform.position, enemyPosition.position);
            shooter.LookAt(enemyPosition);

            if (enemyDis < shootingRange)
            {
                isShootable(true);
            }
            else
            {
                isShootable(false);
            }
        }
        else
        {
            isShootable(false);
        }
    }

    void isShootable(bool isActive)
    {
        ParticleSystem.EmissionModule emission = bullet.emission;
        emission.enabled = isActive;
    }
}