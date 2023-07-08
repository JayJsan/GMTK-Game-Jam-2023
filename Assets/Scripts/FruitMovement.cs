using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMovement : MonoBehaviour
{
    private Vector2 m_currentDirection;
    [SerializeField]
    private float m_timer;
    private bool m_isOnCooldown = false;

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
        if(Input.GetKeyDown(KeyCode.UpArrow) && m_currentDirection != Vector2.down)
        {
            m_currentDirection = Vector2.up;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && m_currentDirection != Vector2.up)
        {
            m_currentDirection = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && m_currentDirection != Vector2.right)
        {
            m_currentDirection = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && m_currentDirection != Vector2.left)
        {
            m_currentDirection = Vector2.right;
        }
    }
    
    private void MoveFruit() {
        transform.position = transform.position + (Vector3)m_currentDirection;
    }

    public Vector2 GetCurrentm_currentDirection() {
        return m_currentDirection;
    }

    public Vector3 GetCurrentPosition() {
        return transform.position;
    }

    IEnumerator Cooldown() {
        MoveFruit();
        m_isOnCooldown = true;
        yield return new WaitForSeconds(m_timer);
        m_isOnCooldown = false;
    }
}
