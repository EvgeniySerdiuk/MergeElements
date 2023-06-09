using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadsceneButton : MonoBehaviour
{
    public  GameObject[] currentSlots;

    public  List<string> slots;
    public  List<ItemType> itemInSlot;


    public void Save()
    {
        for (int i = 0;i<currentSlots.Length;i++)
        {
            if (currentSlots[i].transform.childCount != 0)
            {
                slots.Add(currentSlots[i].name);
                itemInSlot.Add(currentSlots[i].transform.GetChild(0).GetComponent<Item>().ItemType);
            }
        }

        SavePlayingField.slots = slots;
        SavePlayingField.itemInSlot = itemInSlot;       
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
