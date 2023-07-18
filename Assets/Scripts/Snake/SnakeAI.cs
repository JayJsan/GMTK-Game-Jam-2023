using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SnakeAI : MonoBehaviour
{
    public GameObject playerFood;
    private List<GameObject> listOfFood = new List<GameObject>();
    private List<GameObject> listOfDecoys = new List<GameObject>();
    private List<GameObject> listOfPossibleTargets = new List<GameObject>();
    private SnakeMovement snakeMovement;

    void Start() {
        // Grab references.
        listOfFood = GameObject.FindGameObjectsWithTag("Food").ToList();
        listOfDecoys = GameObject.FindGameObjectsWithTag("Decoy").ToList();
        listOfPossibleTargets.AddRange(listOfFood);
        listOfPossibleTargets.AddRange(listOfDecoys);
        listOfPossibleTargets.Add(playerFood);

        // Grab components
        snakeMovement = GetComponent<SnakeMovement>();
    }

    void Update() {
        // Find nearest target
        
        // Move towards it
    }
    // find nearest food,
    // move towards it
    

    // optional decisions/random decisions
    // when 3 blocks away from fruit and is longer than 10 segments
    // have random chance to: 
    // move in a circle
    // create a circle
}
