using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    public bool defendBool = false;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
     
       
    }
   public void Walk(bool move)
    {
        anim.SetBool(AnimationTag.MOVEMENT, move);
    }
    public void Punch_1()
    {
        anim.SetTrigger(AnimationTag.PUNCH_1_TRIGGER);
    }
    public void Punch_2()
    {
        anim.SetTrigger(AnimationTag.PUNCH_2_TRIGGER);
    }
    public void Punch_3()
    {
        anim.SetTrigger(AnimationTag.PUNCH_3_TRIGGER);
    }
    public void Kick_1()
    {
        anim.SetTrigger(AnimationTag.KICK_1_TRIGGER);
    }
    public void Kick_2()
    {
        anim.SetTrigger(AnimationTag.KICK_2_TRIGGER);
    }
    public void Defend()
    {
        anim.SetTrigger(AnimationTag.DEFEND_TRIGGER);
        defendBool = true;
    }
    public void WalkBackFn(bool boolval)
    {
        anim.SetBool(AnimationTag.WALK_BACK,boolval);
        
    }

    //ememy animation
    public void EnemyAttack(int attack)
    {
        if(attack == 0)
        {
            anim.SetTrigger(AnimationTag.Attack_1_TRIGGER);
        }
        if (attack == 1)
        {
            anim.SetTrigger(AnimationTag.Attack_2_TRIGGER);
        }
        if (attack == 2)
        {
            anim.SetTrigger(AnimationTag.Attack_3_TRIGGER);
        }
        if (attack == 3)
        {
            anim.SetTrigger(AnimationTag.Attack_4_TRIGGER);
        }
        if (attack == 4)
        {
            anim.SetTrigger(AnimationTag.Attack_5_TRIGGER);
        }

    }//end of enemey attack
    public void Play_IdleAnimation()
    {
        anim.Play(AnimationTag.IDLE_ANIMATION);

    }
    public void KnockDown()
    {
       
        anim.SetTrigger(AnimationTag.KNOCK_DOWN_TRIGGER);
    }
    public void StandUp()
    {
     
        anim.SetTrigger(AnimationTag.STAND_UP_TRIGGER);
    }
    public void Hit()
    {
        anim.SetTrigger(AnimationTag.HIT_TRIGGER);
    }
    public void Death()
    {
        
        if (this.gameObject.tag == Tags.PLAYER_TAG)
        {
            anim.SetTrigger(AnimationTag.DEATH_TRIGGER);
        }
    }
    public void EnemyDeath()
    {

        if (this.gameObject.tag == Tags.ENEMY_TAG)
        {
            anim.SetTrigger(AnimationTag.DEATH_TRIGGER);
        }
    }
    

}
