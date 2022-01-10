using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    private Button _pause;

    public event UnityAction Clicked;

    private void OnEnable()
    {        
        _pause = GetComponent<Button>();
        _pause.onClick.AddListener(Click);
    }

    private void OnDisable()
    {
        _pause.onClick.RemoveListener(Click);
    }

    private void Click()
    {        
        Clicked?.Invoke();
    }
}
