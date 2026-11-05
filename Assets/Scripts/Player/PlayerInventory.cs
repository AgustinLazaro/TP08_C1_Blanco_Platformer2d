using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private HUDController hudController;

    private const string CoinsPrefKey = "TotalCoins";
    private int currentCoins;

    private void Start()
    {
        currentCoins = PlayerPrefs.GetInt(CoinsPrefKey, 0);
        hudController.UpdateCoinsDisplay(currentCoins);
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;

        PlayerPrefs.SetInt(CoinsPrefKey, currentCoins);
        PlayerPrefs.Save();
        hudController.UpdateCoinsDisplay(currentCoins);
    }
}
