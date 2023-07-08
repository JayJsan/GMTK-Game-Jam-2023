using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegments : MonoBehaviour
{
    private List<Transform> m_segments = new List<Transform>();
    public GameObject snakeSegment;
    private SnakeMovement m_snakeMovement;
    private void Start() {
        m_snakeMovement = GetComponent<SnakeMovement>();
        m_segments.Add(this.transform);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GenerateNewSegment();
        }
    }

    private void FixedUpdate() {

    }

    public void GenerateNewSegment() {
        //https://youtu.be/U8gUnpeaMbQ?t=2079
        Transform segment = Instantiate(snakeSegment).transform;
        segment.position = m_segments[m_segments.Count - 1].position;
        m_segments.Add(segment);
    }

    public void MoveSegment() {
            for (int i = m_segments.Count - 1; i > 0; i--) {
            m_segments[i].position = m_segments[i - 1].position;
        }    
    }
}
