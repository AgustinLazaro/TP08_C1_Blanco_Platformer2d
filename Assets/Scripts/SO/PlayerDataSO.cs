using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Scriptable Objects/PlayerDataSO")]
public class PlayerDataSO : ScriptableObject
{
    [Header("Movement Settings")]
    public float moveSpeed = 9f;
    public float jumpForce = 12f;
    public float crouchSpeed = 0.5f;

    [Header("Health Settings")]
    public float maxHealth = 100f;

    [Header("Attack Settings")]
    public GameObject projectilePrefab;
}
