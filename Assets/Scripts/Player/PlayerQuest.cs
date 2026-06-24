using UnityEngine;

namespace Player
{
    public class PlayerQuest : MonoBehaviour
    {
        public int TrashCount;
        public int OrganikCount;
        public int AnorganikCount;
        public int KertasCount;
        public int ResiduCount;
        public int B3Count;
        
        public void ResetQuest()
        {
            TrashCount = 0;
            OrganikCount = 0;
            AnorganikCount = 0;
            KertasCount = 0;
            ResiduCount = 0;
            B3Count = 0;
        }
    }
}
