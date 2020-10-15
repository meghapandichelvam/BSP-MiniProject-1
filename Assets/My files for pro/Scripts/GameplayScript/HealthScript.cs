using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthScript : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimation animationScript;
    private EnemeyMovement enemyMovement;
    private bool characterDied;
    public bool is_Player;



    private HealthUI health_UI;
    void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
        //if(is_Player)
        health_UI = GetComponent<HealthUI>();
        GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemeyMovement>().enabled = true;
        GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<PlayerAttack>().enabled = true;

    }
    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;

      
        if (is_Player && animationScript.defendBool == true)
        {
            health -=0f;
            animationScript.defendBool = false;
        }
        else if (!is_Player && animationScript.defendBool == true)
        {
            health -= 0f;
            animationScript.defendBool = false;
        }
        else
        {
            health -= damage;
        }
        health_UI.DisplayHealth(health);
        if (health <= 0f)
        {
            GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemeyMovement>().enabled = false;
            GameObject.FindWithTag(Tags.PLAYER_TAG).GetComponent<PlayerAttack>().enabled = false;
            if (is_Player)
            {
             
                animationScript.Death();
                characterDied = true;

            }
            if(!is_Player)
            {
                animationScript.EnemyDeath();
                characterDied = true;

            }
            Invoke("DeathAnimActivate", 5f);
            return;

        }
        
        if (!is_Player)
        {

            if (knockDown)
            {
                if (Random.Range(0,5) > 3)
                {
                    animationScript.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 6) > 3)
                {
                    animationScript.Hit();
                }
            }
        }
    }
    void DeathAnimActivate()
    {
        if (is_Player)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("GameComplete");
        }
    }
}
