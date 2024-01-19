using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTriggerer : MonoBehaviour
{
    
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualQue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;
    public PlayerInputActions PlayerControls;

    private void Awake()
    {
        playerInRange = false;
        visualQue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualQue.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                DialogueManager.GetInstance().enterDialogueMode(inkJSON);
            }
           
        }
        else
        {
            visualQue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if( collider.gameObject.tag == "Player")
        {
            playerInRange=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
