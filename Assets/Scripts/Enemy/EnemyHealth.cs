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
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Vida enemy: " + currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hit");
            audioSource.PlayOneShot(damageSound);
        }
        else
        {
            col.enabled = false;

            anim.SetTrigger("Hit");
            audioSource.PlayOneShot(deathSound);
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject, deathSound.length);
        }
    }
}