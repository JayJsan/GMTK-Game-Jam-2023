using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    // REFACTOR/DO BETTER - 10/06/23
    // - I REALLY DISLIKE USING GAMEOBJECT.FIND TO FIND TEXT ELEMENTS
    // - SURELY THERE'S A BETTER WAY OF DOING THIS
    public static UIManager Instance { get; private set; }
    
    private void Awake() {
    // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        DontDestroyOnLoad(gameObject);
    }

}
