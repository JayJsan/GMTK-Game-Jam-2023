using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    private Vector2 m_currentSegmentPosition;
    private Vector2 m_lastSegmentPosition;
    void Start()
    {
        m_currentSegmentPosition = transform.position;
        m_lastSegmentPosition = m_currentSegmentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveSegment(Vector3 newPosition) {
        m_lastSegmentPosition = m_currentSegmentPosition;
        transform.position = newPosition;
        m_currentSegmentPosition = newPosition;
    }
    
    public void UpdatePosition(Vector3 newPosition, Vector3 lastPosition) {
        m_lastSegmentPosition = lastPosition;
        m_currentSegmentPosition = newPosition;
    }

    public Vector3 GetLastSegmentPosition() {
        return m_lastSegmentPosition;
    }

    public Vector3 GetCurrentSegmentPosition() {
        return m_currentSegmentPosition;
    }
}
