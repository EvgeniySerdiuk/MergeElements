using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


/// <summary>
/// Класс отвечающий за загрузку объектов на сцену.
/// </summary>
public class LevelManager : MonoBehaviour
{
    [SerializeField] private EnemySpawn enemySpawn;
    [SerializeField] private GameObject[] items;

    [SerializeField] private GameObject[] currentSlots;
    [SerializeField] private List<string> loadSlots;
    [SerializeField] private List<ItemType> loadItemInSlot;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;

    public static Action characterRound;
    public static Action enemyRound;

    private void Awake()
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        LoadLevelData(Selectedlevel.selectedLevel);
    }

    private void OnEnable()
    {
        EnemySpawn.levelCompliete += LevelCompliete;
        CharacterHealth.gameOver += LevelGameOver;
    }

    private void OnDisable()
    {
        EnemySpawn.levelCompliete -= LevelCompliete;
        CharacterHealth.gameOver -= LevelGameOver;
    }

    /// <summary>
    /// В этом методе вы 
    /// </summary>
    public void LoadLevelData(LevelData data)
    {
        if(data != null)
        {
          LoadPlayfield();
          characterRound?.Invoke();
          Instantiate(data.Background);
          enemySpawn.FirstSpawn(data.Enemys);
        }
    }

    private void LevelCompliete()
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
    }

    private void LevelGameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }


    /// <summary>
    /// Метод отвечающий за сохранение позиции объектов на игровом поле при смене сцены.
    /// </summary>
    private void LoadPlayfield()
    {
        if (SavePlayingField.itemInSlot != null)
        {
            loadSlots = SavePlayingField.slots;
            loadItemInSlot = SavePlayingField.itemInSlot;

            foreach (GameObject slot in currentSlots) //Перед запуском сцены мы очищаем игровое поле от объектов.
            {
                if (slot.transform.childCount != 0)
                {
                    Destroy(slot.transform.GetChild(0).gameObject);
                }
            }

            for (int i = 0; i < loadSlots.Count; i++) // в этой строчке мы начинаем заполнение игрового поля объектами из прошлой сцены.
            {
                for (int j = 0; j < currentSlots.Length; j++)
                {
                    if (loadSlots[i] == currentSlots[j].name)
                    {
                        foreach (GameObject item in items) 
                        {
                            if (item.GetComponent<Item>().ItemType == loadItemInSlot[i])
                            {
                                Instantiate(item, currentSlots[j].transform);
                                break;
                            }
                        }
                        break;              
                    }
                }
            }

        }
    }

}
