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

    private void Update() {
        Vector3 Up = transform.up;
        Rigidbody.velocity += new Vector2(Up.x,Up.y) * ForwardForce * Time.deltaTime;
        ForwardForce = Mathf.Lerp(ForwardForce,0,Time.deltaTime);
    }

    public void MoveForward(){
       ForwardForce = Speed ;
        print("MoveForward");
    }

     public void MoveDown(){
         Rigidbody.velocity = Vector2.Lerp(Rigidbody.velocity  , new Vector2() , Time.deltaTime );
         ForwardForce = 0;
        print("MoveDown");
    }

   public void TurnLeft(){
        Rigidbody.rotation += LeftTurningSpeed * Time.deltaTime;
        print("TurnLeft");
    }
   public void TurnRight(){
        Rigidbody.rotation -= RightTurningSpeed * Time.deltaTime;
        print("TurnRight");
    }

}
