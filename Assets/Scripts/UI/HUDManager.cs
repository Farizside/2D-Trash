using System;
using Dialogue;
using Player;
using Quest;
using TMPro;
using Trash;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class HUDManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text _areaText;
        public TMP_Text _coinText;
        public GloveUI GloveUI;

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += (arg0, scene) =>
            {
                if (SceneManager.GetActiveScene().name == "MainMenu")
                {
                    Destroy(PlayerController.Instance.gameObject);
                    Destroy(QuestController.Instance.gameObject);
                    Destroy(DialogueController.Instance.gameObject);
                    return;
                }
                _areaText.text = $"Area: {scene.name}";
            };
        }
        
        private void Start()
        {
            _areaText.text = $"Area : {SceneManager.GetActiveScene().name}";
            _coinText.text = $"Koin : {PlayerController.Instance.coin}";
        }

        public void UpdateCoin()
        {
            _coinText.text = $"Koin : {PlayerController.Instance.coin}";
        }
    }
}
