using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySight : MonoBehaviour
{
    private Transform target;
    public float range;
    public Transform enermyRotate;
    public float turnSpeed;

    private EnermyMove enermyMove;  //call class EnermyMove
    private EnermyMoveRandomly enermyMoveRandomly;// call class EnermyMoveRandomly
    private ShootPlayer shootPlayer; // call class ShootPlayer


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        enermyMove = GetComponent<EnermyMove>();
        enermyMoveRandomly = GetComponent<EnermyMoveRandomly>();
        shootPlayer = GetComponent<ShootPlayer>();
    }
    void UpdateTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer < shortestDistance)
        {
            shortestDistance = distanceToPlayer;
            nearestPlayer = player;
        }
        if (nearestPlayer != null && shortestDistance <= range)//when enermy sees player 
        {
            //define player is enermy's target
            target = nearestPlayer.transform;
            //move to the target (player) 
            enermyMove.enabled = true;  //turning this class is enable
            enermyMoveRandomly.enabled = false;//turn this class is disable
            shootPlayer.enabled = true; //turning this class is enable 
        }
        else    //when enermy doesn't see player
        {
            target = null;
            enermyMove.enabled = false;
            enermyMoveRandomly.enabled = true;
            shootPlayer.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotate = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(enermyRotate.rotation, lookRotate, turnSpeed * Time.deltaTime).eulerAngles;
        enermyRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        

    }
    //This function shows enermy's range attack
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
