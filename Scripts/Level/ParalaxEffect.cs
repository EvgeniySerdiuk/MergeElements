using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool enableParallax = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EnemyMove.OnMoving += OnMoving;
    }

    private void LateUpdate()
    {
        PlayAndPause(enableParallax);
    }

    private void PlayAndPause(bool enableParallax)
    {
        if (enableParallax) 
        {
            transform.position = new Vector2(transform.position.x - Time.deltaTime * speed, transform.position.y);
            spriteRenderer.size = new Vector2(spriteRenderer.size.x + Time.deltaTime * speed, spriteRenderer.size.y);
        }
    }

    private void OnMoving(bool move)
    {
        enableParallax = move;
    }
}
