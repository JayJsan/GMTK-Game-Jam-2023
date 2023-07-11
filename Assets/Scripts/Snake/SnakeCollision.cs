using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "SnakeHead":
                Debug.Log("Collison!");
                GameManager.Instance.UpdateGameState(StateType.GAME_OVER);
                //other.gameObject.GetComponent<SnakeSegments>().RemoveLastSegment();
            break;
            default:
            //do nothing
            break;
        }
    }
}
