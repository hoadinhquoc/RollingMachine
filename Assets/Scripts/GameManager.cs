using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Banner BannerController;
    [SerializeField] Button RollingBtn;
    [SerializeField] Button LeftBtn;
    [SerializeField] Button RightBtn;
    bool _isBannerGoRight = false;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isBannerGoRight)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                BannerController.OnSpacePressed();
                _isBannerGoRight = true;
            }
        }
        else
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                if(RollingBtn.interactable)
                    RollingBtn.onClick.Invoke();
            }   
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if(LeftBtn.interactable)
                    LeftBtn.onClick.Invoke();
            }
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                if(RightBtn.interactable)
                    RightBtn.onClick.Invoke();
            }
        }
    }
}
