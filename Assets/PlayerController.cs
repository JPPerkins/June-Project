using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;
    //[SerializeField] GameObject cube;
    Rigidbody thisRigidbody;
    [SerializeField] bool isJumping = false;
    [SerializeField] GameObject spawn;

    void Start() 
    {
        thisRigidbody = gameObject.GetComponentInChildren<Rigidbody>();
    } 
    void Update()
    {
        GetMovementInput();
        isJumping = CheckIfJumping();
    }

    private bool CheckIfJumping()
    {
        return (!Mathf.Approximately(thisRigidbody.velocity.y, 0));
    }

    private void GetMovementInput()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        if (Mathf.Abs(thisRigidbody.velocity.x) > speed)
        {
            thisRigidbody.velocity += Vector3.zero;
        }    
        else 
        {
            thisRigidbody.velocity += movement * speed;
        }
        
        // OLD MOVEMENT CODE
        // if (Input.GetKey(KeyCode.A)) {
        //     transform.Translate(Vector3.left * speed * Time.deltaTime);
        // }
        // else if (Input.GetKey(KeyCode.D)) {
        //     transform.Translate(Vector3.right * speed * Time.deltaTime);
        // }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            //thisRigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange); // += Vector3.up * jumpHeight;
            //movement += (Vector3.up * speed);
            //Debug.Log(Vector3.up * jumpHeight);
            thisRigidbody.velocity += Vector3.up * jumpHeight;
            isJumping = true;
        }
    
        
    }

    public void Respawn()
    {
        thisRigidbody.velocity = Vector3.zero;
        transform.position = spawn.transform.position;
    }
}
