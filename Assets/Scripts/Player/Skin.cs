using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Skin : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private string _label;
    [SerializeField] private Sprite _icon;    
    [SerializeField] private bool _isEquip = false;    

    public int Index => _index;
    public string Label => _label;
    public Sprite Icon => _icon;
    public bool IsEquip => _isEquip;

    public void Equip()
    {        
        _isEquip = true;
    }

    public void UnEquip()
    {        
        _isEquip = false;
    }
}
