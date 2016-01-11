using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]public int                  _lives;                     //The players Lives
                    public  Text                livesText;                  //HUD / UI Text for players lives
                    private ControllerInput     _input;                     //Import Input class
                    private AnimStateHandler    _animator;                  //Import Animator class
                    private bool                _isAttacking;               //Checks if player is Attacking
                    private float               _attackAnimTime = 0.5f;    //Length of Attack Animation
                    private float               _attackInterval = 2f;       //End timer for cooldown
                    private float               _attackTimer = 0f;          //Start timer for cooldown
                    private bool                _isAlive;                   //Checks if player is alive    

    void Start()
    {
        _animator   = GetComponent<AnimStateHandler>();
        _input      = GetComponent<ControllerInput>();
    }

    void Update()
    {
        Attack();
        if (_attackTimer < _attackInterval)     //Cooldown timer for attacking
        {
            _attackTimer += Time.deltaTime;
        }
    }

    void Attack()
    {

        if (_input._xPressed && _attackTimer >= _attackInterval)
        {
            _attackTimer = 0f;
            StartCoroutine(AttackTimer());  //Starts timewindow of the animation so enemy can only be hit if the animation is playing
            Debug.Log("Attacking");
        }
        else if (_input._xPressed && _attackTimer < _attackInterval)
        {

            Debug.Log("Cooldown");
        }
    }

    IEnumerator AttackTimer()
    {
        _animator.AnimState(1);
        yield return new WaitForSeconds(_attackAnimTime);
        _animator.AnimState(0);
    }
}
