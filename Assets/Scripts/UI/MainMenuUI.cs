using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Config UI Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private GameObject _creditsPanel;
    [SerializeField] private GameObject _gameplayConfigPanel;
    [SerializeField] private GameObject _audioPanel;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _optionsButton;
    [SerializeField] private Button _creditsButton;
    [SerializeField] private Button _exitButton;

    [Header("Options Category Buttons")]
    [SerializeField] private Button _openGameplayConfigButton;
    [SerializeField] private Button _openAudioPanelButton;
    [SerializeField] private Button _backOptionsButton;

    [Header("Subpanel Back Buttons")]
    [SerializeField] private Button _backFromGameplayButton;
    [SerializeField] private Button _backFromAudioButton;
    [SerializeField] private Button _backCreditsButton;

    private void Start()
    {
//#if UNITY_WEBGL
//        if (_exitButton)
//        {
//            _exitButton.gameObject.SetActive(false);
//        }
//#endif

        _playButton.onClick.AddListener(PlayGame);
        _optionsButton.onClick.AddListener(ShowOptions);
        _creditsButton.onClick.AddListener(ShowCredits);
        _exitButton.onClick.AddListener(ExitGame);

        _backOptionsButton.onClick.AddListener(HideOptions);
        _backCreditsButton.onClick.AddListener(HideCredits);
        _openGameplayConfigButton.onClick.AddListener(ShowGameplayConfig);
        _openAudioPanelButton.onClick.AddListener(ShowAudioPanel);

        _backFromGameplayButton.onClick.AddListener(BackToOptionsFromGameplay);
        _backFromAudioButton.onClick.AddListener(BackToOptionsFromAudio);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(PlayGame);
        _optionsButton.onClick.RemoveListener(ShowOptions);
        _creditsButton.onClick.RemoveListener(ShowCredits);
        _exitButton.onClick.RemoveListener(ExitGame);

        _backOptionsButton.onClick.RemoveListener(HideOptions);
        _backCreditsButton.onClick.RemoveListener(HideCredits);
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
            else if (_creditsPanel.activeSelf)
            {
                HideCredits();
            }
        }
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
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

    private void ShowCredits()
    {
        _creditsPanel.SetActive(true);
    }

    private void HideCredits()
    {
        _creditsPanel.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}