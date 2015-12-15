using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
    private float timeStamp;
    public float dood;
	// Use this for initialization
	void Start () {
        timeStamp = Time.time + dood;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeStamp <= Time.time)
        {
            Destroy(this.gameObject);
        }
	}
}
