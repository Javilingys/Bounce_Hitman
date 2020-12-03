using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private Vector2 movementVector = new Vector2();
    [SerializeField]
    private float period = 0f;

    private float movementFactor;

    Vector2 startingPos;

    private void Awake()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;

        float cycles = Time.time / period; // grows contiunally from 0

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector2 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }

}
