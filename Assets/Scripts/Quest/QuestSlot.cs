using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    public class QuestSlot : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _quest;
    
        public void SetQuestSlot(QuestData questData)
        {
            _title.text = questData.title;
            _quest.text = questData.quest + $"({questData.current}/{questData.target})";
            _background.color = questData.questState == QuestState.Finished ? Color.green : Color.yellow;
        }
    }
}
