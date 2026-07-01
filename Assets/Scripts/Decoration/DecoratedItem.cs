using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Decoration
{
    public class DecoratedItem : MonoBehaviour
    {
        public DecoratedItemSO itemSO;
        public Button button;
        public TMP_Text buttonText;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemPrice;
        [SerializeField] private Image itemImage;

        private void Start()
        {
            itemName.text = itemSO.itemName;
            itemPrice.text = "Harga : " + itemSO.itemPrice;
            itemImage.sprite = itemSO.itemSprite;
        }
    }
}
