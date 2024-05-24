using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
     public float moveSpeed = 10f;
     public Transform firePoint;
     public Transform expopoint;
     public GameObject explo;
    public float lifeTime = 5f;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
       _rigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    { 
        _rigidbody.velocity = transform.forward * moveSpeed;

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
         Instantiate(explo, expopoint.position, expopoint.rotation);
          Destroy(this.gameObject);


        
    }
}
