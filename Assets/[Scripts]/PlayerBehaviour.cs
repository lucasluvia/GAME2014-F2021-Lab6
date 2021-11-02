using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    public float groundRadius;
    public LayerMask groundLayerMask;
    public Transform groundOrigin;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        CheckIfGrounded();
    }

    private void Move()
    {
        if(isGrounded)
        {
            // Keyboard / Mouse Input
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            float jump = Input.GetAxisRaw("Jump");

            Vector2 worldTouch = new Vector2();


            // Touch Input
            foreach (var touch in Input.touches)
            {
                worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            }

            var horizontalMoveForce = x * horizontalForce * Time.deltaTime;
            var jumpMoveForce = jump * verticalForce * Time.deltaTime;

            rigidbody.AddForce(new Vector2(horizontalMoveForce, jumpMoveForce));

        }
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D hit = Physics2D.CircleCast(groundOrigin.position, groundRadius, Vector2.down, groundRadius, groundLayerMask);
        isGrounded = (hit) ? true : false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundOrigin.position, groundRadius);
    }

}
