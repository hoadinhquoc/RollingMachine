using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour {
	[SerializeField] int minNumber = 200;
	[SerializeField] int maxNumber = 360;
	[SerializeField] float stopTime = 4f;
	[SerializeField] List<RollingNumber> rollingSlots;
	// Use this for initialization
	
	List<int> _numberPool = new List<int>();
	int _winningNumber = -1;
	List<int> _winningNumbers = new List<int>();
	float _timer = 0f;
	bool _isRolling = false;
	int _currentSlotIndex = 0;
	void Awake()
	{
		Reset();
	}
	// Update is called once per frame
	void Update () {
		if(!_isRolling) return;

		float dt = Time.deltaTime;
		_timer += dt;

		if(_timer > stopTime)
		{
			_timer = 0f;

			rollingSlots[_currentSlotIndex].StopRollingAt(_winningNumbers[_currentSlotIndex]);

			_currentSlotIndex++;

			if(_currentSlotIndex >= rollingSlots.Count)
			{
				_isRolling = false;
			}
		}

	}

	public void OnRollingPressed()
	{
		rollingSlots.ForEach(x=>x.StartRolling());

		int index = Random.Range(0, _numberPool.Count);
		_winningNumber =  _numberPool[index];
		_numberPool.RemoveAt(index);
		
		_winningNumbers.Clear();
		int tempWinningNumber = _winningNumber;
		
		for(int i = 0 ; i < rollingSlots.Count; i++)
		{
			int addNum = tempWinningNumber % 10;
			_winningNumbers.Insert(0, addNum);
			tempWinningNumber /= 10;
		}

		_timer = 0f;
		_currentSlotIndex = 0;
		_isRolling = true;
	}

	public void Reset()
	{
		_numberPool.Clear();

		for(int i = minNumber; i <= maxNumber; i++)
		{
			_numberPool.Add(i);
		}
		_isRolling = false;
		_timer = 0f;

		_currentSlotIndex = 0;
	}
}
