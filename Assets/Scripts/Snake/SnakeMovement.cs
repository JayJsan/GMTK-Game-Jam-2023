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
    private Vector2 m_currentSnakeDirection;
    private Vector2 m_currentSnakePosition;
    private Vector2 m_lastSnakePosition;
    private Vector2 m_currentInput;
    private SnakeSegments m_snakeSegments;
    [SerializeField]
    private float m_timer;
    private bool m_isOnCooldown = false;
    private bool m_snakeCanMove = true;

    private void Start() {
        m_snakeSegments = GetComponent<SnakeSegments>();
        m_lastSnakePosition = transform.position;
        m_currentSnakePosition = transform.position;
    }
    private void Update() {
        CheckInput();
    }
    private void FixedUpdate() {
        // every x seconds move snake in current m_currentSnakeDirection.
        if (!m_isOnCooldown && m_snakeCanMove) {
            StartCoroutine(Cooldown());
        }
    }

    public void SendDirection(Direction dir) {
        if((dir == Direction.Up) && m_currentSnakeDirection != Vector2.down)
        {
            m_currentSnakeDirection = Vector2.up;
        }
        else if((dir == Direction.Down) && m_currentSnakeDirection != Vector2.up)
        {
            m_currentSnakeDirection = Vector2.down;
        }
        else if((dir == Direction.Left) && m_currentSnakeDirection != Vector2.right)
        {
            m_currentSnakeDirection = Vector2.left;
        }
        else if((dir == Direction.Right) && m_currentSnakeDirection != Vector2.left)
        {
            m_currentSnakeDirection = Vector2.right;
        }
    }

    private void CheckInput() {
        if(Input.GetKeyDown(KeyCode.W) && m_currentSnakeDirection != Vector2.down)
        {
            m_currentInput = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.S) && m_currentSnakeDirection != Vector2.up)
        {
            m_currentInput = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.A) && m_currentSnakeDirection != Vector2.right)
        {
            m_currentInput = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.D) && m_currentSnakeDirection != Vector2.left)
        {
            m_currentInput = Vector2.right;
        }
    }
    
    private void MoveSnake() {
        m_lastSnakePosition = transform.position;
        transform.position = transform.position + (Vector3)m_currentSnakeDirection;
        m_currentSnakePosition = transform.position;
        GetComponent<Segment>().UpdatePosition(m_currentSnakePosition,m_lastSnakePosition);
    }

    public Vector2 GetCurrentSnakeDirection() {
        return m_currentSnakeDirection;
    }

    public Vector3 GetCurrentPosition() {
        return m_currentSnakePosition;
    }

    public Vector3 GetLastPosition() {
        return m_lastSnakePosition;
    }

    private IEnumerator Cooldown() {
        m_currentSnakeDirection = m_currentInput;
        MoveSnake();
        UpdateSpriteDirection();
        m_snakeSegments.MoveSegment();
        m_isOnCooldown = true;
        yield return new WaitForSeconds(m_timer);
        m_isOnCooldown = false;
    }

    public bool CanSnakeCurrentlyMove() {
        return !m_isOnCooldown;
    }

    public void ToggleSnakeMovement() {
        m_snakeCanMove = !m_snakeCanMove;
    }

    public void ToggleSnakeMovement(bool canMove) {
        m_snakeCanMove = canMove;
    }

    public void UpdateSpriteDirection() {
        float rotation = 0f;
        float scale = 1f;

        if (m_currentSnakeDirection == Vector2.left) {
            scale = -1f;
        }

        if (m_currentSnakeDirection == Vector2.up) {
            rotation = 90f;
        }

        if (m_currentSnakeDirection == Vector2.down) {
            rotation = -90f;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotation);
        transform.localScale = new Vector3(scale,1f,1f);
    }
}
