using UnityEngine;

public class SnakeMouth : MonoBehaviour
{
    [SerializeField] private Game game;
    [SerializeField] private PickupsManager pm;
    private Snake snake;

    private void Awake()
    {
        snake = GetComponentInParent<Snake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Pickup")) pm.PickupCollected(other.gameObject);
        if(other.gameObject.CompareTag("SnakeBody"))
        {
            snake.isAlive = false;
            game.GameOver();
        }
    }
}