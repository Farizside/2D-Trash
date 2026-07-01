using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using Quest;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Decoration
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coinsText;
        [SerializeField] private TMP_Text _coinsText1;
        [SerializeField] private List<DecoratedItem> _items;
        private List<PlacedItem> _bangkuTaman = new List<PlacedItem>();
        private List<PlacedItem> _lampuJalan = new List<PlacedItem>();
        private List<PlacedItem> _airMancur = new List<PlacedItem>();

        private void Start()
        {
            _bangkuTaman.Clear();
            _lampuJalan.Clear();
            _airMancur.Clear();

            _bangkuTaman = FindObjectsByType<PlacedItem>(FindObjectsInactive.Include).Where(x => x.name == "Bangku Taman").ToList();
            _lampuJalan = FindObjectsByType<PlacedItem>(FindObjectsInactive.Include).Where(x => x.name == "Lampu Taman").ToList();
            _airMancur = FindObjectsByType<PlacedItem>(FindObjectsInactive.Include).Where(x => x.name == "Air Mancur").ToList();

            foreach (var item in _items)
            {
                item.itemSO.itemQuantity = 0;
            }
        }

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += OnSceneChanged;
            _coinsText.text = "Koin : " + PlayerController.Instance.coin;
            _coinsText1.text = "Koin : " + PlayerController.Instance.coin;
            CheckAvailability();
        }

        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnSceneChanged;
        }

        private void CheckAvailability()
        {
            foreach (DecoratedItem item in _items)
            {
                if (PlayerController.Instance.coin <= item.itemSO.itemPrice)
                {
                    item.button.interactable = false;
                    item.buttonText.text = "Koin Kurang";
                    continue;
                }

                if (item.itemSO.itemQuantity >= item.itemSO.itemMaxQuantity)
                {
                    item.button.interactable = false;
                    item.buttonText.text = "Stok Habis";
                    continue;
                }
                
                item.button.interactable = true;
                item.buttonText.text = "Beli";
            }
        }

        public void BuyItem(DecoratedItemSO itemSO)
        {
            PlayerController.Instance.playerQuest.DecorateCount++;
            QuestController.Instance.UpdateAllQuests();
            PlayerController.Instance.coin -= itemSO.itemPrice;
            _coinsText.text = "Koin : " + PlayerController.Instance.coin;
            _coinsText1.text = "Koin : " + PlayerController.Instance.coin;
            SpawnItem(itemSO.itemName, itemSO.itemQuantity);
            itemSO.itemQuantity++;
            CheckAvailability();
        }
        
        private void SpawnItem(string itemName, int idx)
        {
            switch (itemName)
            {
                case "Bangku Taman":
                    _bangkuTaman[idx].gameObject.SetActive(true);
                    break;
                case "Lampu Jalan":
                    _lampuJalan[idx].gameObject.SetActive(true);
                    break;
                case "Air Mancur":
                    _airMancur[idx].gameObject.SetActive(true);
                    break;
            }
        }

        private void OnSceneChanged(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.Scene scene)
        {
            _bangkuTaman.Clear();
            _lampuJalan.Clear();
            _airMancur.Clear();

            _bangkuTaman = FindObjectsByType<PlacedItem>(FindObjectsInactive.Include).Where(x => x.name == "Bangku Taman").ToList();
            _lampuJalan = FindObjectsByType<PlacedItem>(FindObjectsInactive.Include).Where(x => x.name == "Lampu Taman").ToList();
            _airMancur = FindObjectsByType<PlacedItem>(FindObjectsInactive.Include).Where(x => x.name == "Air Mancur").ToList();

            foreach (var item in _items)
            {
                item.itemSO.itemQuantity = 0;
            }
        }
    }
}
