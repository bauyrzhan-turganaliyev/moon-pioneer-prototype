using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UnityEngine.AI
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _cube;

        [SerializeField] private float _raduis;
        [SerializeField] private float _everyXSecond;

        private float _nextUpdate = 1;
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Time.time >= _nextUpdate)
            {
                _nextUpdate = Time.time + _everyXSecond;
                UpdateEverySecond();
            }
        }

        private void UpdateEverySecond()
        {

            var position = RandomNavmeshLocation(_raduis);
            if (SetDestination(position))
            {
                var item = Instantiate(_cube);
                item.transform.position = RandomNavmeshLocation(_raduis);

                var nm = GameObject.FindObjectOfType<NavMeshSurface>();
                nm.UpdateNavMesh(nm.navMeshData);
            } else
            {
                print($"Wrong poition {position}");
            }
        }

        private bool SetDestination(Vector3 targetDestination)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(targetDestination, out hit, 1f, NavMesh.AllAreas))
            {
                return true;
            }
            return false;
        }

        private Vector3 RandomNavmeshLocation(float radius)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                finalPosition = hit.position;
            }
            return finalPosition;
        }
    }
}
