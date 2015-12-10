using UnityEngine;
using System.Collections;

public class Player : ControllerInput {
    
    //Terrain
    private bool    _isGrounded;
    private bool    _isInAir;
    //Jumping
    private bool    _canJump;
    private int     _jumpCount;
    [SerializeField]    
    private int     _maxJumps;
    //Speed
    [SerializeField]    
    private float   _dashSpeed;
    [SerializeField]    
    private float   _speed;
    //Attack
    private float   _attackInterval = 1;
    private float   _attackTimer = 0;
    //Particles & Animator
    private Animator _playerAnim;
    [SerializeField]
    private GameObject _smokeCloud;
    private bool _isMoving;
	// Use this for initialization
	void Start () 
    {
        _playerAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        AerialMovement();
        Movement();
        Rotate();
        Attack();

        if (_attackTimer < _attackInterval)
        {
            _attackTimer += Time.deltaTime;
        }
	}

    void Movement()
    {
        if(_lsUp)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            _playerAnim.Play("Walk");
        }
        if(_lsDown)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * _speed);
        }
        if(_lsRight)
        {
            transform.Translate(-Vector3.left * Time.deltaTime * _speed);
        }
        if(_lsLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
    }

    void Rotate()
    {
        Transform cameraController = transform.GetChild(0);
        
        if(_rsLeft)
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * 100);
        }
        if(_rsRight)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100);
        }
        if(_rsUp)
        {
            cameraController.Rotate(-Vector3.right * Time.deltaTime * 100);
        }
        if(_rsDown)
        {
            cameraController.Rotate(Vector3.right * Time.deltaTime * 100);
        }
    }

    void AerialMovement()
    {
       if(_jumpCount < _maxJumps)
       {
           if(_aPressed)
           {
               this.GetComponent<Rigidbody>().velocity = new Vector3(0, 8, 0);
               _jumpCount++;
               _isInAir = true;
           }
       }

        if(_isInAir)
        {
            if(_lbPressed)
            {
                Instantiate(_smokeCloud, transform.position, Quaternion.identity);
                transform.Translate(Vector3.left * Time.deltaTime * _dashSpeed);
                
            }
            if(_rbPressed)
            {
                Instantiate(_smokeCloud, transform.position, Quaternion.identity);
                transform.Translate(Vector3.right * Time.deltaTime * _dashSpeed);
            }
        }
    }

    void Attack()
    {
       
        if(_xPressed && _attackTimer >= _attackInterval)
        {
            //Attack animation
            _attackTimer = 0f;
            Debug.Log("Attacking");
        }else if(_xPressed && _attackTimer < _attackInterval)
        {
            Debug.Log("Cooldown");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _jumpCount = 0;
            _isInAir = false;
        }

        if (other.gameObject.tag == "Player" )
        {
            Debug.Log("Player");
        }

        if (other.gameObject.tag == "Sword_Blade")
        {
            //Play death animation

            //Respawn Timer
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag =="Player")
        {
            Debug.Log("Player");
        }
    }
}
