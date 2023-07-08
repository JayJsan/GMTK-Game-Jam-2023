using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Snake has eaten fruit -- Destroy -- instantiate new fruit?
        SnakeSegments snakeSegments;
        if (other.GetComponent<SnakeSegments>() == null) {
            Debug.Log("Component not found!");
            return;
        }
        snakeSegments = other.GetComponent<SnakeSegments>();
        snakeSegments.GenerateNewSegment();
        this.gameObject.SetActive(false);
    }
}
