using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// ����� ���������� �� �������� ����� ��������� �� ������� ����..
/// </summary>
public class ItemSpawn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List <Slot> freeSlots; // ��� �� ������ ���-�� ��������� ������ �� ������� ����.
    [SerializeField] private GameObject[] spawnGameObject; // ��� �� ������ ������� ������� ����� �����������.
    [SerializeField] private float timeToSpawn;
    [SerializeField] private Image timeBar;

    private bool Onspawn = false;
    private float randomNumber;
    private float currentTime;

    private void Awake()
    {
        currentTime = 0;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        timeBar.fillAmount = currentTime / timeToSpawn;
        if (currentTime > timeToSpawn) 
        {
            Onspawn = true;
        }
    }

    private void CreateItem()
    {
        if (Onspawn)
        {
            int kolvo = NumberOfItem();

            if (freeSlots.Count - kolvo >= 0)
            {
                for (int i = 0; i < kolvo; i++)
                {
                    int randomItem = Random.Range(0, spawnGameObject.Length);
                    int randomSlot = Random.Range(0, freeSlots.Count);
                    Instantiate(spawnGameObject[randomItem], freeSlots[randomSlot].transform);
                    RemoveSlot(freeSlots[randomSlot]);
                }
            }
            else if (freeSlots.Count > 0)
            {
                for (int i = 0; i < freeSlots.Count; i++)
                {
                    int randomItem = Random.Range(0, spawnGameObject.Length);
                    int randomSlot = Random.Range(0, freeSlots.Count);
                    Instantiate(spawnGameObject[randomItem], freeSlots[randomSlot].transform);
                    RemoveSlot(freeSlots[randomSlot]);
                }
            }
            else
            {
                Debug.Log("��� ���������� �����");
            }
            currentTime = 0;
            Onspawn = false;
        }
    }

    /// <summary>
    /// ����� ������� ���������� � ����� ����������� ���-�� ��������� �� 2 �� 4
    /// </summary>
    private int NumberOfItem()
    {
        randomNumber = Random.value;

        if (randomNumber < 0.60f)
        {
            return 2;
        }
        else if (randomNumber < 0.90f)
        {
            return 3;
        }
        else
        {
            return 4;
        }
    }

    /// <summary>
    /// ����� ��� ���������� ���������� �����
    /// </summary>
    public void AddFreeSlot(Slot slot)
    {
        freeSlots.Add(slot);        
    }

    /// <summary>
    /// ����� ��� �������� ���������� �����.
    /// </summary>
    public void RemoveSlot(Slot slot) 
    {
        freeSlots.Remove(slot);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CreateItem();
    }
}
