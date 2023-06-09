using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]

/// <summary>
/// ����� ��� �������� ������, ��� ���������.
/// </summary>
public class AbilityData : ScriptableObject
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject abilitySprite;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    public void Attack()
    {
        
        GameObject clone =  Instantiate(abilitySprite,startPoint.position,Quaternion.identity);
        clone.GetComponent<TriggerDetected>().ChangeDamage(damage); //����������� �������� �����.
        Sequence sequence = DOTween.Sequence();
        sequence.Append(clone.transform.DOMove(endPoint.position, 5));
        sequence.OnComplete(() => { Destroy(clone); });
    }
}
