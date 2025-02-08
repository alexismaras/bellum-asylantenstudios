using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolkenMovement : MonoBehaviour
{
    [SerializeField] float speed = 1.0f; // Geschwindigkeit der Bewegung
    [SerializeField] float amount = 0.2f; // Maximale Abweichung nach oben/unten

    Vector3 startPosition;
    float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 2f * Mathf.PI); // Zufaellige Phasenverschiebung fuer Variation
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * speed + randomOffset) * amount;
        transform.position = new Vector3(startPosition.x, startPosition.y + yOffset, startPosition.z);
    }
}
