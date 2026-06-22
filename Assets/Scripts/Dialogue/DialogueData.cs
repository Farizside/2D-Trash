using System;
using System.Collections.Generic;
using Trash;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName =  "New Dialogue Data", menuName = "Dialogue Data")]
    public class DialogueData : ScriptableObject
    {
        public List<Dialogue> _dialogueList;
    }

    [Serializable]
    public struct Dialogue
    {
        public DialogueState state;
        public List<Message> messages;
    }

    [Serializable]
    public struct Message
    {
        public string actor;
        public string message;
    }

    public enum DialogueState
    {
        Start = 0,
        Progress = 1,
        End = 2,
    }
}
