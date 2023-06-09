using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Класс отвечающий за перемещение предметов.
/// </summary>
public class DraggableItem: MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Item Info")]
    [HideInInspector] public Transform parentAfterDrag;
    [SerializeField] private ItemType itemType;
    public ItemType ItemType => itemType;
    private Image image;

    private void Awake()
    {
       image = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
