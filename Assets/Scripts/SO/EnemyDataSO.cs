using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "Scriptable Objects/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    [Header("Health Settings")]
    public float maxHealth = 50f;

    [Header("Attack Settings")]
    public float contactDamage = 10f;
}
