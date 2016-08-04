using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    public enum gameState {lobby,play };
    public gameState currentGameState = gameState.lobby;

    public void setGameStateToPlay()
    {
        currentGameState = gameState.play;
    }
    public void setGameStateToLobby()
    {
        currentGameState = gameState.lobby;
    }
}
