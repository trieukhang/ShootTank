using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed = 40f;

    Vector3 moveVelocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        moveVelocity = Vector3.zero;
        //move forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, moveSpeed*Time.deltaTime);
        }
        //move backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -moveSpeed*Time.deltaTime);
        }
        //turn left
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed*Time.deltaTime, 0);   
        }
        //turn right
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);   
        }
        limitedMove();
    }
    //limit player movement in map
    void limitedMove()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -140.0f,140.0f), transform.position.y, Mathf.Clamp(transform.position.z, -140.0f, 140.0f));
    }
}
