using System.Collections.Generic;
using Interactable;
using Player;
using Quest;
using Trash;
using UnityEngine;

public class TrashController : MonoBehaviour, IInteractable, IQuestObject
{
    public TrashEnum category;
    public void Interact()
    {
        if (PlayerController.Instance.playerInteraction._collectedTrash) return;
        PlayerController.Instance.playerInteraction._collectedTrash = this;
        gameObject.SetActive(false);
    }

    public void OnProgress()
    {
        PlayerController.Instance.playerQuest.TrashCount += 1;
        switch (category)
        {
            case TrashEnum.Organik:
                PlayerController.Instance.playerQuest.OrganikCount++;
                break;
            case TrashEnum.Anorganik:
                PlayerController.Instance.playerQuest.AnorganikCount++;
                break;
        }
        QuestController.Instance.UpdateAllQuests();
    }
}
