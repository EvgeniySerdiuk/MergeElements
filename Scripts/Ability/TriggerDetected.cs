using UnityEngine;

/// <summary>
/// Класс отвечающий за нанесение урона врагу.
/// </summary>
public class TriggerDetected : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    private SpriteRenderer spriteRenderer;
    private int damage;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy component))
        {
            spriteRenderer.enabled = false;
            hitEffect.SetActive(true);
            component.TakeDamage(damage);
        }
    }

    public void ChangeDamage(int damage)
    {
        this.damage = damage;
    }
}
