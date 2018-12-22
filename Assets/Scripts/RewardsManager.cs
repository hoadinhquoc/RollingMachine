using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsManager : MonoBehaviour
{
    [System.Serializable]
    class RewardInfo
    {
        public Sprite rewardSprite;
        public Vector3 stopTime;
    }
    [SerializeField] Image RewardImage;
    [SerializeField] List<RewardInfo> RewardsInfoList;
    [SerializeField] Animator RewardAnimator;
    [SerializeField] SlotMachine slotMachine;
    //Private field
    int _rewardIndex = 0;
    void OnEnable()
    {
        //SetReward(0);
    }
    public void SetReward(int index)
    {
        if(index < 0) index = 0;
        if(index >= RewardsInfoList.Count) index = RewardsInfoList.Count -1;

        RewardImage.sprite = RewardsInfoList[index].rewardSprite;
        _rewardIndex = index;
        RewardAnimator.Play(index == (RewardsInfoList.Count -1) ? "ZoomOutMax" : "ZoomOut");
    }

    public void SetNextReward()
    {
        SetReward(++_rewardIndex);
    }
    public void SetPreviousReward()
    {
        SetReward(--_rewardIndex);
    }

    public void OnRollingPressed()
    {
        slotMachine.OnRollingPressed(_rewardIndex == 0, RewardsInfoList[_rewardIndex].stopTime);
    }
    
}
