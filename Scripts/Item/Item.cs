using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemType;
    [SerializeField] private GameObject mergedItem;
    [SerializeField] private AbilityData abilityData;
    public AbilityData Ability => abilityData;
    public ItemType ItemType => itemType;
    public GameObject MergedItem => mergedItem;
}
