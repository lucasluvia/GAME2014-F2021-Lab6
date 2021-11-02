using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float horizontalForce;
    public float verticalForce;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Keyboard / Mouse Input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 worldTouch = new Vector2();


        // Touch Input
        foreach (var touch in Input.touches)
        {
            worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
        }

        Debug.Log("X: " + x);
        Debug.Log("Y: " + y);
        Debug.Log("Touch: " + worldTouch);

    }
}
