using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlotMachine : MonoBehaviour {
	[SerializeField] UnityEvent EndRollingEvent;
	[SerializeField] int minNumber = 200;
	[SerializeField] int maxNumber = 360;

	[SerializeField] int minNumberGuest = 100;
	[SerializeField] int maxNumberGuest = 150;

	[SerializeField] List<RollingNumber> rollingSlots;
	// Use this for initialization
	
	List<int> _numberPool = new List<int>();
	int _winningNumber = -1;
	List<int> _winningNumbers = new List<int>();
	float _timer = 0f;
	bool _isRolling = false;
	int _currentSlotIndex = 0;
	int _totalRollingNumberEnd = 0;
	void Awake()
	{
		Reset();
	}

	public void OnRollingPressed(bool isGuest, Vector3 stopTime)
	{
		rollingSlots.ForEach(x=>x.StartRolling());

		_winningNumbers.Clear();
		int tempWinningNumber = GetWinningNumber(isGuest);
		
		for(int i = 0 ; i < rollingSlots.Count; i++)
		{
			int addNum = tempWinningNumber % 10;
			float time = 0f;
			if(i == 0) time = stopTime.z;
			if(i == 1) time = stopTime.y;
			if(i == 2) time = stopTime.x;
			
			rollingSlots[i].StopRollingAt(addNum, time);
			tempWinningNumber /= 10;
		}

		_totalRollingNumberEnd = 0;
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

	int GetWinningNumber(bool isGuest)
	{
		if(isGuest)
			return Random.Range(minNumberGuest, maxNumberGuest+1);

		int index = Random.Range(0, _numberPool.Count);
		_winningNumber =  _numberPool[index];
		_numberPool.RemoveAt(index);
		
		_winningNumbers.Clear();

		return _winningNumber;
	}

	public void OnRollingNumberEnd()
	{
		_totalRollingNumberEnd++;
		if(_totalRollingNumberEnd == rollingSlots.Count)
		{
			EndRollingEvent.Invoke();
		}
	}
}
