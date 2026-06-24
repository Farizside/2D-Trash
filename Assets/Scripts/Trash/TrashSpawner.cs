using System.Collections.Generic;
using UnityEngine;

namespace Trash
{
    [System.Serializable]
    public class TrashCategory
    {
        public TrashEnum category;
        public List<GameObject> prefabs;
        public int amount = 10;
    }

    public class TrashSpawner : MonoBehaviour
    {
        [SerializeField] private List<TrashCategory> _trashCategories;
        [SerializeField] private Vector3 _spawnArea = new Vector3(10, 10, 0);

        private void Awake()
        {
            SpawnAllTrash();
        }

        private void SpawnAllTrash()
        {
            foreach (TrashCategory category in _trashCategories)
                SpawnTrashByCategory(category);
        }

        private void SpawnTrashByCategory(TrashCategory category)
        {
            if (category.prefabs == null || category.prefabs.Count == 0)
            {
                Debug.LogWarning($"No prefabs assigned for category: {category.category}");
                return;
            }

            GameObject categoryParent = new GameObject(category.category.ToString());
            categoryParent.transform.SetParent(transform);

            for (int i = 0; i < category.amount; i++)
            {
                Vector2 spawnPoint;

                do
                {
                    spawnPoint = GetRandomPointInArea();
                }
                while (Physics2D.OverlapPoint(spawnPoint) != null);

                GameObject prefab = category.prefabs[Random.Range(0, category.prefabs.Count)];
                Instantiate(prefab, spawnPoint, Quaternion.identity, categoryParent.transform);
            }
        }

        private Vector2 GetRandomPointInArea()
        {
            float x = Random.Range(
                transform.position.x - _spawnArea.x * 0.5f,
                transform.position.x + _spawnArea.x * 0.5f);

            float y = Random.Range(
                transform.position.y - _spawnArea.y * 0.5f,
                transform.position.y + _spawnArea.y * 0.5f);

            return new Vector2(x, y);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, _spawnArea);
        }
    }
}