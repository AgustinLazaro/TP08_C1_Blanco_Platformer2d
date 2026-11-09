using UnityEngine;

// Poner en el prefab Enemy. Asignar el mismo EnemyDataSO que usa EnemyHealth.
public class EnemyContactDamage : MonoBehaviour
{
    [SerializeField] private EnemyDataSO data;

    private void OnCollisionStay2D(Collision2D collision)
    {
        TryDamage(collision.collider);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TryDamage(other);
    }

    private void TryDamage(Collider2D other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth player))
            player.TakeDamage(data.contactDamage);
    }
}
