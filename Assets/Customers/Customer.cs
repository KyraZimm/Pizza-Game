using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomerState { WalkingToSeat, ReadyToOrder, Ordered, Served, Exiting }
public class Customer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] float walkSpeed;

    Vector2 destination;

    private const float MARGIN_OF_ERROR = .1f;

    public CustomerState CurrState { get; private set; } 

    public void Init(Vector2 walkToPoint, Color color) {
        WalkTo(walkToPoint);
        sr.color = color; //will eventually be changed to a sprite
        CurrState = CustomerState.WalkingToSeat;
    }

    private void Update() {
        if (CurrState == CustomerState.WalkingToSeat) {
            if ((rb.position - destination).sqrMagnitude <= MARGIN_OF_ERROR * MARGIN_OF_ERROR) { //if customer has reached seat, stop walking & enter ordering phase
                rb.velocity = Vector2.zero;
                ProgressState();
            }
        }
    }

    private void ProgressState() {
        if (CurrState < CustomerState.Exiting) CurrState++;
        else Destroy(this);
    }
    private void WalkTo(Vector2 pos) {
        destination = pos;

        Vector2 dir = (destination - rb.position).normalized;
        rb.velocity = dir * walkSpeed;
    }

}
