using System;
using TMPro;
using UnityEngine;

/// <summary>
/// ����� ���������� �� �������� ���������.
/// </summary>
public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] private TextMeshPro healthBar;
    private int currentHP;
    public static Action gameOver; //������ ������� ���������� ���� � ��������� �� �������� ��������.

    private void Awake()
    {
        currentHP = maxHP;
        healthBar.text = $"Hp {currentHP}/{maxHP}";
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        healthBar.text = $"Hp {currentHP}/{maxHP}";
        if (currentHP <= 0)
        {
            gameOver?.Invoke();
        }
    }
}
