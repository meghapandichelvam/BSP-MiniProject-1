using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image playerhealth_UI;
    private Image enemyhealth_UI;

  
    void Awake()
    {
        playerhealth_UI = GameObject.FindWithTag(Tags.PLAYER_HEALTH_UI).GetComponent<Image>();
        enemyhealth_UI = GameObject.FindWithTag(Tags.ENEMY_HEALTH_UI).GetComponent<Image>();
            
    }

   public void DisplayHealth(float value)
    {
    

        if(gameObject.tag == Tags.PLAYER_TAG)
        {
            value /= 100f;
            if (value < 0f)
                value = 0f;
            playerhealth_UI.fillAmount = value;
        }
        if (gameObject.tag == Tags.ENEMY_TAG)
        {
            value /= 100f;
            if (value < 0f)
                value = 0f;
            enemyhealth_UI.fillAmount = value;
        }
    }
}
