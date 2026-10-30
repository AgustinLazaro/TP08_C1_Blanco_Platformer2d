using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickableItem : MonoBehaviour
{
    [SerializeField] private PickableDataSO data;

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
        if (!collision.TryGetComponent<PlayerMovement>(out PlayerMovement player)) return;

        Debug.Log($"Collected: {data.name}");

        Destroy(gameObject);
    }
}