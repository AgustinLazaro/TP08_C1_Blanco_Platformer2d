using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayMenuUI : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _gameplayConfigPanel;
    [SerializeField] private GameObject _audioPanel;

    [Header("Main Pause Buttons")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _backToMenuButton;

    [Header("Options Category Buttons")]
    [SerializeField] private Button _openGameplayConfigButton;
    [SerializeField] private Button _openAudioPanelButton;
    [SerializeField] private Button _backOptionsButton;

    [Header("Subpanel Back Buttons")]
    [SerializeField] private Button _backFromGameplayButton;
    [SerializeField] private Button _backFromAudioButton;

    private void Start()
    {
        Time.timeScale = 1f;


        _continueButton.onClick.AddListener(TogglePause);
        _optionsButton.onClick.AddListener(ShowOptions);
        _backToMenuButton.onClick.AddListener(ReturnToMainMenu);


        _backOptionsButton.onClick.AddListener(HideOptions);
        _openGameplayConfigButton.onClick.AddListener(ShowGameplayConfig);
        _openAudioPanelButton.onClick.AddListener(ShowAudioPanel);


        _backFromGameplayButton.onClick.AddListener(BackToOptionsFromGameplay);
        _backFromAudioButton.onClick.AddListener(BackToOptionsFromAudio);
    }

    private void OnDestroy()
    {
        _continueButton.onClick.RemoveListener(TogglePause);
        _optionsButton.onClick.RemoveListener(ShowOptions);
        _backToMenuButton.onClick.RemoveListener(ReturnToMainMenu);

        _backOptionsButton.onClick.RemoveListener(HideOptions);
        _openGameplayConfigButton.onClick.RemoveListener(ShowGameplayConfig);
        _openAudioPanelButton.onClick.RemoveListener(ShowAudioPanel);

        _backFromGameplayButton.onClick.RemoveListener(BackToOptionsFromGameplay);
        _backFromAudioButton.onClick.RemoveListener(BackToOptionsFromAudio);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameplayConfigPanel.activeSelf)
            {
                BackToOptionsFromGameplay();
            }
            else if (_audioPanel.activeSelf)
            {
                BackToOptionsFromAudio();
            }
            else if (_optionsPanel.activeSelf)
            {
                HideOptions();
            }
            else
            {
                TogglePause();
            }
        }
    }

    public void TogglePause()
    {
        _pauseMenuPanel.SetActive(!_pauseMenuPanel.activeSelf);

        if (_pauseMenuPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void ShowOptions()
    {
        _optionsPanel.SetActive(true);
    }

    private void HideOptions()
    {
        _optionsPanel.SetActive(false);
    }

    private void ShowGameplayConfig()
    {
        _optionsPanel.SetActive(false);
        _gameplayConfigPanel.SetActive(true);
    }

    private void BackToOptionsFromGameplay()
    {
        _gameplayConfigPanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }

    private void ShowAudioPanel()
    {
        _optionsPanel.SetActive(false);
        _audioPanel.SetActive(true);
    }

    private void BackToOptionsFromAudio()
    {
        _audioPanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }

    private void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}