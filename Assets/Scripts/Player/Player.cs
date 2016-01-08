using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : ControllerInput
{

    private bool _isAlive;
    //Terrain
    private bool _isGrounded;
    private bool _isInAir;
    //Jumping
    private bool _canJump;
    private int _jumpCount;
    [SerializeField]
    private float _jumpHeight;
    [SerializeField]
    private int _maxJumps;
    //Speed
    [SerializeField]
    private float _teleportDistance;
    [SerializeField]
    private float _speed;
    private float _defaultSpeed;
    //Attack
    private bool _isAttacking;
    private float _attackAnimTime;
    private float _attackInterval = 4f;
    private float _attackTimer = 0f;
    //Particles & Animator
    Animator _playerAnim;
    [SerializeField]
    private GameObject _smokeCloud;
    private bool _isMoving;
    //Lives
    public Text livesText;
    [SerializeField]
    private int _lives;

    private enum animState
    {
        Idle,
        Walking,
        Jumping,
        IdleAttack,
        WalkingAttack,
        Death
    }
   
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        livesText = GameObject.Find("Player" + joystickNumber + "Lives").GetComponent<Text>();
        livesText.text = "Player " + joystickNumber + " Lives : " + _lives.ToString();
        _isAlive = true;
    }

    void Update()
    {
        if (_isAlive)
        {
            AerialMovement();
            Movement();
            Rotate();
            Attack();

            //Attack Cooldown starter
            if (_attackTimer < _attackInterval)
            {
                _attackTimer += Time.deltaTime;
            }
        }
    }

    void Movement()
    {
        if (_lsUp)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            _playerAnim.SetInteger("State",1);
        }
        if (_lsDown)
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * _speed / 1.5f);
        }
        if (_lsRight)
        {
            transform.Translate(-Vector3.left * Time.deltaTime * _speed);
        }
        if (_lsLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        }
    }

    void Rotate()
    {
        Transform cameraController = transform.GetChild(0);

        if (_rsLeft)
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * 250);
        }
        if (_rsRight)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 250);
        }

        if (_rsUp)
        {
            cameraController.Rotate(-Vector3.right * Time.deltaTime * 250);
        }
        if (_rsDown)
        {
            cameraController.Rotate(Vector3.right * Time.deltaTime * 250);
        }



    }

    void AerialMovement()
    {
        if (_jumpCount < _maxJumps)
        {
            if (_aPressed)
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, _jumpHeight, 0);
                _jumpCount++;
                _isInAir = true;
            }
        }

        if (_isInAir)
        {
            if (_lbPressed)
            {
                Instantiate(_smokeCloud, transform.position, Quaternion.identity);
                transform.Translate(Vector3.left * Time.deltaTime * _teleportDistance);
            }
            if (_rbPressed)
            {
                Instantiate(_smokeCloud, transform.position, Quaternion.identity);
                transform.Translate(Vector3.right * Time.deltaTime * _teleportDistance);
            }
        }
    }

    void Attack()
    {

        if (_xPressed && _attackTimer >= _attackInterval)
        {
            //Attack animation
            _attackTimer = 0f;
            _playerAnim.SetTrigger("Attacking");
            StartCoroutine(AttackTimer());
            Debug.Log("Attacking");
        }
        else if (_xPressed && _attackTimer < _attackInterval)
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

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player");
        }


    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("Player");
        }
        if (_isAttacking)
        {
            if (coll.gameObject.tag == "Sword_Blade")
            {
                //Play death animation
                UpdateLives();
                _isAlive = false;
                //Destroy(this.gameObject);
                //Respawn Timer
            }
        }
    }

    IEnumerator AttackTimer()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(_attackAnimTime);
        _isAttacking = false;
    }

    void UpdateLives()
    {
        _lives--;
        livesText.text = "Player " + joystickNumber + " Lives : " + _lives.ToString();
        if(_lives < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
