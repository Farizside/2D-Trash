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
        if (PlayerController.Instance.playerInteraction._currentGlove != category) return;
        PlayerController.Instance.playerInteraction.PlayGrabSound();
        PlayerController.Instance.playerInteraction._collectedTrash = this;
        gameObject.SetActive(false);
    }

    public void OnProgress()
    {
        PlayerController.Instance.playerQuest.TrashCount += 1;
        PlayerController.Instance.coin += 50;
        switch (category)
        {
            case TrashEnum.Organik:
                PlayerController.Instance.playerQuest.OrganikCount++;
                break;
            case TrashEnum.Anorganik:
                PlayerController.Instance.playerQuest.AnorganikCount++;
                break;
            case TrashEnum.Kertas:
                PlayerController.Instance.playerQuest.KertasCount++;
                break;
            case TrashEnum.Residu:
                PlayerController.Instance.playerQuest.ResiduCount++;
                break;
            case TrashEnum.B3:
                PlayerController.Instance.playerQuest.B3Count++;
                break;
        }
        QuestController.Instance.UpdateAllQuests();
        PlayerController.Instance.hudManager.UpdateCoin();
    }
}
