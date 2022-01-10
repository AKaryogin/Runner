using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _equipButton;

    private Skin _skin;

    public event UnityAction<Skin, SkinView> EquipButtonClick;

    private void OnEnable()
    {
        _equipButton.onClick.AddListener(OnButtonClick);        
    }

    private void OnDisable()
    {
        _equipButton.onClick.RemoveListener(OnButtonClick);        
    }

    public void ChangeButtonText()
    {
        if(_skin.IsEquip)
            _equipButton.GetComponentInChildren<Text>().text = "Unequip";
        else
            _equipButton.GetComponentInChildren<Text>().text = "Equip";
    }

    public void Render(Skin skin)
    {
        _skin = skin;
        _label.text = skin.Label;
        _icon.sprite = skin.Icon;
    }

    private void OnButtonClick()
    {
        EquipButtonClick?.Invoke(_skin, this);
    }
}
