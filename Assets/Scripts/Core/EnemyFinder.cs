using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SugARTechnology.Scripts.Core 
{
    public class EnemyFinder : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private LayerMask mask;
        public Enemy FindNearestEnemy()
        {
            List<Enemy> enemyList = FindEnemies();

            if (enemyList.Count == 0)
                return null;

            Enemy closestEnemy = enemyList[0];

            foreach (Enemy enemy in enemyList)
            {
                if (DistanceBetweenEnemy(enemy) < DistanceBetweenEnemy(closestEnemy))
                {
                    closestEnemy = enemy;
                }
            }
            return closestEnemy;
        }

        private List<Enemy> FindEnemies()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, mask);

            List<Enemy> enemyList = new List<Enemy>();
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent(out Enemy enemy))
                    enemyList.Add(enemy);
            }

            return enemyList;
        }

        private float DistanceBetweenEnemy(Enemy targetEnemy)
        {
            return Vector3.Distance(transform.position, targetEnemy.transform.position);
        }
    }
}

