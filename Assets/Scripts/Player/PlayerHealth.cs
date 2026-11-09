using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerHealth : MonoBehaviour
{
    #region Variables
    [Header("Components")]
    private HUDController hud;
    private Animator anim;

    [Header("Data Configuration")]
    [SerializeField] private PlayerDataSO data;

    [Header("Health Settings")]
    [SerializeField] private float currentHealth;
    [SerializeField] private float hitInvulnerability = 0.6f;
    [SerializeField] private float restartDelay = 2f;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip healSound;

    private float hitInvulnerableUntil;
    private bool isDead;

    public bool IsInvulnerable => Time.time < hitInvulnerableUntil;
    #endregion

    #region Unity Lifecycle
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = data.maxHealth;
        hud = FindFirstObjectByType<HUDController>();
        if (hud != null) hud.UpdateHealthBar(currentHealth, data.maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) TakeDamage(20f);
    }
    #endregion

    #region Public Methods
    public void TakeDamage(float damageAmount)
    {
        if (isDead || IsInvulnerable) return;

        currentHealth -= damageAmount;
        hitInvulnerableUntil = Time.time + hitInvulnerability;

        if (hud != null) hud.UpdateHealthBar(currentHealth, data.maxHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            anim.SetTrigger("Hit");
            if (audioSource && damageSound) audioSource.PlayOneShot(damageSound);
        }
    }

    public void Heal(float amount)
    {
        if (isDead) return;

        currentHealth = Mathf.Min(currentHealth + amount, data.maxHealth);
        if (hud != null) hud.UpdateHealthBar(currentHealth, data.maxHealth);
        if (healSound != null && audioSource != null) audioSource.PlayOneShot(healSound);
    }
    #endregion

    #region Private Methods
    private void Die()
    {
        isDead = true;

        if (audioSource && gameOverSound) audioSource.PlayOneShot(gameOverSound);
        anim.SetTrigger("Die");

        GetComponent<PlayerMovement>().enabled = false;
        if (TryGetComponent<PlayerAttack>(out PlayerAttack attack)) attack.enabled = false;

        Invoke(nameof(RestartLevel), restartDelay);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion
}