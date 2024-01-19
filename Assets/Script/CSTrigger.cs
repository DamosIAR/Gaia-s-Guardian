using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CSTrigger : MonoBehaviour
{

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualQue;
    [SerializeField] public string sceneName;

    private bool playerInRange;
    public PlayerInputActions PlayerControls;

    private void Awake()
    {
        playerInRange = false;
        visualQue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            visualQue.SetActive(true);
            if (Input.GetKey(KeyCode.F))
            {
                changeScene(sceneName);
            }

        }
        else
        {
            visualQue.SetActive(false);
        }
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
