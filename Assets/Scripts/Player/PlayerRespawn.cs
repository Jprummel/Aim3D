using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {
    [SerializeField]private Transform[]         _respawnPoint;
                    private AnimStateHandler    _animator;
                    private PlayerHealth        _healthController;
                    private bool                _isAlive;
   

	// Use this for initialization
	void Start () {
        _healthController   = GetComponent<PlayerHealth>();
        _animator           = GetComponent<AnimStateHandler>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator Respawn()
    {
        _isAlive = false;
        _healthController.ChangeHealth(-1);
        _animator.AnimState(2);
        yield return new WaitForSeconds(6);
        _animator.AnimState(0);
        transform.position = _respawnPoint[Random.Range(0,_respawnPoint.Length -1)].position; //Gets a random spawn point from the array and lets player respawn there
        _isAlive = true;
    }

    public bool Alive()
    {
        return _isAlive;
    }

}
