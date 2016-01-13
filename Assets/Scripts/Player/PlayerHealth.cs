using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]private int             _startHealth;
                    private int _currentHealth;
                    private ControllerInput _input;
                    public  Text            livesText;

	void Start () {

        _input          = GetComponent<ControllerInput>();
        _currentHealth  = _startHealth;                                                                     //Sets players currenthealth to his max health at the start
        livesText       = GameObject.Find("Player" + _input.joystickNumber + "Lives").GetComponent<Text>();
        livesText.text  = "Player " + _input.joystickNumber + " Lives : " + _currentHealth.ToString();      //Starts off showing the players full life count
	}
	
	void Update () {
        StartCoroutine(Death());
	}

    public void ChangeHealth(int value)
    {
        _currentHealth += value;
        UpdateLiveText();
    }
    public int GetHealth()
    {
        return _currentHealth;
    }

    public void UpdateLiveText()
    {
        livesText.text = "Player " + _input.joystickNumber + " Lives : " + _currentHealth.ToString();
    }

    IEnumerator Death()
    {
        if(_currentHealth <= 0)
        {
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }
}
