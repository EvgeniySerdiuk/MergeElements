using UnityEngine;
using DG.Tweening;
using System;

/// <summary>
/// Класс отвечающий за движение врага.
/// </summary>
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform target;
    public static Action<bool> OnMoving; //Собитие которое контролирует эффект Paralax

    private void Awake()
    {
        OnMoving?.Invoke(true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(target.position, 4));
        sequence.OnComplete(() => {OnMoving?.Invoke(false);});
    }
}
