using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour {

    public int  joystickNumber; //Assigns Controller number to player object
    //Face Buttons
    public bool _aPressed;
    public bool _xPressed;
    public bool _yPressed;
    public bool _bPressed;
    //Start and Back
    public bool _startPressed;
    public bool _backPressed;
    //Bumpers and Triggers
    public bool _rbPressed;
    public bool _rtPressed;
    public bool _lbPressed;
    public bool _ltPressed;
    //Analog Clicks
    public bool _rsPressed;
    public bool _lsPressed;
    //Analog Sticks
    //Left
    public bool _lsLeft;
    public bool _lsRight;
    public bool _lsUp;
    public bool _lsDown;
    //Right
    public bool _rsLeft;
    public bool _rsRight;
    public bool _rsUp;
    public bool _rsDown;
    //DPAD
    public bool _dPadUp;
    public bool _dPadDown;
    public bool _dPadLeft;
    public bool _dPadRight;
    
    void Start()
    {

    }

    void Update()
    {
        XboxInput();
    }

    public void XboxInput()
    {

        string joystickString = joystickNumber.ToString();

        if(Input.GetButtonDown(InputAxes.a + joystickString))  //A BUTTON
        {
            _aPressed = true;
        }
        else
        {
            _aPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.b + joystickString)) //B BUTTON
        {
            _bPressed = true;
        }
        else
        {
            _bPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.x + joystickString)) //X BUTTON
        {
            _xPressed = true;
        }
        else
        {
            _xPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.y + joystickString)) //Y BUTTON
        {
            _yPressed = true;
        }
        else
        {
            _yPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.lb + joystickString)) //LEFT BUMPER
        {
            _lbPressed = true;
        }
        else
        {
            _lbPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.rb + joystickString)) //RIGHT BUMPER
        {
            _rbPressed = true;
        }
        else
        {
            _rbPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.back + joystickString)) //BACK BUTTON
        {
            _backPressed = true;
        }
        else
        {
            _backPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.start + joystickString)) //START BUTTON
        {
            _startPressed = true;
        }
        else
        {
            _startPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.l3 + joystickString)) //L3 CLICK
        {
            _lsPressed = true;
        }
        else
        {
            _lsPressed = false;
        }

        if (Input.GetButtonDown(InputAxes.r3 + joystickString)) //R3 CLICK
        {
            _rsPressed = true;
        }
        else
        {
            _rsPressed = false;
        }

        if (Input.GetAxis(InputAxes.rt + joystickString)>0) //RIGHT TRIGGER
        {
            _rtPressed = true;
        }
        else
        {
            _rtPressed = false;
        }

        if (Input.GetAxis(InputAxes.lt + joystickString)>0) //LEFT TRIGGER
        {
            _ltPressed = true;
            Debug.Log("LT");
        }
        else
        {
            _ltPressed = false;
        }

        //ANALOG STICKS
        float leftX = Input.GetAxis(InputAxes.leftX + joystickString); //LEFT X

        if(leftX > 0)
        {
            _lsRight = true;
        }
        else
        {
            _lsRight = false;
        }
        
        if (leftX < 0)
        {
            _lsLeft = true;
        }
        else
        {
            _lsLeft = false;
        }

        float leftY = Input.GetAxis(InputAxes.leftY + joystickString); //LEFT Y

        if(leftY > 0)
        {
            _lsDown = true;
        }
        else
        {
            _lsDown = false;
        }
        
        if(leftY < 0)
        {
            _lsUp = true;
        }else
        {
            _lsUp = false;  
        }
        
        float rightX = Input.GetAxis(InputAxes.rightX + joystickString); // RIGHT X

        if(rightX > 0)
        {
            _rsRight = true;
        }
        else
        {
            _rsRight = false;
        }
        
        if (rightX < 0)
        {
            _rsLeft = true;
        }
        else
        {
            _rsLeft = false;
        }

        float rightY = Input.GetAxis(InputAxes.rightY + joystickString); //Right Y

        if(rightY > 0)
        {
            _rsDown = true;
        }
        else
        {
            _rsDown = false;
        }

        if(rightY < 0)
        {
            _rsUp = true;
        }
        else
        {
            _rsUp = false;
        }

        //DPAD
        float dPadX = Input.GetAxis(InputAxes.dpadX ); //Dpad X

        if(dPadX < 0)
        {
            _dPadLeft = true;
        }
        else
        {
            _dPadLeft = false;
        }

        if (dPadX > 0)
        {
            _dPadRight = true;
        }
        else
        {
            _dPadRight = false;
        }

        float dPadY = Input.GetAxis(InputAxes.dpadY);

        if (dPadY < 0)
        {
            _dPadDown = true;
        }
        else
        {
            _dPadDown = false;
        }

        if (dPadY > 0)
        {
            _dPadUp = true;
        }
        else
        {
            _dPadDown = false;
        }
    }
}
