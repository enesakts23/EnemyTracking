using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SugARTechnology.Scripts.Core 
{
    public class DroneController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        [SerializeField] private EnemyFinder enemyFinder;
        private Player player;

        private Entity target;

        private float flightHeigth = 2f;
        private float rotateRadius = 2f;

        private void Start()
        {
            player = enemyFinder.GetComponent<Player>();
            target = player;
        }
        private void Update()
        {
            SetTarget();


            if (CalculateHorizontalDistance(target) < rotateRadius)
            {
                if (target is Enemy)
                    RotateAround(target);
            }
            else
            {
                MoveToPosition(target.transform.position);
            }

        }

        private void SetTarget()
        {
            Enemy enemy = enemyFinder.FindNearestEnemy();
            target = enemy ? enemy : player;
        }

        private void MoveToPosition(Vector3 position)
        {
            transform.position = Vector3.MoveTowards(transform.position, position + Vector3.up * flightHeigth, moveSpeed * Time.deltaTime);
            transform.LookAt(position);
        }

        private void RotateAround(Entity entity)
        {
            this.transform.RotateAround(entity.HeadPosition, Vector3.up, rotationSpeed * Time.deltaTime);
            this.transform.LookAt(entity.HeadPosition);
        }

        private float CalculateHorizontalDistance(Entity entity)
        {
            Vector3 horizontalEnemyDistance = entity.transform.position - entity.transform.position.y * Vector3.up;
            Vector3 horizontalDroneDistance = transform.position - transform.position.y * Vector3.up;
            return Vector3.Distance(horizontalDroneDistance, horizontalEnemyDistance);
        }
    }

}

