using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {
    
    private PlayerMovement      _movement;  //Import Movement script for Jumpcount resets and aerialmovement
    private PlayerAttack        _attack;    //Import Attack script
    private PlayerHealth        _health;    //Import Player Health script
    private PlayerRespawn       _respawn;  //Import Animatior script

    void Start()
    {
        _movement   = GetComponent<PlayerMovement>();
        _attack     = GetComponent<PlayerAttack>();
        _health     = GetComponent<PlayerHealth>();
        _respawn    = GetComponent<PlayerRespawn>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _movement.JumpCountReset();
            _movement.NotInAir();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.tag == "Sword_Blade")
        {
                StartCoroutine(_respawn.Respawn());
        }
    }
}
