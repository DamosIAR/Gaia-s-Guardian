using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int score;
    public GameObject CompleteCanvas;

    // Start is called before the first frame update
    void Start()
    {
        CompleteCanvas.SetActive(false);
        score = 0;
        ScoreText.text = ""+ score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Apel")
        {
            score += 1;
            Destroy(collision.gameObject);
            ScoreText.text = "" + score;
        }
        if (collision.tag == "FastApel")
        {
            score += 2;
            Destroy(collision.gameObject);
            ScoreText.text = "" + score;
        }

        if (score >= 30)
        {
            Time.timeScale = 0f;
            CompleteCanvas.SetActive(true);
        }
    }
}
