using System;
using UnityEngine;

namespace Player
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        private void Start()
        {
            PlayerController.Instance.gameObject.transform.position = _spawnPoint.position;
            PlayerController.Instance.playerQuest.ResetQuest();
        }
    }
}
