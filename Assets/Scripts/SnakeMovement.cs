using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public enum Direction {
        Up,
        Left,
        Right,
        Down,
    }
    private Vector2 m_currentDirection;
    private SnakeSegments m_snakeSegments;
    [SerializeField]
    private float m_timer;
    private bool m_isOnCooldown = false;

    private void Start() {
        m_snakeSegments = GetComponent<SnakeSegments>();
    }
    private void Update() {
        CheckInput();
    }
    private void FixedUpdate() {
        // every x seconds move snake in current m_currentDirection.
        if (!m_isOnCooldown) {
            StartCoroutine(Cooldown());
        }
    }

    public void SendDirection(Direction dir) {
        if((dir == Direction.Up) && m_currentDirection != Vector2.down)
        {
            m_currentDirection = Vector2.up;
        }
        else if((dir == Direction.Down) && m_currentDirection != Vector2.up)
        {
            m_currentDirection = Vector2.down;
        }
        else if((dir == Direction.Left) && m_currentDirection != Vector2.right)
        {
            m_currentDirection = Vector2.left;
        }
        else if((dir == Direction.Right) && m_currentDirection != Vector2.left)
        {
            m_currentDirection = Vector2.right;
        }
    }

    private void CheckInput() {
        if(Input.GetKeyDown(KeyCode.W) && m_currentDirection != Vector2.down)
        {
            m_currentDirection = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.S) && m_currentDirection != Vector2.up)
        {
            m_currentDirection = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.A) && m_currentDirection != Vector2.right)
        {
            m_currentDirection = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.D) && m_currentDirection != Vector2.left)
        {
            m_currentDirection = Vector2.right;
        }
    }
    
    private void MoveSnake() {
        transform.position = transform.position + (Vector3)m_currentDirection;
    }

    public Vector2 GetCurrentm_currentDirection() {
        return m_currentDirection;
    }

    public Vector3 GetCurrentPosition() {
        return transform.position;
    }

    private IEnumerator Cooldown() {
        MoveSnake();
        m_snakeSegments.MoveSegment();
        m_isOnCooldown = true;
        yield return new WaitForSeconds(m_timer);
        m_isOnCooldown = false;
    }

    public bool CanSnakeMove() {
        return !m_isOnCooldown;
    }
}
