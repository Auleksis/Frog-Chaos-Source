using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTile : AfterOldEffects
{
    [SerializeField] float flashCount = 6;
    [SerializeField] float flashTimeSeconds = 0.3f;
    [SerializeField] GameObject highlightPlace;

    public override void Apply()
    {
        StartCoroutine(HightLight());
    }

    IEnumerator HightLight()
    {
        for(int i = 0; i < flashCount; i++)
        {
            roomLogic.HighlightTile(highlightPlace.transform.position);
            yield return new WaitForSeconds(flashTimeSeconds);
            roomLogic.DehighlightTile(highlightPlace.transform.position);
            yield return new WaitForSeconds(flashTimeSeconds);
        }
    }
}
