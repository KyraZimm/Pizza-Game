using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workstation : MonoBehaviour
{
    [SerializeField] float interactionTimeRequired;
    [SerializeField] float requiredPlayerRadius;

    Vector2 pos; //saves us from calling to the C++ layer and/or converting Vector3 to Vector2 each frame
    float totalTimeInteracted = 0;

    private void Awake() {
        pos = transform.position;
        Reset();
    }

    private void Update() {
        //do not interact if player is out of range
        if ((pos - Player.Position).sqrMagnitude > requiredPlayerRadius * requiredPlayerRadius)
            return;

        if (Input.GetButton("Interact")) {
            totalTimeInteracted += Time.deltaTime;
            Debug.Log($"interacted for {totalTimeInteracted} seconds");
        }
    }

    private void Reset() {
        totalTimeInteracted = 0;
    }
}
