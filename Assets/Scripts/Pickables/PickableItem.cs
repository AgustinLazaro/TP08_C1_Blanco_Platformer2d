using UnityEngine;

// Clase BASE de los pickables (Clase 11: herencia, virtual / override).
// Por defecto se comporta como Reward (moneda). Las hijas cambian OnCollected.
[RequireComponent(typeof(Collider2D))]
public class PickableItem : MonoBehaviour
{
    [SerializeField] protected PickableDataSO data;

    [Header("Float Settings")]
    [SerializeField] private float floatSpeed = 3f;
    [SerializeField] private float floatAmplitude = 0.2f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<PlayerHealth>(out PlayerHealth _)) return;

        if (OnCollected(collision.gameObject))
            Destroy(gameObject);
    }

    // Devuelve true si el item se consumio
    protected virtual bool OnCollected(GameObject player)
    {
        if (player.TryGetComponent<PlayerInventory>(out PlayerInventory inventory))
        {
            inventory.AddCoins(data.coinAmount);
            return true;
        }
        return false;
    }
}