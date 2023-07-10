using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType {
    PLAYING,
    GAME_OVER,
    SHOP_MENU,       // Player is viewing shop menu
    PAUSE_MENU,     // Player is viewing in-game menu
    DEFAULT       // SCENE IS IN MAIN MENU
}