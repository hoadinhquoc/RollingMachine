using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RollingNumber : MonoBehaviour {

	// Use this for initialization
	[SerializeField]TextMeshProUGUI textNumber;

	[SerializeField]float CHANGING_TIME = 0.5f;
	[SerializeField]int TOTAL_NUMBER = 10;
	
	float _timer = 0f;
	int _number = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		_timer += Time.deltaTime;

		if(_timer >= CHANGING_TIME)
		{
			_number = (_number + 1) % TOTAL_NUMBER;
			textNumber.text = _number.ToString();
			_timer = 0f;
		}
	}
}
