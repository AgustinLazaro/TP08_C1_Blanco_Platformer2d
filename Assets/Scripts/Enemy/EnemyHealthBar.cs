using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void SetFill(float normalized)
    {
        fillImage.fillAmount = Mathf.Clamp01(normalized);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
