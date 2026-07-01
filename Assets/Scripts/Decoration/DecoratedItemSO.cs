using UnityEngine;

namespace Decoration
{
    [CreateAssetMenu(fileName = "Shop Item")]
    public class DecoratedItemSO : ScriptableObject
    {
        public string itemName;
        public Sprite itemSprite;
        public int itemPrice;
        public int itemQuantity;
        public int itemMaxQuantity;
    }
}
