using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2

}
public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation player_Anim;

    private bool activateTimerToReset;
    private float default_Combo_Timer = 1f;
    private float current_Combo_Timer;
    private float default_Timer = 0.5f;
    private float current_Timer;
    private ComboState current_Combo_State;

  
    void Awake()
    {
        player_Anim = GetComponentInChildren<CharacterAnimation>();

    }

   
    void Start()
    {
        current_Combo_Timer = default_Combo_Timer;
        current_Timer = default_Timer;
        current_Combo_State = ComboState.NONE;
    }


    void Update()
    {
        ComboAttack();
        ResetComboState();
    }

    void ComboAttack()
    {


        if (Input.GetKey(KeyCode.P) && (Input.GetKey(KeyCode.U)))
        {

            if (current_Combo_State == ComboState.PUNCH_3 || current_Combo_State == ComboState.KICK_1 || current_Combo_State == ComboState.KICK_2)
                return;
            current_Combo_State++;
            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == ComboState.PUNCH_1)
                player_Anim.Punch_1();
            if (current_Combo_State == ComboState.PUNCH_2)
                player_Anim.Punch_2();
            if (current_Combo_State == ComboState.PUNCH_3)
                player_Anim.Punch_3();
             GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<PlayerAttack>().enabled = false;
           
        }

        if (Input.GetKey(KeyCode.P) && (Input.GetKey(KeyCode.I)))
        {
            if (current_Combo_State == ComboState.PUNCH_3 || current_Combo_State == ComboState.KICK_2)
                return;

            if (current_Combo_State == ComboState.NONE || current_Combo_State == ComboState.PUNCH_1 || current_Combo_State == ComboState.PUNCH_2)
            {
                current_Combo_State = ComboState.KICK_1;
            }
            else if (current_Combo_State == ComboState.KICK_1)
            {
                current_Combo_State++;
            }

            activateTimerToReset = true;
            current_Combo_Timer = default_Combo_Timer;

            if (current_Combo_State == ComboState.KICK_1)
                player_Anim.Kick_1();
            if (current_Combo_State == ComboState.KICK_2)
                player_Anim.Kick_2();
            

        }
       

        if (Input.GetKeyDown(KeyCode.U))
        {
            activateTimerToReset = true;
            current_Timer = default_Timer;
           
            player_Anim.Punch_1();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            activateTimerToReset = true;
            current_Timer = default_Timer;
        
            player_Anim.Punch_2();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            activateTimerToReset = true;
            current_Timer = default_Timer;
         
            player_Anim.Punch_3();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            activateTimerToReset = true;
            current_Timer = default_Timer;
           
            player_Anim.Kick_1();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            activateTimerToReset = true;
            current_Timer = default_Timer;
          
            player_Anim.Kick_2();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            activateTimerToReset = true;
            current_Timer = default_Timer;
            player_Anim.Defend();
        }

        }//combo attack

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            current_Combo_Timer -= Time.deltaTime;
            current_Timer -= Time.deltaTime;
          
            if (current_Combo_Timer <= 0f )
            {
                
                current_Combo_State = ComboState.NONE;
                activateTimerToReset = false;
                current_Combo_Timer = default_Combo_Timer;
               

            }
            else if (current_Timer <= 0f )
            {
               
                current_Combo_State = ComboState.NONE;
                activateTimerToReset = false;
                current_Timer = default_Timer;
                
            }
        }
    }//reset combo class
}
