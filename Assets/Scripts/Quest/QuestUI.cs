using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quest
{
    public class QuestUI : MonoBehaviour
    {
        [SerializeField] private GameObject _questSlotPrefab;
        private List<QuestSlot> _questSlots = new List<QuestSlot>();

        private void OnEnable()
        {
            _questSlots = GetComponentsInChildren<QuestSlot>().ToList();
            UpdateQuestUI();
        }

        private void UpdateQuestUI()
        {
            ClearUI();
            foreach (var quest in QuestController.Instance.ActiveQuests)
            {
                var go  = Instantiate(_questSlotPrefab, transform);
                var questSlot = go.GetComponent<QuestSlot>();
                questSlot.SetQuestSlot(quest);
            }
        }

        private void ClearUI()
        {
            foreach (var questSlot in _questSlots)
            {
                Destroy(questSlot.gameObject);
            }
        }
    }
}
