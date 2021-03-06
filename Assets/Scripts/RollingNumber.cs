﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class RollingNumber : MonoBehaviour {

	// Use this for initialization
	[SerializeField]TextMeshProUGUI textNumber;

	[SerializeField]float CHANGING_TIME = 0.5f;
	[SerializeField]int START_NUMBER = 0;
	[SerializeField]int TOTAL_NUMBER = 10;

	[SerializeField]List<Sprite> numberSprites;
	[SerializeField]Image numberImage;
	[SerializeField]UnityEvent ChangeNumberEvent;
	[SerializeField]UnityEvent EndEvent;
	
	float _timer = 0f;
	float _timeToStop = 0f;
	int _number = 0;
	bool _isRolling = false;
	int _targetNumber = -1;
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!_isRolling) return;

		_timer += Time.deltaTime;
		_timeToStop -= Time.deltaTime;

		if(_timer >= CHANGING_TIME)
		{
			_number = (_number + 1) % TOTAL_NUMBER + START_NUMBER;
			textNumber.text = _number.ToString();
			_timer = 0f;

			numberImage.sprite = numberSprites[_number];
			ChangeNumberEvent.Invoke();
			if(_targetNumber != -1 && _timeToStop <= 0f)
			{
				if(_number == _targetNumber)
				{
					_isRolling = false;
					_targetNumber = -1;
					EndEvent.Invoke();
				}
			}
		}
	}

	public void StartRolling()
	{
		_timer = 0f;
		_number = 0;

		_isRolling = true;
	}

	public void StopRollingAt(int targetNumber, float timeToStop)
	{
		_targetNumber = targetNumber;
		_timeToStop = timeToStop;
	}
}
