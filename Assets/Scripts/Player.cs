using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float walkSpeed;
    public float power;
    public float powerModifer;
    public float maxPower;
    public Vector2 angle;

    private Rigidbody2D rigidbody2D;
    public GameObject golfBall;
    Vector2 direction;

    private void Start() {
        golfBall = GameObject.Find("Golf Ball");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {

        Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        if (Input.GetButton("Hit")) {
            power += Time.deltaTime;
            power = Mathf.Min(power, maxPower);
        }
        if (Input.GetButtonUp("Hit")) {
            HitBall();
            power = 0.0f;
        }
    }

    private void HitBall() {
        Vector2 force = angle * power * powerModifer;
        golfBall.GetComponent<Rigidbody2D>().AddForce(force);
    }

    private void FixedUpdate() {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
        direction *= walkSpeed;
        direction.y = rigidbody2D.velocity.y;
        rigidbody2D.velocity = direction;
    }
}
