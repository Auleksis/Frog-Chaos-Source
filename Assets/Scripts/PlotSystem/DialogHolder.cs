using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    List<DialogPoint> dialogPoints;
    void Start()
    {
        dialogPoints = new List<DialogPoint>();

        for(int i = 0; i < transform.childCount; i++)
        {
            dialogPoints.Add(transform.GetChild(i).GetComponent<DialogPoint>()); 
        }
    }

    public DialogPoint [] GetRandomPoints(int count, int currentChaosLevel)
    {
        HashSet<DialogPoint> result = new HashSet<DialogPoint>();
        int temp = 0;
        do
        {
            temp++;
            int index = Random.Range(0, dialogPoints.Count);
            if (dialogPoints[index].requiredChaosLevel <= currentChaosLevel && !dialogPoints[index].IsAchieved())
                result.Add(dialogPoints[index]);
        } while (result.Count < count && temp < 20);

        return result.ToArray();
    }
}
