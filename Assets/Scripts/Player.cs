using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed;

    private Rigidbody2D rigidbody2D;
    Vector2 direction;

    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
        direction *= walkSpeed;
        direction.y = rigidbody2D.velocity.y;
        rigidbody2D.velocity = direction;
    }
}
