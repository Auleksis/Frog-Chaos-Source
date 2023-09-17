using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    List<EventPoint> eventPoints;

    private void Start()
    {
        eventPoints = new List<EventPoint>();

        for(int i = 0; i < transform.childCount; i++) 
        {
            Transform child = transform.GetChild(i);
            eventPoints.Add(child.GetComponent<EventPoint>());
        }
    }

    public EventPoint[] GetRandomEvents(int chaos_level)
    {
        HashSet<EventPoint> events = new HashSet<EventPoint>();
        int temp = 0;
        do
        {
            int index = Random.Range(0, eventPoints.Count);
            events.Add(eventPoints[index]);
            temp++;
        } while (events.Count < chaos_level && temp < 20);

        return eventPoints.ToArray();
    }
}
