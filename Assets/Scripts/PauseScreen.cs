using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _again;
    [SerializeField] private Button _mainMenu;
    [SerializeField] private PauseButton _pauseButton;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _pauseButton.Clicked += OnShowed;
        _play.onClick.AddListener(OnPlayButtonClick);
        _again.onClick.AddListener(OnAgainButtonClick);
        _mainMenu.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void OnDisable()
    {
        _pauseButton.Clicked -= OnShowed;
        _play.onClick.RemoveListener(OnPlayButtonClick);
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

    private void OnShowed()
    {        
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        Time.timeScale = 0;
    }

    private void OnPlayButtonClick()
    {
        Time.timeScale = 1;
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnAgainButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    private void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
