using UnityEngine;

public class DamagePickable : PickableItem
{
    protected override bool OnCollected(GameObject player)
    {
        PlayerAttack.DamageMultiplier += data.damageBonus;
        return true;
    }
}