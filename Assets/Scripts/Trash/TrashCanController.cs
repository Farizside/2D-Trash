using Interactable;
using Player;
using UnityEngine;

namespace Trash
{
    public class TrashCanController : MonoBehaviour, IInteractable
    {
        public TrashEnum category;
        
        public void Interact()
        {
            TrashController trash = PlayerController.Instance.playerInteraction._collectedTrash;
            if (!trash) return;
            if (trash.category == category)
            {
                PlayerController.Instance.playerInteraction._collectedTrash = null;
                trash.OnProgress();
                Destroy(trash.gameObject);
            }
        }
    }
}
