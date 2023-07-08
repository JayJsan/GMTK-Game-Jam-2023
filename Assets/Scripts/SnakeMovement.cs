using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
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

    IEnumerator Cooldown() {
        MoveSnake();
        m_snakeSegments.MoveSegment();
        m_isOnCooldown = true;
        yield return new WaitForSeconds(m_timer);
        m_isOnCooldown = false;
    }
}
