using TMPro;
using UnityEngine;

namespace Trash
{
    [CreateAssetMenu(fileName = "Trash Category")]
    public class TrashCategorySO : ScriptableObject
    {
        public TrashEnum _category;
        public string _description;
        public string _color;
        public Sprite _icon;
    }
}
