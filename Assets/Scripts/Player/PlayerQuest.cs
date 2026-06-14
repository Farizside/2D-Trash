using UnityEngine;

namespace Player
{
    public class PlayerQuest : MonoBehaviour
    {
        public int TrashCount;
        public int OrganikCount;
        public int AnorganikCount;
        
        public void ResetQuest()
        {
            TrashCount = 0;
            OrganikCount = 0;
            AnorganikCount = 0;
        }
    }
}
