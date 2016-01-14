using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
                    private PlayerRespawn       _respawn;                   //Import respawn class to check if player is alive
                    private ControllerInput     _input;                     //Import Input class
                    private AnimStateHandler    _animator;                  //Import Animator class
                    private bool                _isAttacking;               //Checks if player is Attacking
                    private float               _attackAnimTime = 0.5f;     //Length of Attack Animation
                    private float               _attackInterval = 2f;       //End timer for cooldown
                    private float               _attackTimer = 0f;          //Start timer for cooldown

    void Start()
    {
        _animator       = GetComponent<AnimStateHandler>();
        _input          = GetComponent<ControllerInput>();
        _respawn        = GetComponent<PlayerRespawn>();
    }

    void Update()
    {
        if (_respawn.IsAlive())
        {
            Attack();
        }
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
    }

    IEnumerator AttackTimer()
    {
        _animator.AnimState(1);
        _isAttacking = true;
        yield return new WaitForSeconds(_attackAnimTime);
        _animator.AnimState(0);
        _isAttacking = false;
    }

    public bool Attacking()
    {
        return _isAttacking;
    }
}
