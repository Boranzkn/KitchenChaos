using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;

        Show(false);
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Show(false);
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show(true);
    }

    private void Show(bool isShown)
    {
        gameObject.SetActive(isShown);
    }
}
