using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody2D Rigidbody;

    [SerializeField]
    public float Speed;
    [SerializeField]
    public float LeftTurningSpeed;

    float ForwardForce;
    [SerializeField]
    public float RightTurningSpeed;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 Up = transform.up;
        Rigidbody.MovePosition(Rigidbody.position + (new Vector2(Up.x, Up.y) * ForwardForce * Time.fixedDeltaTime));
        ForwardForce = Mathf.Lerp(ForwardForce, 0, Time.deltaTime);
    }

    public void MoveForward()
    {
        ForwardForce = Speed;
    }

    public void MoveDown()
    {
        Rigidbody.velocity = Vector2.Lerp(Rigidbody.velocity, new Vector2(), Time.deltaTime);
        ForwardForce = 0;
    }

    public void TurnLeft()
    {
        Rigidbody.rotation += LeftTurningSpeed * Time.deltaTime;
    }
    public void TurnRight()
    {
        Rigidbody.rotation -= RightTurningSpeed * Time.deltaTime;
    }

}
