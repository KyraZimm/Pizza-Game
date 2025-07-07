using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;

    private Vector2 horizontalBounds;
    private Vector2 verticalBounds;
    private Vector2 velocity;

    public static Vector2 Position { get { return Instance.rb.position; } }

    private void Awake() {
        if (Instance != null) {
            Debug.LogWarning($"Destroying a newer instance of {nameof(Player)} on {gameObject.name} to preserve an older instance on {Instance.gameObject.name}.");
            DestroyImmediate(this);
            return;
        }
        Instance = this;
    }

    public void Init(Vector2 xBounds, Vector2 yBounds) {
        horizontalBounds = xBounds;
        verticalBounds = yBounds;
    }

    private void Update() {
        UpdateWalk();
    }

    private void UpdateWalk() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //ensure that player is not exiting boundaries
        if ((rb.position.x <= horizontalBounds.x && x < 0) || (rb.position.x >= horizontalBounds.y && x > 0)) {
            x = 0;
        }
        if ((rb.position.y <= verticalBounds.x && y < 0) || (rb.position.y >= verticalBounds.y && y > 0)) {
            y = 0;
        }

        velocity = new Vector2(x, y);
        velocity.Normalize();
        velocity *= speed;

        rb.velocity = velocity;
    }
}
