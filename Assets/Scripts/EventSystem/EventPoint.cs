using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPoint : MonoBehaviour
{
    AfterEffect[] afterEffects;

    private void Start()
    {
        afterEffects = GetComponents<AfterEffect>();
    }

    public void Happen()
    {
        foreach(AfterEffect effect in afterEffects)
        {
            effect.Apply();
        }
    }
}
