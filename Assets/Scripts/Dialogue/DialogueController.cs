using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueController : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private GameObject _dialogueCanvas;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _timing;
        
        public static DialogueController Instance;
        public static Action OnFinishDialogue;
        public Dialogue CurrentDialogue;

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

        public void StartDialogue()
        {
            _dialogueCanvas.SetActive(true);
            StartCoroutine(ShowText());
        }

        public void FinishDialogue()
        {
            _dialogueCanvas.SetActive(false);
            StopCoroutine(ShowText());
            OnFinishDialogue?.Invoke();
        }

        private IEnumerator ShowText()
        {
            _text.text = "";
            foreach (var dialogue in CurrentDialogue.text)
            {
                foreach (var c in dialogue)
                {
                    _text.text += c;
                    yield return new WaitForSeconds(_timing);
                }
                yield return new WaitForSeconds(2);
                _text.text = "";
            }
            FinishDialogue();
        }
    }
}
