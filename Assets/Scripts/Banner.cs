using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Banner : MonoBehaviour
{
    [SerializeField]Animator BannerAnimator;
    [SerializeField]UnityEvent EndIntroEvent;
    [SerializeField]UnityEvent EndGoRightEvent;

    public void OnBannerIntroFinished()
    {
        EndIntroEvent.Invoke();
    }
    public void OnBannerGoRightEnd()
    {
        EndGoRightEvent.Invoke();
    }

    public void OnSpacePressed()
    {
        BannerAnimator.Play("BannerGoLeft");
    }
}
