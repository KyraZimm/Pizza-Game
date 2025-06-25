using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] Config config;

    private void Awake() {
        if (Instance != null) {
            Debug.LogWarning($"Destroying a newer instance of {nameof(GameManager)} on {gameObject.name} to preserve an older instance on {Instance.gameObject.name}.");
            DestroyImmediate(this);
            return;
        }
        Instance = this;

        if (config == null) {
            Debug.LogError($"CRITICAL: GameManager does not have an assigned Config file. Please assign one in order to initialize game.");
            return;
        }

        InitPlayer();
    }

    private void InitPlayer() {
        Player player = Instantiate(config.PlayerPrefab, config.SpawnPos, Quaternion.identity).GetComponent<Player>();

        if (player == null) {
            Debug.LogError($"CRITICAL: The player prefab in Confg does not have an attached Player.cs. Please add one before running game.");
            return;
        }

        player.Init(config.HorizontalBounds, config.VerticalBounds);
    }

}
