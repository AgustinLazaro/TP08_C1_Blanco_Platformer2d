using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickableItem : MonoBehaviour
{
    [SerializeField] private PickableDataSO data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<PlayerMovement>(out PlayerMovement player)) return;

        Debug.Log($"Collected: {data.name}");

        Destroy(gameObject);
    }
}