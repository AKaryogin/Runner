using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _lifes;
    [SerializeField] private int _health;    
    [SerializeField] private List<Skin> _skins;

    public event UnityAction Died;

    private void Start()
    {
        _lifes.text = "x " + _health;
        Initialize();
    }

    private void Initialize()
    {
        Skin skin = _skins.FirstOrDefault(p => p.IsEquip);
        Instantiate(skin, transform);
        Time.timeScale = 1;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        _lifes.text = "x " + _health;

        if(_health <= 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();        
    }
}
