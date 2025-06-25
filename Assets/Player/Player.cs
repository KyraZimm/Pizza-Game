using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;

    private void Update() {
        UpdateWalk();
    }

    private void UpdateWalk() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y);
        dir.Normalize();

        rb.velocity = dir * speed;
    }
}
