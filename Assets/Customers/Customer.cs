using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float walkSpeed;

    Vector2 destination;

    private const float MARGIN_OF_ERROR = .1f;


    public void Init(Vector2 walkToPoint, Color color) {
        WalkTo(walkToPoint);
        sr.color = color; //will eventually be changed to a sprite
    }

    private void Update() {
        bool reachedDestination = (rb.position - destination).sqrMagnitude <= MARGIN_OF_ERROR * MARGIN_OF_ERROR;
        if (reachedDestination) {
            rb.velocity = Vector2.zero;
        }
    }

    private void WalkTo(Vector2 pos) {
        destination = pos;

        Vector2 dir = (destination - rb.position).normalized;
        rb.velocity = dir * walkSpeed;
    }

}
