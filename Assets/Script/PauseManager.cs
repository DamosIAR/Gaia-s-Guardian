using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
    }

    public void Paused()
    {
        isPaused = true;
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void Unpaused()
    {
        isPaused = false;
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Paused();
        }
    }
}
