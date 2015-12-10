using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour {

    //Face Buttons
    protected bool _aPressed;
    protected bool _xPressed;
    protected bool _yPressed;
    protected bool _bPressed;
    //Start and Back
    protected bool _startPressed;
    protected bool _backPressed;
    //Bumpers and Triggers
    protected bool _rbPressed;
    protected bool _rtPressed;
    protected bool _lbPressed;
    protected bool _ltPressed;
    //Analog Clicks
    protected bool _rsPressed;
    protected bool _lsPressed;
    //Analog Sticks
    //Left
    protected bool _lsLeft;
    protected bool _lsRight;
    protected bool _lsUp;
    protected bool _lsDown;
    //Right
    protected bool _rsLeft;
    protected bool _rsRight;
    protected bool _rsUp;
    protected bool _rsDown;
    //DPAD
    protected bool _dPadUp;
    protected bool _dPadDown;
    protected bool _dPadLeft;
    protected bool _dPadRight;

    public int joystickNumber;

    void FixedUpdate()
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

        if (Input.GetAxis(InputAxes.rt + joystickString)>0) //RIGHT TRIGGER (NOT WORKING YET)
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
