using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolkenMovement : MonoBehaviour
{
    public float floatSpeed = 1.0f; // Geschwindigkeit der Bewegung
    public float floatAmount = 0.2f; // Maximale Abweichung nach oben/unten

    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 2f * Mathf.PI); // Zufällige Phasenverschiebung für Variation
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed + randomOffset) * floatAmount;
        transform.position = new Vector3(startPosition.x, startPosition.y + yOffset, startPosition.z);
    }
}
