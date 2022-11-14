using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour
{
    public Animator nAnimator;

    public void Start()
    {
        nAnimator = GetComponent<Animator>();
    }

    public void SwitchOn()
    {
        nAnimator.SetTrigger("TrStart");
    }

    public void SwitchOff()
    {
        nAnimator.SetTrigger("TrEnd");
    }
}
