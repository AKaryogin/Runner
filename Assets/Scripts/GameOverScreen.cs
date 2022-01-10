using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;
    [SerializeField] private Button _again;
    [SerializeField] private Button _mainMenu;    
    [SerializeField] private Player _player;
    [SerializeField] private CoinCounter _coinCounter;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.Died += OnDied;
        _again.onClick.AddListener(OnAgainButtonClick);
        _mainMenu.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _again.onClick.RemoveListener(OnAgainButtonClick);
        _mainMenu.onClick.RemoveListener(OnMainMenuButtonClick);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnDied()
    {        
        _coins.text = "COINS : " + _coinCounter.Count;
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0;
    }

    private void OnAgainButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
