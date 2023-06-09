using System.Collections;
using UnityEngine;
using DG.Tweening;


/// <summary>
/// Класс отвечающий за выпуск снаряда врагом.
/// </summary>
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject enemyAbility;
    [SerializeField] private Transform target;

    private void OnEnable()
    {
        LevelManager.enemyRound += Attack; //Когда начинается раунд врага, вызываем метод Атаки.
    }

    private void OnDisable()
    {
        LevelManager.enemyRound -= Attack;
    }

    private void Attack()
    {
        StartCoroutine(waitAttack());       
    }

    IEnumerator waitAttack() 
    {
        yield return new WaitForSeconds(2);
        GameObject clone = Instantiate(enemyAbility, transform.position, Quaternion.identity);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(clone.transform.DOMove(target.position, 2.3f));
        LevelManager.characterRound?.Invoke();
        sequence.OnComplete(() => { Destroy(clone); });
    }
}
