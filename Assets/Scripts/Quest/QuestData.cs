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
                case QuestType.Kertas:
                    current = PlayerController.Instance.playerQuest.KertasCount;
                    break;
                case QuestType.Residu:
                    current = PlayerController.Instance.playerQuest.ResiduCount;
                    break;
                case QuestType.B3:
                    current = PlayerController.Instance.playerQuest.B3Count;
                    break;
                case QuestType.Decorate:
                    current = PlayerController.Instance.playerQuest.DecorateCount;
                    break;
            }

            if (current >= target)
            {
                questState = QuestState.Finished;
            }
        }
    }

    public enum QuestType
    {
        All,
        Organik,
        Anorganik,
        Kertas,
        Residu,
        B3,
        Decorate
    }

    public enum QuestState
    {
        Started,
        Finished
    }
}