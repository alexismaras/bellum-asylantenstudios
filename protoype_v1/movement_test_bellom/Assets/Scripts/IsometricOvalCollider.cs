using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricOvalCollider : MonoBehaviour
{
    [SerializeField] PolygonCollider2D polygonCollider;
    [SerializeField] float width = 3f;  // Horizontal size
    [SerializeField] float height = 1.5f;  // Vertical size (squished for isometric look)
    [SerializeField] float offset; 

    void Start()
    {
        if (polygonCollider == null)
            polygonCollider = GetComponent<PolygonCollider2D>();

        Vector2[] points = new Vector2[21]; // 10 points + 1 to close the loop
        float angleStep = 2f * Mathf.PI / 20; // 10 evenly spaced points

        for (int i = 0; i < 20; i++)
        {
            float angle = i * angleStep;
            float x = width * Mathf.Cos(angle);
            float y = ((height * Mathf.Sin(angle)) * 0.5f) + offset; // Squishing Y for isometric look
            points[i] = new Vector2(x, y);
        }

        points[20] = points[0]; // Close the shape

        polygonCollider.points = points;
    }
}
