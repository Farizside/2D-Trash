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

        private void Awake()
        {
            _areaText.text = $"Area: {SceneManager.GetActiveScene().name}";
        }
    }
}
