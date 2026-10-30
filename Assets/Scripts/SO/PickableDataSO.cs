using UnityEngine;

public enum PickableType
{
    Reward,
    Heal,
    Invulnerability
}

[CreateAssetMenu(fileName = "NewPickableData", menuName = "Scriptable Objects/Pickable Data")]
public class PickableDataSO : ScriptableObject
{
    [Header("General")]
    public PickableType type = PickableType.Reward;
}