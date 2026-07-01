using UnityEngine;

namespace Trash
{
    [CreateAssetMenu(fileName =  "TrashSO", menuName = "Trash")]
    public class TrashSO : ScriptableObject
    {
        [SerializeField] private string trashName;
        [SerializeField] private string trashDescription;
        [SerializeField] private TrashEnum trashType;
        [SerializeField] private Sprite trashIcon;
        [SerializeField] private int trashPrice;
    }
}
