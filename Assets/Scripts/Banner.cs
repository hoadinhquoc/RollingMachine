using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Banner : MonoBehaviour
{
    [SerializeField]UnityEvent EndIntroEvent;
    public void OnBannerIntroFinished()
    {
        EndIntroEvent.Invoke();
    }
}
