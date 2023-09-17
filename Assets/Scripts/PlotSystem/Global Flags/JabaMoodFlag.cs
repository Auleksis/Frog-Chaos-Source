using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JabaMoodFlag : AbstractFlag
{
    [SerializeField] int expectedValueGreaterThan = 1;
    public override void ProcessActionAndSetFlag(ACTION_MODE actionMode)
    {
        flagValue = roomLogic.jabaMood > expectedValueGreaterThan;
    }
}
