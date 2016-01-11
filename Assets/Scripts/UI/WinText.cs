using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinText : MonoBehaviour {

    public GameObject _player1;
    public GameObject _player2;
    private Text _winText;
    

	// Use this for initialization
	void Start () {
        _player1 = GameObject.Find("Player1");
        _player2 = GameObject.Find("Player2");
        _winText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(!_player1)
        {
            _winText.text = "Player 2 Wins!";
        }else if(!_player2)
        {
            _winText.text = "Player 1 Wins!";
        }
	}
}
