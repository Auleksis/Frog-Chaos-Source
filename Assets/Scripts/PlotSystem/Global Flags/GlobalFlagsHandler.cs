using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlagsHandler : MonoBehaviour
{
    List<AbstractFlag> globalFlags;

    private void Start()
    {
        globalFlags = new List<AbstractFlag>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            globalFlags.Add(child.GetComponent<AbstractFlag>());
        }
    }

    public void ProcessAction(ACTION_MODE action_mode)
    {
        foreach (AbstractFlag flag in globalFlags)
        {
            flag.ProcessActionAndSetFlag(action_mode);
        }
    }
}
