using System;
using System.Collections;
using TMPro;
using UnityEngine;


/// <summary>
/// Класс врага.
/// </summary>
public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] private TextMeshPro healthBar;
    private int currentHP;
    public static Action EnemyDeath; //Событие сметри врага, подписчик класс SpawnEnemy.
    private SpriteRenderer sprite;
    private Color currentColor;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        currentColor = sprite.color;
        currentHP = maxHP;
        healthBar.text = $"Hp {currentHP}/{maxHP}";
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        healthBar.text = $"Hp {currentHP}/{maxHP}";
        StartCoroutine(Hit());

        if (currentHP <= 0) 
        {
            EnemyDeath?.Invoke();
            LevelManager.characterRound?.Invoke();
            Destroy(gameObject);
        }
    }

    IEnumerator Hit()
    {
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sprite.color = currentColor;
    }
}
