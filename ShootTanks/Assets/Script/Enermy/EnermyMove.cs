using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMove : MonoBehaviour
{
    public float moveSpeed = 500f;
    public float reteatSpeed = 1000f;
    public float stoppingDistance = 2000f;  //Enermy will stop when approaching player.
    public float retreatDistance = 1500f;   //Enermy will back away from player

    public Transform player;
    //Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        enermyMoveToPlayer();
        
    }
    public void enermyMoveToPlayer()
    {
        //                      Enermy's position   player's position                      //
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        //keeping distance is far or near enough from player
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        //move back away
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -reteatSpeed * Time.deltaTime);
        }
        transform.LookAt(player);
    }
    
}
