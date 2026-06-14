using System.Collections.Generic;
using UnityEngine;

namespace Trash
{
    public class TrashSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> trashPrefab;
        [SerializeField] private int trashAmount = 10;
        [SerializeField] private Vector3 spawnArea = new Vector3(10, 10, 0);

        private void Awake()
        {
            SpawnTrash();
        }

        private void SpawnTrash()
        {
            for (int i = 0; i < trashAmount; i++)
            {
                Vector2 spawnPoint;

                do
                {
                    spawnPoint = GetRandomPointInArea();
                }
                while (Physics2D.OverlapPoint(spawnPoint) != null);

                Instantiate(trashPrefab[Random.Range(0, trashPrefab.Count)], spawnPoint, Quaternion.identity, transform);
            }
        }

        private Vector2 GetRandomPointInArea()
        {
            float x = Random.Range(
                transform.position.x - spawnArea.x * 0.5f,
                transform.position.x + spawnArea.x * 0.5f);

            float y = Random.Range(
                transform.position.y - spawnArea.y * 0.5f,
                transform.position.y + spawnArea.y * 0.5f);

            return new Vector2(x, y);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, spawnArea);
        }
    }
}