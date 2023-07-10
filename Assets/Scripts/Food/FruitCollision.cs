using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollision : MonoBehaviour
{
    public bool isDecoy = false;
    public BoxCollider2D spawnArea;
    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Snake has eaten fruit -- Destroy -- instantiate new fruit?
        if (!other.tag.Equals("SnakeHead")) {
            return;
        }

        if (!other.tag.Equals("SnakeSegment")) {
            RandomizePosition();
        }


        SnakeSegments snakeSegments;
        if (other.GetComponent<SnakeSegments>() == null) {
            Debug.Log("Component not found!");
            return;
        }
        
        // Make snake longer on collison
        if (!isDecoy) {
        snakeSegments = other.GetComponent<SnakeSegments>();
        snakeSegments.GenerateNewSegment();
        }

        RandomizePosition();
        // this.gameObject.SetActive(false);
    }

    void RandomizePosition() {
        Bounds bounds = spawnArea.bounds;

        float x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        float y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        this.transform.position = new Vector3(x, y, 0.0f);
    }
}
