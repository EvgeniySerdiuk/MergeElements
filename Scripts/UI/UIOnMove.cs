using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIOnMove : MonoBehaviour
{
    [SerializeField] private float timeRound;
    [SerializeField] private Image timeBar;

    private TextMeshProUGUI text;
    private float currentTime;
    private bool characterRound;


    private void Awake()
    {
        currentTime = timeRound;
        text = GetComponent<TextMeshProUGUI>();
        CharacterRound();
    }

    private void Update()
    {
        if (characterRound) 
        {
            currentTime-= Time.deltaTime;
            timeBar.fillAmount = currentTime / timeRound;

            if (currentTime <= 0)
            {
                LevelManager.enemyRound?.Invoke();
            }
        }
        
    }

    private void OnEnable()
    {
        LevelManager.characterRound += CharacterRound;
        LevelManager.enemyRound += EnemyRound;
    }

    private void OnDisable()
    {
        LevelManager.characterRound -= CharacterRound;
        LevelManager.enemyRound -= EnemyRound;
    }

    private void CharacterRound()
    {
       characterRound= true;
       timeBar.gameObject.SetActive(true);
       text.text = "ход игрока";
       currentTime = timeRound;        
    }

    private void EnemyRound()
    {
        characterRound = false;
        text.text = "ход противника";
        timeBar.gameObject.SetActive(false);
    }
}
