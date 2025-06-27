using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    [SerializeField] Config config;
    [Header("Important Scene Components")]
    [SerializeField] Transform customerEntryPoint;
    [SerializeField] Transform firstSeatAtCounter;

    static float customerSpawnIntervals;
    static float lastTimeCustomerSpawned;
    static Vector2 lastCustomerSeatPos;
    static List<Customer> activeCustomers = new List<Customer>();

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
        InitCustomerSettings();
    }

    private void Update() {
        TrySpawnCustomer();
    }

    private void InitPlayer() {
        Player player = Instantiate(config.PlayerPrefab, config.SpawnPos, Quaternion.identity).GetComponent<Player>();

        if (player == null) {
            Debug.LogError($"CRITICAL: The player prefab in Confg does not have an attached Player.cs. Please add one before running game.");
            return;
        }

        player.Init(config.HorizontalBounds, config.VerticalBounds);
    }

    #region Customers

    private void InitCustomerSettings() {
        customerSpawnIntervals = config.CustomerSpawnIntervals;
        lastTimeCustomerSpawned = 0f;
        lastCustomerSeatPos = new Vector2(firstSeatAtCounter.position.x, firstSeatAtCounter.position.y - config.SpaceBetweenCustomersAtCounter);
    }

    private void TrySpawnCustomer() {
        if (Time.time - lastTimeCustomerSpawned >= customerSpawnIntervals) {
            SpawnCustomer();
            lastTimeCustomerSpawned = Time.time;
        }
    }

    private void SpawnCustomer() {
        Vector2 seatPos = new Vector2(lastCustomerSeatPos.x, lastCustomerSeatPos.y + config.SpaceBetweenCustomersAtCounter);
        Customer customer = Instantiate(config.CustomerPrefab, customerEntryPoint.position, Quaternion.identity).GetComponent<Customer>();
        
        //safety check
        if (customer == null) {
            Debug.LogError($"CRITICAL: There is no Customer.cs component on the assigned customer prefab in Config. Please add one immediately and restart game.");
            return;
        }

        int colorIndex = Random.Range(0, config.PossibleSpriteColors.Length);
        Color color = config.PossibleSpriteColors[colorIndex];
        customer.Init(seatPos, color);

        activeCustomers.Add(customer);
        lastCustomerSeatPos = seatPos;
    }

    #endregion

}
