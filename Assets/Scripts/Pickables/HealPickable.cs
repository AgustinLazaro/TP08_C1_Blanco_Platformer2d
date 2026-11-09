using UnityEngine;

public class HealPickable : PickableItem
{
    protected override bool OnCollected(GameObject player)
    {
        if (!player.TryGetComponent<PlayerHealth>(out PlayerHealth health)) return false;

        health.Heal(data.healAmount);
        return true;
    }
}
