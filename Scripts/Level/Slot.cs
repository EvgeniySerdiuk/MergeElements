using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ����� ���������� �� ����� �� ������� �������. 
/// </summary>
public class Slot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ItemSpawn itemSpawn;

    //������ ������ �� ��������������� ������ � �� ������ � �����.
    private DraggableItem draggableItem;
    private DraggableItem itemInSlot;

    public static Action<Slot, GameObject> CreatItem;

    private void Awake()
    {
        //��������� ���� �� �������� �������, ���� ���. ��������� ���� ��� ��������� � Spawn
        if (transform.childCount == 0)
        {
            itemSpawn.AddFreeSlot(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        draggableItem = dropped.GetComponent<DraggableItem>();
        itemSpawn.AddFreeSlot(draggableItem.parentAfterDrag.GetComponent<Slot>());

        if (transform.childCount == 0)
        {
            draggableItem.parentAfterDrag = transform;
            itemSpawn.RemoveSlot(this);
        }
        else
        {
            itemInSlot = GetComponentInChildren<DraggableItem>();

            if (draggableItem.ItemType == itemInSlot.ItemType)
            {
                CreatItem.Invoke(this, draggableItem.gameObject.GetComponent<Item>().MergedItem);
                itemInSlot.DestroyItem();
                draggableItem.DestroyItem();
            }
        }
    }
}
