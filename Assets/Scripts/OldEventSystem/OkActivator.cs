using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkActivator : AbstractEventActivator
{
    public override bool IsAchieved()
    {
        if (manager.GetMessageBox().IsOkPressed())
            return true;
        return false;
    }
}
