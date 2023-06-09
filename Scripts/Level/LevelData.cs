using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "New Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject[] enemys;
    public GameObject Background => background;
    public GameObject[] Enemys => enemys;
}

