using UnityEngine;

public class GameManage : MonoBehaviour
{

    // simplified manager and removed recursive functions to prevent crashes

    [Header("Player Settings")]
    public PlayerController[] Players;
    public float PlayerSpeed = 5f;
    public float MaxPlayerSpeed = 10f;

    public Transform RespawnLocation; // This can vary per level.

    [Header("Interactions")]
    [Tooltip("The layer hazards are on (8 by default)")]
    public LayerMask HazardMask = 1 << 8; // Assign to layer 8 (hazard) by default
    [Tooltip("How long (in seconds) the player will have a status effect while in a hazard.")]
    public float HazardPenalty = 3;


    [Tooltip("The time (in seconds) it takes for a player to drop out due to inactivity.")]
    public float idleTimeOut = 60f;

    public float TimeRemaining = 300f; // 5 minutes

    public bool IsGameEnd = false;


 


    void FixedUpdate()
    {
        foreach (PlayerController player in Players) // Call each player's input and movement at the same time.
        {
            if (player.gameObject.activeInHierarchy) { player.HandlePlayer(); }
        }
    }


}
