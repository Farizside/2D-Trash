using UI;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerInteraction playerInteraction;
        public PlayerMovement playerMovement;
        public PlayerQuest playerQuest;
        public HUDManager hudManager;
        
        public static PlayerController Instance;
        
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
    }
}
