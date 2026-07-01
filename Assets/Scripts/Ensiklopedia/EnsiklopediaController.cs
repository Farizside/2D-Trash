using System;
using System.Collections.Generic;
using TMPro;
using Trash;
using UnityEngine;
using UnityEngine.UI;

public class EnsiklopediaController : MonoBehaviour
{
    [SerializeField] private List<TrashCategorySO> _categories;
    
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _color;
    [SerializeField] private Image _icon;

    private void Awake()
    {
        OnButtonClick(_categories[0]);
        _icon.preserveAspect = true;
    }

    public void OnButtonClick(TrashCategorySO category)
    {
        _name.text = "Kategori : " + category._category;
        _description.text = "Deskripsi : " + category._description;
        _color.text = "Warna Tong : " + category._color;
        _icon.sprite = category._icon;
    }
}
