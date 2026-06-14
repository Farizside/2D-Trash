using Dialogue;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quest
{
    [CreateAssetMenu(fileName = "QuestData", menuName = "Quests/QuestData")]
    public class QuestData : ScriptableObject
    {
        public QuestType type;
        public string title;
        public string quest;
        public int target;
        public int current;
        public QuestState questState;
        public string sceneName;

        private void OnEnable()
        {
            DialogueController.OnFinishDialogue += OnQuestFinished;
        }

        private void OnValidate()
        {
            current = 0;
            questState = QuestState.Started;
        }

        public void UpdateState()
        {
            switch (type)
            {
                case QuestType.All:
                    current = PlayerController.Instance.playerQuest.TrashCount;
                    break;
                case QuestType.Organik:
                    current = PlayerController.Instance.playerQuest.OrganikCount;
                    break;
                case QuestType.Anorganik:
                    current = PlayerController.Instance.playerQuest.AnorganikCount;
                    break;
            }

            if (current >= target)
            {
                questState = QuestState.Finished;
            }
        }
    
        private void OnQuestFinished()
        {
            if (questState == QuestState.Finished && !string.IsNullOrEmpty(sceneName))
            {
                QuestController.Instance.ActiveQuests.Remove(this);
                DialogueController.OnFinishDialogue -= OnQuestFinished;
                if (!string.IsNullOrEmpty(sceneName))
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }

    public enum QuestType
    {
        All,
        Organik,
        Anorganik
    }

    public enum QuestState
    {
        Started,
        Finished
    }
}