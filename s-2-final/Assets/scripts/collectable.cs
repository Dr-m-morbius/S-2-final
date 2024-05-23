using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using Unity.VisualScripting;

public class collectable : MonoBehaviour
 {
   // [SerializeField] private int value = 1;
    public int score;

   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(this.gameObject);
            score++;
             Debug.Log("player collected a coin");
        }
    }
}