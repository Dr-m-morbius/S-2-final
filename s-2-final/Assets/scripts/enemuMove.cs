using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemuMove : MonoBehaviour
{
    private Vector3 startingPositon;

public float speed = 1f;
    public float rangeValue = 5f;
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _enemyAnimation;
    [SerializeField] private Rigidbody _enemyRb;
[SerializeField] private bool _isAtking;
    // Start is called before the first frame update
    void Start()
    {
        startingPositon = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = (_player.position - transform.position).normalized;
        
        float distance = Vector3.Distance(_player.position, transform.position);
        Debug.Log("Distance " + distance);
        if(distance < rangeValue)
        {
            _enemyRb.velocity = movementDirection * speed;
            transform.LookAt(_player);
            _enemyAnimation.SetBool("IsMoving", true);
        }
        else
        {
            _enemyAnimation.SetBool("IsMoving", false);
            _enemyRb.velocity = movementDirection * 0;
        }
    }// end Update

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("player"))
        {
        Debug.Log("Player hit");
        _isAtking = true;
        }
    }
}