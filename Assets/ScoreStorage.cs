using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStorage : MonoBehaviour
{
    [SerializeField] public GameObject gameoverPanel;
    [SerializeField] public TextMeshProUGUI TextScore;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameoverPanel.SetActive(false);
        TextScore.text = "" + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore()
    {
        score += 1;
        Debug.Log("scorestorage");

        TextScore.text = "" + score;

        if (score == 10)
        {
            gameoverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
