using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unit;

public class HitterBase : PlayerBase
{
    protected override void OnEnable()
    {
        AddBehaviour<PlayerAnimation>();
        AddBehaviour<HitterSwing>();
        base.OnEnable();
    }
}
