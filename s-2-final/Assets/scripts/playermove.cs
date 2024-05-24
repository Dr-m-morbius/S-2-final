using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class playermove : MonoBehaviour
{
     public float moveSpeed = 1f;
      public GameObject bullet;
      public int _Score;
      public TextMeshProUGUI scoreText;
      
      public GameObject fireball;
    public Transform firePoint;
    public Transform fireballpoint;
    public float jumpForce = 10f;
    private ammo _ammo;
    private FireAmmo fireAmmo;
      public Transform theCamera;
    public float gravityModifier = 1f;
        public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    public float mouseSensitivity = 1f;
    private Vector3 _moveInput;
    private Vector3 starttingPose; 
     private bool _canPlayerJump;
        private CharacterController _characterController;
        [SerializeField] private Animator _playerAnim;

    // Start is called before the first frame update
    void Start()
    {
         Cursor.lockState = CursorLockMode.Locked;
          _characterController = GetComponent<CharacterController>();
          _playerAnim = GetComponent<Animator>();
          starttingPose = transform.position;
          _ammo = GetComponent<ammo>();
          fireAmmo = GetComponent<FireAmmo>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player jump setup
        float yVelocity = _moveInput.y;

        //Player movement
        //_moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        //_moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 forwardDirection = transform.forward * Input.GetAxis("Vertical");
        Vector3 horizontalDirection = transform.right * Input.GetAxis("Horizontal");

        _moveInput = (forwardDirection + horizontalDirection).normalized;
        _moveInput *= moveSpeed;

        //Apply Jumping
        _moveInput.y = yVelocity;

        _moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        //Check if character controller is on the ground
        if(_characterController.isGrounded)
        {
            _moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        //Check if player can jump
        _canPlayerJump = Physics.OverlapSphere(groundCheckpoint.position, 0.5f, whatIsGround).Length > 0;

        //Make player jump
        if(Input.GetKeyDown(KeyCode.Space) && _canPlayerJump)
        {
            _moveInput.y = jumpForce;
        }

     float horizontalInput = Input.GetAxis("Horizontal");
     float verticalInput = Input.GetAxis("Vertical");
        _characterController.Move(_moveInput * Time.deltaTime);

        //Camera rotation
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        theCamera.rotation = Quaternion.Euler(theCamera.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

        //primary shooting
         if(Input.GetMouseButtonDown(1) && _ammo.GetAmmoAmount() > 0)
         {
            //Find the crosshair
            RaycastHit hit;
            if(Physics.Raycast(theCamera.position, theCamera.forward, out hit, 50f))
            {
                if(Vector3.Distance(theCamera.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(theCamera.position + (theCamera.forward * 30f));
            }
              Instantiate(bullet, firePoint.position, firePoint.rotation);
              _ammo.RemoveAmmo();
         }

         //secondary shooting 
         if(Input.GetMouseButtonDown(0) && fireAmmo.GetAmmoAmount() > 0)
         {
            //Find the crosshair
            RaycastHit hit;
            if(Physics.Raycast(theCamera.position, theCamera.forward, out hit, 50f))
            {
                if(Vector3.Distance(theCamera.position, hit.point) > 2f)
                {
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(theCamera.position + (theCamera.forward * 30f));
            }
              Instantiate(fireball, fireballpoint.position, fireballpoint.rotation);
              fireAmmo.RemoveAmmo();
         }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coll"))
        {
            Destroy(other.gameObject);
            _Score++;
    scoreText.text = "score; " + _Score.ToString();
        }
    }
}
