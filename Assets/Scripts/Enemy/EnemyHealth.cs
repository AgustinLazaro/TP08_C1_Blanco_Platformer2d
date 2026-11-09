using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region Variables
    [Header("Components")]
    private Animator anim;
    private Collider2D col;

    [Header("Data Configuration")]
    [SerializeField] private EnemyDataSO data;

    [Header("Effects")]
    [SerializeField] private GameObject deathEffectPrefab;

    [Header("UI")]
    [SerializeField] private EnemyHealthBar healthBar;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip deathSound;

    [Header("Health Settings")]
    [SerializeField] private float currentHealth;
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        currentHealth = data.maxHealth;
        if (healthBar != null) healthBar.SetFill(1f);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (healthBar != null) healthBar.SetFill(currentHealth / data.maxHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hit");
            audioSource.PlayOneShot(damageSound);
        }
        else
        {
            col.enabled = false;
            if (healthBar != null) healthBar.Hide();

            anim.SetTrigger("Hit");
            audioSource.PlayOneShot(deathSound);
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject, deathSound.length);
        }
    }
}