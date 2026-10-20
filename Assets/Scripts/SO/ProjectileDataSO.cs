using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileDataSO", menuName = "Scriptable Objects/ProjectileDataSO")]
public class ProjectileDataSO : ScriptableObject
{
    [Header("Projectile Settings")]
    public float speed = 10f;
    public float lifeTime = 3f;
    public float damage = 25f;
}
