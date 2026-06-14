using System.Collections.Generic;
using Input;
using Interactable;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private List<Transform> _interactableObjects = new List<Transform>();
        public TrashController _collectedTrash;

        private void OnEnable()
        {
            InputManager.interactAction += Interact;
        }

        private void OnDisable()
        {
            InputManager.interactAction -= Interact;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                _interactableObjects.Add(other.transform);
            };
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                _interactableObjects.Remove(other.transform);
            }
        }

        private void Interact()
        {
            if (_interactableObjects.Count <= 0) return;
            for (int i = 0; i < _interactableObjects.Count; i++)
            {
                var interactable = _interactableObjects[i].gameObject.GetComponent<IInteractable>();
                interactable.Interact();
            }
        }
    }
}
