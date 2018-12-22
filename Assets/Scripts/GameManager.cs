using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] Button RollingBtn;
    [SerializeField] Button LeftBtn;
    [SerializeField] Button RightBtn;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(StartButton.gameObject.activeSelf)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                StartButton.onClick.Invoke();
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
