using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class FishScoreManager : MonoBehaviour
{
    
    ScoreStorage scoring;
    int score;

    
    void Start()
    {
        scoring = GameObject.FindGameObjectWithTag("Storage").GetComponent<ScoreStorage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Spear")
        {
            Debug.Log("hit");
            scoring.updateScore();

            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
        if (collision.tag == "FastFish")
        {
            
            Destroy(gameObject);
            
        }

       
    }
}
