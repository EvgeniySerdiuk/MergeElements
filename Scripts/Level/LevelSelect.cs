using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private LevelData level;
    [SerializeField] private Transform character;

    private void OnMouseDown()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(character.DOMove(transform.position, 3));
        sequence.OnComplete(() => { LoadLevel(); });
    }

    private void LoadLevel()
    {
        Selectedlevel.selectedLevel = level;
        SceneManager.LoadScene(2);
    }
}
