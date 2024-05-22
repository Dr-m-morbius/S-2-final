using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leaveintro : MonoBehaviour
{
    public int title;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
     {
        if (other.gameObject.CompareTag("player"))
        {
             SceneManager.LoadScene(title);
        }
     }
}
