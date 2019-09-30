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

    public GameObject tennisBall;
    public GameObject bone;

    public string moveType = "swing";

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
        GameObject temp = null;
        switch (moveType) {
            case "swing":
                temp = golfBall;
                break;
            case "tennis":
                temp = Instantiate(tennisBall, transform.position, Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-15.0f, 15.0f));
                break;
            case "bone":
                temp = Instantiate(bone, transform.position, Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-15.0f, 15.0f));
                break;
        }
        temp.GetComponent<Rigidbody2D>().AddForce(force);
    }

    private void FixedUpdate() {
        direction = new Vector2(Input.GetAxis("Horizontal"), 0.0f);
        direction *= walkSpeed;
        direction.y = rigidbody2D.velocity.y;
        rigidbody2D.velocity = direction;
    }
}
