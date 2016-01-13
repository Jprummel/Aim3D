using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {

    [SerializeField]private GameObject      _bloodSplatter; //Blood Particle
                    private PlayerMovement  _movement;      //Import Movement script for Jumpcount resets and aerialmovement
                    private PlayerRespawn   _respawn;       //Import Animatior script
    

    void Start()
    {
        _movement   = GetComponent<PlayerMovement>();
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
            PlayerAttack enemySword = coll.gameObject.GetComponentInParent<PlayerAttack>();
            if (enemySword.Attacking()) //Checks if other player is attacking or not
            {
                GameObject newBloodSplatter = Instantiate(_bloodSplatter, transform.position, Quaternion.identity) as GameObject; //Spawns blood particle
                newBloodSplatter.transform.parent = transform;
                newBloodSplatter.transform.localPosition = new Vector3(0, 1.1f, 0); //Positions blood particle
                StartCoroutine(_respawn.Respawn());
            }
        }
    }
}
