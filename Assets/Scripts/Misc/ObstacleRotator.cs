using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationVector = new Vector2();
    [SerializeField]
    private float period = 0f;

    private float rotationFactor;

    Vector3 startingRot;

    void Start()
    {
        startingRot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;

        float cycles = Time.time / period; // grows contiunally from 0

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau);

        rotationFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = rotationFactor * rotationVector;
        transform.rotation = Quaternion.Euler(startingRot + offset);
    }
}
