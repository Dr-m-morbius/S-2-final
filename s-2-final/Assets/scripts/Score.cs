using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      int score = GameObject.Find("player").GetComponent<playermove>()._Score;
      scoreText.text = "score; " + score.ToString();
    }
}
