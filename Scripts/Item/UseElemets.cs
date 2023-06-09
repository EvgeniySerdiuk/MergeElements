using System;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Класс отвечающий за использование предметов.
/// </summary>
public class UseElemets : MonoBehaviour
{
    [SerializeField] private GameObject attackSlot;
    [SerializeField] private Button button;

    private bool characterRound = true;


    private void OnEnable()
    {
        LevelManager.characterRound += CharacterRound;
        LevelManager.enemyRound += EnemyRound;
        button.onClick.AddListener(UseItems);
    }

    private void OnDisable()
    {
        LevelManager.characterRound -= CharacterRound;
        LevelManager.enemyRound -= EnemyRound;
    }

    private void UseItems()
    {
        if (attackSlot.transform.childCount != 0 && characterRound)
        {
            Item item = attackSlot.GetComponentInChildren<Item>();

            if (item != null)
            {
                item.Ability.Attack();
                Destroy(item.gameObject);
                characterRound = false;
            }
        }
    }

    private void CharacterRound()
    {
        characterRound = true;
    }

    private void EnemyRound()
    {
        characterRound = false;
    }
}
