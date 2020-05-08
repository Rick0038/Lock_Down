using UnityEngine;
using System.Collections;

public class PlayerMovement_v2 : MonoBehaviour{
public float movementSpeed = 1f;   
public Vector2 movement;           
public Rigidbody2D rigidbody;      
 

 
    void Start()
{
    rigidbody = this.GetComponent<Rigidbody2D>();
}
 
   void Update()
{
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");
}

private void FixedUpdate()
{
    rigidbody.MovePosition(rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
}

 }
