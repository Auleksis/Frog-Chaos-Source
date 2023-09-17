using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEventActivator : MonoBehaviour
{
    protected UIManager manager;
    private void Awake()
    {
        manager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public abstract bool IsAchieved();
}
