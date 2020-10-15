using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyMovement : MonoBehaviour
{

    private CharacterAnimation enemeyAnim;

    private Rigidbody myBody;
    public float speed = 5f;

    public Transform playerTarget;

    public float attack_Distance = 1f;
    public float defend_Distance = 0.8f;
    private float chase_Player_After_Attack = 1.5f;

    private float current_Attack_Time;
    private float default_Attack_Time = 0.5f;

    private bool followPlayer;
    private bool attackPlayer;
    public  bool  walkback = false;



    void Start()
    {
        followPlayer = true;
        enemeyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Attack();
      
        FollowPlayer();


    }
    void FollowPlayer()
    {
      

        if (!followPlayer)
            return;

        if(Vector3.Distance(transform.position,playerTarget.position)>attack_Distance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if (myBody.velocity.sqrMagnitude != 0)
            {
                enemeyAnim.Walk(true);
            }

        }
        else if(Vector3.Distance(transform.position,playerTarget.position)<= attack_Distance)
        {
            myBody.velocity = Vector3.zero;
            enemeyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }//end of enemey follow

    void Attack()
    {
        if (!attackPlayer)
            return;
        int DRval = Random.Range(0, 6);
        int WRval = Random.Range(0, 1);
        current_Attack_Time += Time.deltaTime;

        if(current_Attack_Time>default_Attack_Time)
        {
            if (DRval >= 5)
            {
                if (WRval == 1)
                {
                    walkback = true;
                    enemeyAnim.WalkBackFn(true);
                    walkback = false;
                   
                }else
                {
                     enemeyAnim.Defend();
                }
            }
            else
            {
                enemeyAnim.EnemyAttack(Random.Range(0, 4));
            }
            current_Attack_Time = 0f;
        }
        
        if (Vector3.Distance(transform.position,playerTarget.position)>=attack_Distance+chase_Player_After_Attack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
    
}
