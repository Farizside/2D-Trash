using Dialogue;
using Interactable;
using Quest;
using UnityEngine;

namespace NPC
{
    public class NPCDialogueController : MonoBehaviour, IInteractable
    {
        [SerializeField] DialogueData _dialogueData;
        [SerializeField] DialogueState _currentState; 
        [SerializeField] QuestData _questData;
        
        public void Interact()
        {
            switch (_currentState)
            {
                case DialogueState.Start:
                    DialogueController.Instance.CurrentDialogue = _dialogueData._dialogueList[(int)_currentState];
                    DialogueController.Instance.StartDialogue();
                    QuestController.Instance.ActiveQuests.Add(_questData);
                    QuestController.Instance.UpdateAllQuests();
                    _currentState++;
                    return;
                case DialogueState.Progress:
                    if (_questData.questState == QuestState.Finished)
                    {
                        _currentState++;
                    }
                    break;
                case DialogueState.End:
                    QuestController.Instance.ActiveQuests.Remove(_questData);
                    break;
            }
            DialogueController.Instance.CurrentDialogue = _dialogueData._dialogueList[(int)_currentState];
            DialogueController.Instance.StartDialogue();
        }
    }
}
