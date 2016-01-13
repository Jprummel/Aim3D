using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //Script Imports
                    private ControllerInput     _input;        //Input Class import
                    private PlayerRespawn       _respawn;      //Respawn class import to check if player is alive or not 
    //Speed
    [SerializeField]private float               _movementSpeed;
    [SerializeField]private float               _rotationSpeed;
    [SerializeField]private float               _teleportDistance;
    //Jumping
    [SerializeField]private float               _jumpHeight;
    [SerializeField]private int                 _maxJumps;     //Sets the max amount of jumps a player can make
                    private bool                _canJump;      //checks if player can jump
                    private int                 _jumpCount;    //Amount of times jumped
    
    //Terrain
                    private bool                _isGrounded;   //Checks if player is on the ground
                    private bool                _isInAir;      //Checks if the player has jumped / is in the air
    //Particle
    [SerializeField]private GameObject          _smokeCloud;   //Smoke cloud for teleporting

    void Start()
    {
      //_input.joystickNumber = controllerNumber;
        _input      = GetComponent<ControllerInput>();
        _respawn    = GetComponent<PlayerRespawn>();
    }

    void Update()
    {
        if (_respawn.IsAlive()) //Enables Movement functions if the player is alive
        {
            Movement();
            Rotation();
            AerialMovement();
        }
    }

    public void Movement()
    {
            if (_input._lsUp)       //Moves forward
            {
                transform.Translate(Vector3.forward * Time.deltaTime * _movementSpeed);
            }
            if (_input._lsDown)     //Moves backward (Backpeddling)
            {
                transform.Translate(-Vector3.forward * Time.deltaTime * _movementSpeed / 2f);   //Backpeddling has decreased movement speed
            }
            if (_input._lsRight)    //Moves right (strafe)
            {
                transform.Translate(-Vector3.left * Time.deltaTime * _movementSpeed);
            }
            if (_input._lsLeft)     //Moves left (strafe)
            {
                transform.Translate(Vector3.left * Time.deltaTime * _movementSpeed);
            }
    }

    public void Rotation()
    {
        //Rotates the player on the Y Axis
        if (_input._rsLeft)        //Rotates Left
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * _rotationSpeed);
        }
        if (_input._rsRight)       //Rotates Right
        {
            transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);
        }
    }

    void AerialMovement()
    {
        if (_jumpCount < _maxJumps) //Checks if the amount of jumps the player made is below the max allowed jumps
        {
            if (_input._aPressed)
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0, _jumpHeight, 0);
                _jumpCount++;
                _isInAir = true;
            }
        }

        if (_isInAir)               // Checks if player is in the air
        {
            if (_input._lbPressed)  //Teleports left
            {
                Instantiate(_smokeCloud, transform.position, Quaternion.identity);
                transform.Translate(Vector3.left * Time.deltaTime * _teleportDistance);
            }
            if (_input._rbPressed)  //Teleports right
            {
                Instantiate(_smokeCloud, transform.position, Quaternion.identity);
                transform.Translate(Vector3.right * Time.deltaTime * _teleportDistance);
            }
        }
    }

    public int JumpCountReset()
    {
       return _jumpCount = 0;       //Sets the jump count back to 0 allowing the player to jump again
    }

    public bool NotInAir()
    {
        return _isInAir = false;
    }
}
