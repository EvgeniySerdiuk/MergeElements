using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс отвечающий за создание новых объектов после слияния.
/// </summary>
public class CreatMergeItem : MonoBehaviour
{
    private void OnEnable()
    {
        Slot.CreatItem += CreatingMergeItem;
    }

    private void OnDisable()
    {
        Slot.CreatItem -= CreatingMergeItem;
    }

    public void CreatingMergeItem(Slot slot, GameObject mergedItem)
    {
        Instantiate(mergedItem, slot.transform);
    }
}
