using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Workstation : MonoBehaviour
{
    [SerializeField] float interactionTimeRequired;
    [SerializeField] float requiredPlayerRadius;
    [SerializeField] Slider timer;

    Vector2 pos; //saves us from calling to the C++ layer and/or converting Vector3 to Vector2 each frame
    float totalTimeInteracted = 0;

    private void Awake() {
        pos = transform.position;
        Reset();
    }

    private void Update() {
        
        if ((pos - Player.Position).sqrMagnitude <= requiredPlayerRadius * requiredPlayerRadius) {
            if (Input.GetButton("Interact")) {
                totalTimeInteracted += Time.deltaTime;
                Debug.Log($"interacted for {totalTimeInteracted} seconds");
            }
        }

        UpdateTimerVisual();
    }

    private void UpdateTimerVisual() {
        float value = totalTimeInteracted / interactionTimeRequired;
        timer.value = value;
        timer.gameObject.SetActive(value >= 0.01f); //if timer is close to 0 (with some margin of error), hide timer
    }

    private void Reset() {
        totalTimeInteracted = 0;
    }


}
