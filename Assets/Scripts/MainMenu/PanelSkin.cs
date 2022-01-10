using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelSkin : MonoBehaviour
{
    [SerializeField] private List<Skin> _skins;    
    [SerializeField] private SkinView _tamplate;
    [SerializeField] private GameObject _skinContainer;

    private Skin _currentSkin;
    private List<SkinView> _views = new List<SkinView>();

    private void OnDisable()
    {
        RemoveSkin();
    }

    private void Start()
    {
        _currentSkin = _skins.FirstOrDefault(p => p.IsEquip);

        for(int i = 0; i < _skins.Count; i++)
        {
            AddSkin(_skins[i]);
        }
    }

    private void AddSkin(Skin skin)
    {
        SkinView view = Instantiate(_tamplate, _skinContainer.transform);
        view.EquipButtonClick += OnEquipButtonClick;
        view.Render(skin);
        view.ChangeButtonText();
        _views.Add(view);
    }

    private void RemoveSkin()
    {
        foreach(var view in _views) 
            view.EquipButtonClick -= OnEquipButtonClick;
    }

    private void OnEquipButtonClick(Skin skin, SkinView skinView)
    {
        if(skin.IsEquip)
        {
            Debug.Log("Unequip");
            TryUnEquipSkin(skin, skinView);                      
        }
        else
        {
            Debug.Log("Equip");
            TryEquipSkin(skin, skinView); 
        }
    }

    private void TryEquipSkin(Skin skin, SkinView skinView)
    {
        _currentSkin.UnEquip();
        _views[_currentSkin.Index].ChangeButtonText();        
        skin.Equip();
        skinView.ChangeButtonText();

        _currentSkin = skin;
    }

    private void TryUnEquipSkin(Skin skin, SkinView skinView)
    {
        skin.UnEquip();
        skinView.ChangeButtonText();
        _currentSkin = _skins[0];
        _currentSkin.Equip();
        _views[_currentSkin.Index].ChangeButtonText();
    }

}
