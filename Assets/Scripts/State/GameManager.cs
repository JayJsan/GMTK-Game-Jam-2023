using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 7/06/23 - NEED TO IMPROVE 
    public static GameManager Instance { get; private set; }
    private StateType m_currentGameState = StateType.DEFAULT;
    public GameObject snakeHead;
    private SnakeMovement m_snakeHeadMovement;
    private int numberOfEnemiesToSpawn = 1;
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

    // Start is called before the first frame update
    void Start()
    {
        m_snakeHeadMovement = snakeHead.GetComponent<SnakeMovement>();
    }


    public void UpdateGameState(StateType state) {
        m_currentGameState = state;
         switch (state) {
            case StateType.PLAYING:
                CanvasManager.Instance.SwitchCanvas(CanvasType.GameUI);
            break;

            case StateType.PAUSE_MENU:

            break;

            case StateType.GAME_OVER:
                m_snakeHeadMovement.ToggleSnakeMovement(false);
                CanvasManager.Instance.SwitchCanvas(CanvasType.EndScreen);
            break;

            case StateType.SHOP_MENU:

            break;

            default:

            break;
        }
    }

    public void StartGame() {
  
    }

    public void RestartGame() {

    }

    public void ContinueGame() {

    }
    
    public bool IsGameStateThis(StateType stateType) {
        return stateType == m_currentGameState;
    }
}
