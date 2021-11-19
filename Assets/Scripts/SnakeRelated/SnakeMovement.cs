using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private Snake snake;
    [SerializeField] private float moveCooldownMilliseconds;
    [SerializeField] private PlayField _playField;

    private float moveCooldown = 1f;
    private Vector2 currPos = MyGrid.grid[4, 4];
    private Vector2 direction = new Vector2(1f, 0f);
    private Direction currDir = Direction.right;
    private bool justMoved = false;

    private void Awake()
    {
        moveCooldownMilliseconds /= 100;
    }

    private void Start()
    {
        transform.position = (Vector3)currPos + Vector3.back;
    }

    private void Update()
    {
        if(justMoved == false)
        {
            if(Input.GetKeyDown(KeyCode.W) && currDir != Direction.down) ChangeDirection(Direction.up);
            if(Input.GetKeyDown(KeyCode.A) && currDir != Direction.right) ChangeDirection(Direction.left);
            if(Input.GetKeyDown(KeyCode.S) && currDir != Direction.up) ChangeDirection(Direction.down);
            if(Input.GetKeyDown(KeyCode.D) && currDir != Direction.left) ChangeDirection(Direction.right);
        }

        if(moveCooldown < Time.time && snake.isAlive == true)
        {
            
            Vector3 newPos = (Vector3)(currPos + direction);
            
            // Screen Wrapping
            if(newPos.x < 0) newPos.x = MyGrid.PlayFieldSize - 1;
            else if(newPos.x >= MyGrid.PlayFieldSize) newPos.x = 0;
            else if(newPos.y < 0) newPos.y = MyGrid.PlayFieldSize - 1;
            else if(newPos.y >= MyGrid.PlayFieldSize) newPos.y = 0;
            
            currPos = MyGrid.grid[(int) newPos.x, (int) newPos.y];
            snake.MoveSnakeHead((Vector3)currPos + Vector3.back);

            justMoved = false;
            
            //transform.position = (Vector3)currPos + Vector3.back;
            

            moveCooldown += moveCooldownMilliseconds;
        }
    }

    private void ChangeDirection(Direction dir)
    {
        justMoved = true;
        currDir = dir;
        switch(dir)
        {
            case Direction.up:
                direction = new Vector2(0f, 1f);
                break;
            case Direction.left:
                direction = new Vector2(-1f, 0f);
                break;
            case Direction.down:
                direction = new Vector2(0f, -1f);
                break;
            case Direction.right:
                direction = new Vector2(1f, 0f);
                break;
        }
    }

    enum Direction
    {
        up, down, left, right
    }
}
