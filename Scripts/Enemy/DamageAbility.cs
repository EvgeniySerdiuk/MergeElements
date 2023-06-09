using UnityEngine;

public class DamageAbility : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private int damage;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterHealth component))
        {
            spriteRenderer.enabled = false;
            hitEffect.SetActive(true);
            component.TakeDamage(damage);
        }
    }
}
