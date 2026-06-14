using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    public class QuestController : MonoBehaviour
    {
        public List<QuestData> ActiveQuests = new List<QuestData>();
        
        public static QuestController Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void UpdateAllQuests()
        {
            foreach (var questData in ActiveQuests)
            {
                questData.UpdateState();
            }
        }
    }
}
