using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMoveRandomly : MonoBehaviour
{
    Rigidbody rbEnermy;
    float positionX;
    float positionZ;
    //Limit movement area

    Vector3 targetPos;
    public float speedMove;
    public float speedTurn;

    void Awake()
    {
        rbEnermy = GetComponent<Rigidbody>();   
    }
 
    void Start()
    {
        GetNewPosition();
    }

    void GetNewPosition()
    {
        positionX = Random.Range(-140f, 140f);
        positionZ = Random.Range(-140f, 140f);

        Vector3 newPosition = new Vector3(positionX, transform.position.y, positionZ);
        targetPos = newPosition;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPos) < 5f)
            GetNewPosition();
        Rotate();
    }
    void FixedUpdate()
    {
        Move();    
    }
    void Rotate()
    {
        Vector3 tankDirection = targetPos - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, tankDirection, speedTurn * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    void Move()
    {
        Vector3 moveForward = transform.forward * speedMove * Time.deltaTime;
        rbEnermy.MovePosition(rbEnermy.position + moveForward);
    }
}
