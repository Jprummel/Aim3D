using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

    //Makes it able to set a target
    [SerializeField]private float           _cameraSensitivityX;
    [SerializeField]private float           _cameraSensitivityY;
    [SerializeField]private float           _minX;
    [SerializeField]private float           _maxX;                
                    private ControllerInput _input;
                    private PlayerRespawn   _respawn;
                    private Vector3         _offset;
                    private float           _rotationX;
                    private float           _rotationY;
                    public  Transform       target;
    
   

    void Start()
    {
        _offset     = target.position - this.transform.position;
        _input      = GetComponent<ControllerInput>();
        _respawn    = GetComponentInParent<PlayerRespawn>();
    }

    void LateUpdate()
    {
        //makes the object that this script is on follow a target
        this.transform.position = target.position - _offset;
        if (_respawn.IsAlive())
        {
            CamRotation();
        }
    }



    void CamRotation()
    {
        _rotationX = Mathf.Clamp(_rotationX, _minX, _maxX);
        this.transform.rotation = target.rotation;
        
        this.transform.eulerAngles = new Vector3(_rotationX, _rotationY );

        if (_input._rsLeft)        //Rotates Left
        {
            _rotationY -= Time.deltaTime * _cameraSensitivityY;
        }
        if (_input._rsRight)       //Rotates Right
        {
            _rotationY += Time.deltaTime * _cameraSensitivityY;
        }
        if (_input._rsUp)          //Rotates up
        {
            _rotationX -= Time.deltaTime * _cameraSensitivityX;
        }
        if (_input._rsDown)        //Rotates Down
        {
            _rotationX += Time.deltaTime * _cameraSensitivityX;
        }
    }

    Quaternion  CalculateRotation()
    {
        return target.rotation;
    }
}
