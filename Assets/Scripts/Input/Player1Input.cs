using UnityEngine;
using System.Collections;

public class Player1Input : MonoBehaviour {

    //Face Buttons
    private bool _aPressed;
    private bool _xPressed;
    private bool _yPressed;
    private bool _bPressed;
    //Start and Back
    private bool _startPressed;
    private bool _backPressed;
    //Bumpers and Triggers
    private bool _rbPressed;
    private bool _rtPressed;
    private bool _lbPressed;
    private bool _ltPressed;
    //Analog Clicks
    private bool _rsPressed;
    private bool _lsPressed;
    //Analog Sticks
    //Left
    private bool _lsLeft;
    private bool _lsRight;
    private bool _lsUp;
    private bool _lsDown;
    //Right
    private bool _rsLeft;
    private bool _rsRight;
    private bool _rsUp;
    private bool _rsDown;

    void FixedUpdate()
    {
        ControllerInput();
    }

    public void ControllerInput()
    {
        if(Input.GetKey(KeyCode.Joystick1Button0))  //A BUTTON
        {
            _aPressed = true;
            Debug.Log("APressed");
        }else
        {
            _aPressed = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button1)) //B BUTTON
        {
            _bPressed = true;
            Debug.Log("BPressed");
        }else
        {
            _bPressed = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button2)) //X BUTTON
        {
            _xPressed = true;
            Debug.Log("XPressed");
        }
        else
        {
            _xPressed = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button3)) //Y BUTTON
        {
            _yPressed = true;
            Debug.Log("YPressed");
        }
        else
        {
            _yPressed = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button4)) //LEFT BUMPER
        {
            _lbPressed = true;
            Debug.Log("Left Bumper Pressed");
        }
        else
        {
            _lbPressed = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button5)) //RIGHT BUMPER
        {
            _rbPressed = true;
            Debug.Log("Right Bumper Pressed");
        }
        else
        {
            _bPressed = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button6)) //BACK BUTTON
        {
            _backPressed = true;
            Debug.Log("Back Pressed");
        }
        else
        {
            _backPressed = false;
        }

        if (Input.GetKey(KeyCode.Joystick1Button7)) //START BUTTON
        {
            _startPressed = true;
            Debug.Log("Start Pressed");
        }
        else
        {
            _startPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button8)) //L3 CLICK
        {
            _lsPressed = true;
            Debug.Log("Left Stick Pressed");
        }
        else
        {
            _lsPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button9)) //R3 CLICK
        {
            _rsPressed = true;
            Debug.Log("Right Stick Pressed");
        }
        else
        {
            _rsPressed = false;
        }

        if (Input.GetAxis("Xbox_RT")>0)
        {
            _rtPressed = true;
            Debug.Log("Right Trigger Pressed");
        }
        else
        {
            _rtPressed = false;
        }

        if (Input.GetAxis("Xbox_LT")>0)
        {
            _ltPressed = true;
            Debug.Log("Left Trigger Pressed");
        }
        else
        {
            _ltPressed = false;
        }

        //ANALOG STICKS
        float left_X = Input.GetAxis("Xbox_LeftStick_X_1"); //LEFT X

        if(left_X > 0)
        {
            Debug.Log("L Right");
        }else if (left_X < 0)
        {
            Debug.Log("L Left");
        }

        float left_Y = Input.GetAxis("Xbox_LeftStick_Y_1"); //LEFT Y

        if(left_Y > 0)
        {
            Debug.Log("L Down");
        }else if(left_Y < 0)
        {
            Debug.Log("L Up");
        }
        
        float right_X = Input.GetAxis("Xbox_RightStick_X_1"); // RIGHT X

        if(right_X > 0)
        {
            _rsRight = true;
            Debug.Log("R Right");
        }else if (right_X < 0)
        {
            _rsLeft = true;
            Debug.Log("R Left");
        }

        float right_Y = Input.GetAxis("Xbox_RightStick_Y_1"); //Right Y

        if(right_Y > 0)
        {
            _rsDown = true;
            Debug.Log("R Down");
        }else if(right_Y < 0)
        {
            _rsUp = true;
            Debug.Log("R Up");
        }
    }
}
