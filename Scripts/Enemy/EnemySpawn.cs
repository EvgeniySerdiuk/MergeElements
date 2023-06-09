using System;
using UnityEngine;


/// <summary>
/// Класс отвечающий за создание врагов.
/// </summary>
public class EnemySpawn : MonoBehaviour
{
    private int numberSpawnEnemy = 0;
    private GameObject[] enemys;
    public static Action levelCompliete; // Событие которое вызывается если враги на уровне кончились.

    private void OnEnable()
    {
        Enemy.EnemyDeath += Spawn;
    }

    private void OnDisable()
    {
        Enemy.EnemyDeath -= Spawn;
    }

    public void FirstSpawn(GameObject[] enemys)
    {
        this.enemys = enemys;
        Spawn();
    }

    public void Spawn()
    {
        if (numberSpawnEnemy < enemys.Length) 
        {
            Instantiate(enemys[numberSpawnEnemy]);
            numberSpawnEnemy++;
        }
        else
        {
            levelCompliete?.Invoke();
        }
    }
}
