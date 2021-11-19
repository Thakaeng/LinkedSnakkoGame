using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject snakeHead;
    [SerializeField] private GameObject snakePart;
    [SerializeField] private int startingParts = 2;
    [SerializeField] private int score = 0;
    internal SnekkoList snakeList = new SnekkoList();

    [HideInInspector] public bool isAlive = true;
    
    public int Score
    {
        get => score;
        set => score = value;
    }
    private void Start()
    {
        snakeList.InsertLast(snakeList, snakeHead.transform);
        for(int i = 0; i < startingParts; i++)
        {
            AddNewSnakePart();
        }
    }
    public void AddNewSnakePart()
    {
        var newPart = Instantiate(snakePart, transform, true);
        snakeList.InsertLast(snakeList, newPart.transform);
    }

    public void MoveSnakeHead(Vector3 newPos)
    {
        snakeList.head.lastPosition = snakeList.head.snakePart.position;
        snakeList.head.snakePart.position = newPos;
        
        MoveSnakeBody(snakeList.head.next);
    }
    
    internal void MoveSnakeBody(Node node)
    {
        node.lastPosition = node.snakePart.position;
        node.snakePart.position = node.prev.lastPosition;
        
        if(node.next != null) MoveSnakeBody(node.next);
    }
}
