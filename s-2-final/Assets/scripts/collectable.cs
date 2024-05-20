using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class collectable : MonoBehaviour
 {
    [SerializeField] private int value = 1;
    private int score;

    public TextMeshProUGUI scoreText;

    void Start()
    {
         scoreText.text = "Sore: " + score.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(this.gameObject);
            score++;
            scoreText.text = "Sore: " + score.ToString();
        }
    }
}