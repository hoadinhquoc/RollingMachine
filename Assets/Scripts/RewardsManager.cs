using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsManager : MonoBehaviour
{
    [SerializeField] Image RewardImage;
    [SerializeField] List<Sprite> RewardsSpriteList;
    [SerializeField] Animator RewardAnimator;

    //Private field
    int _rewardIndex = 0;
    void Awake()
    {
        SetReward(0);
    }
    void SetReward(int index)
    {
        if(index < 0) index = 0;
        if(index >= RewardsSpriteList.Count) index = RewardsSpriteList.Count -1;

        RewardImage.sprite = RewardsSpriteList[index];
        _rewardIndex = index;
        RewardAnimator.Play(index == (RewardsSpriteList.Count -1) ? "ZoomOutMax" : "ZoomOut");
    }

    public void SetNextReward()
    {
        SetReward(++_rewardIndex);
    }
    public void SetPreviousReward()
    {
        SetReward(--_rewardIndex);
    }
    
}
