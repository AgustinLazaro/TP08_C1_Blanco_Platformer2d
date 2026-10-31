using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Slider _healthSlider;

    [Header("Coins UI")]
    [SerializeField] private TextMeshProUGUI _coinsText;

    [Header("Attack Cooldown UI")]
    [SerializeField] private TextMeshProUGUI _meleeCooldownText;

    private int _lastDisplayedSpeed = -1;

    private void OnEnable()
    {
        // PlayerHealth.OnHealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        // PlayerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    public void UpdateCoinsDisplay(int totalCoins)
    {
        _coinsText.text = $"Coins: {totalCoins}";
    }

    public void UpdateCooldownDisplay(float remainingTime)
    {
        if (remainingTime > 0f)
        {
            _meleeCooldownText.text = remainingTime.ToString("F1") + "s";
        }
        else
        {
            _meleeCooldownText.text = "READY";
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = currentHealth;
    }
}