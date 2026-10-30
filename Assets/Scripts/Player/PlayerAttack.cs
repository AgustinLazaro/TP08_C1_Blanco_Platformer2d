using UnityEngine;
using TMPro;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerAttack : MonoBehaviour
{
    #region Variables
    [Header("Components")]
    private Animator anim;
    private PlayerMovement playerMovement;

    [Header("Data Configuration")]
    [SerializeField] private PlayerDataSO data;

    [Header("Attack Settings")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackCooldown = 0.5f;
    private float nextAttackTime = 0f;

    [Header("UI Feedback")]
    [SerializeField] private TextMeshProUGUI meleeCooldownText;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        HandleAttackInput();
        UpdateCooldownUI();
    }
    #endregion

    #region Input & Logic Methods
    private void HandleAttackInput()
    {
        if (Input.GetMouseButtonDown(0) && playerMovement.IsGrounded && Time.time >= nextAttackTime)
        {
            ExecuteAttack();
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void ExecuteAttack()
    {
        if (playerMovement.IsCrouching)
        {
            anim.SetTrigger("isCrouchAttacking");
        }
        else
        {
            anim.SetTrigger("isAttacking");
        }

        GameObject projectile = Instantiate(data.projectilePrefab, firePoint.position, firePoint.rotation);

        if (transform.localScale.x < 0)
        {
            Vector3 projectileScale = projectile.transform.localScale;
            projectileScale.x *= -1;
            projectile.transform.localScale = projectileScale;
        }
    }

    private void UpdateCooldownUI()
    {
        float remainingTime = nextAttackTime - Time.time;

        if (remainingTime > 0f)
        {
            meleeCooldownText.text = remainingTime.ToString("F1") + "s";
        }
        else
        {
            meleeCooldownText.text = "READY";
        }
    }
    #endregion
}