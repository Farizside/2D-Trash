using System;
using Dialogue;
using Interactable;
using Quest;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NPC
{
    public class NPCDialogueController : MonoBehaviour, IInteractable
    {
        [SerializeField] DialogueData _dialogueData;
        [SerializeField] DialogueState _currentState;
        [SerializeField] List<QuestData> _questDatas = new List<QuestData>();
        [SerializeField] string _sceneName;

        private void OnEnable()
        {
            DialogueController.OnFinishDialogue += OnAllQuestFinished;
        }

        public void Interact()
        {
            switch (_currentState)
            {
                case DialogueState.Start:
                    DialogueController.Instance.CurrentDialogue = _dialogueData._dialogueList[(int)_currentState];
                    DialogueController.Instance.StartDialogue();
                    foreach (var quest in _questDatas)
                    {
                        if (!QuestController.Instance.ActiveQuests.Contains(quest))
                            QuestController.Instance.ActiveQuests.Add(quest);
                    }
                    QuestController.Instance.UpdateAllQuests();
                    _currentState++;
                    return;

                case DialogueState.Progress:
                    QuestController.Instance.UpdateAllQuests();
                    if (AllQuestsFinished())
                        _currentState++;
                    break;

                case DialogueState.End:
                    QuestController.Instance.ActiveQuests.Clear();
                    break;
            }

            DialogueController.Instance.CurrentDialogue = _dialogueData._dialogueList[(int)_currentState];
            DialogueController.Instance.StartDialogue();
        }

        private bool AllQuestsFinished()
        {
            foreach (var quest in _questDatas)
            {
                if (quest.questState != QuestState.Finished) return false;
            }
            return true;
        }
        
        private void OnAllQuestFinished()
        {
            if (_currentState == DialogueState.End)
            {
                QuestController.Instance.ActiveQuests.Clear();
                PlayerController.Instance.playerInteraction.PlayWinSound();
                DialogueController.OnFinishDialogue -= OnAllQuestFinished;
                SceneManager.LoadScene(_sceneName);
            }
        }
    }
}