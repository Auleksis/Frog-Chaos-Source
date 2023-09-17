using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintEvent : MonoBehaviour
{
    [SerializeField] [Multiline] string message;

    UIManager uIManager;

    AbstractEventActivator activator;

    bool isAchieved = false;

    [SerializeField] PrintEvent[] mustBeAchievedBefore;

    AfterOldEffects[] afterOldEffects;

    void Start()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        activator = GetComponent<AbstractEventActivator>();
        afterOldEffects = GetComponents<AfterOldEffects>();
    }

    void Update()
    {
        if (!isAchieved)
        {
            foreach (PrintEvent e in mustBeAchievedBefore)
            {
                if (!e.isAchieved)
                    return;
            }

            if (activator.IsAchieved())
            {
                uIManager.GetMessageBox().AddToQueue(message);
                uIManager.GetMessageBox().Show();

                isAchieved = true;

                ApplyAfterEffects();
            }
        }
    }

    void ApplyAfterEffects()
    {
        foreach (AfterOldEffects effect in afterOldEffects)
            effect.Apply();
    }
}
