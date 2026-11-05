using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private HUDController hudController;

    [Header("Coin Settings")]
    [SerializeField] private int maxCoins = 9;

    private string levelCoinsKey;
    private int currentCoins;

    private void Awake()
    {
        levelCoinsKey = $"Coins_{SceneManager.GetActiveScene().name}";
    }

    private void Start()
    {
        currentCoins = Mathf.Clamp(PlayerPrefs.GetInt(levelCoinsKey, 0), 0, maxCoins);
        UpdateCoinsUI();
    }

    public void AddCoins(int amount)
    {
        if (currentCoins >= maxCoins) return;

        currentCoins = Mathf.Clamp(currentCoins + amount, 0, maxCoins);

        PlayerPrefs.SetInt(levelCoinsKey, currentCoins);
        PlayerPrefs.Save();

        UpdateCoinsUI();

        if (currentCoins >= maxCoins)
        {
            OnCoinsGoalReached();
        }
    }

    private void UpdateCoinsUI()
    { 
        hudController.UpdateCoinsDisplay(currentCoins, maxCoins);
    }

    private void OnCoinsGoalReached()
    {
        Debug.Log($"Total de monedas recolectadas");
    }
}
