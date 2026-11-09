using UnityEngine;
public enum PickableType
{
    Reward,
    Heal,
    Invulnerability,
    Damage
}

[CreateAssetMenu(fileName = "NewPickableData", menuName = "Scriptable Objects/Pickable Data")]
public class PickableDataSO : ScriptableObject
{
    [Header("General")]
    public PickableType type = PickableType.Reward;

    [Header("Values")]
    public int coinAmount = 1;
    public float healAmount = 30f;
    public float invulnerabilityTime = 5f;
    public float damageBonus = 0.5f;      
}