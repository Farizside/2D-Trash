using System;
using UnityEngine;

namespace Dialogue
{
    public class Monologue : MonoBehaviour
    {
        [SerializeField] private DialogueData _monologue;
        [SerializeField] private bool _isPlayOnAwake;

        private void Start()
        {
            if (_isPlayOnAwake)
            {
                DialogueController.Instance.CurrentDialogue = _monologue._dialogueList[0];
                DialogueController.Instance.StartDialogue();
            }
        }
    }
}
