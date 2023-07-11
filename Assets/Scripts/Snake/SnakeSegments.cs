using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegments : MonoBehaviour
{
    private List<Segment> m_segments = new List<Segment>();
    public GameObject snakeSegment;
    private SnakeMovement m_snakeMovement;
    private bool m_initialSpawn = true; // LOL I NEED TO FIX THIS LATER
    private void Start() {
        m_snakeMovement = GetComponent<SnakeMovement>();
        m_segments.Add(GetComponent<Segment>());
        m_initialSpawn = true;
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
        Segment segment = Instantiate(snakeSegment).GetComponent<Segment>();
        segment.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.1803922f, 0.1764706f,0.2470588f, 1f);
        if (m_initialSpawn) {
            m_initialSpawn = false;
            segment.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,1f);
            segment.MoveSegment(GetComponent<SnakeMovement>().GetLastPosition());
            m_segments.Add(segment);
            return;
        }
        segment.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        segment.MoveSegment(m_segments[m_segments.Count - 1].GetLastSegmentPosition());
        m_segments.Add(segment);
    }

    public void MoveSegment() {
        for (int i = m_segments.Count - 1; i > 0; i--) {
            m_segments[i].MoveSegment(m_segments[i-1].GetCurrentSegmentPosition());
            //m_segments[i].position = m_segments[i - 1].position;
        }    
    }
}
