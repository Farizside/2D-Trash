using System;
using System.Collections.Generic;
using Input;
using Interactable;
using Trash;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private List<Transform> _interactableObjects = new List<Transform>();
        public TrashEnum _currentGlove;
        public TrashController _collectedTrash;

        private void OnEnable()
        {
            InputManager.interactAction += Interact;
            InputManager.changeGloveAction += ChangeGlove;
        }

        private void OnDisable()
        {
            InputManager.interactAction -= Interact;
            InputManager.changeGloveAction -= ChangeGlove;
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

        private void ChangeGlove()
        {
            _currentGlove = (TrashEnum)(((int)_currentGlove + 1) % Enum.GetValues(typeof(TrashEnum)).Length);
            PlayerController.Instance.hudManager.GloveUI.OnGloveChanged();
        }
    }
}
