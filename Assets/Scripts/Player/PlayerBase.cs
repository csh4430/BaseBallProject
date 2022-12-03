using System.Collections;
using System.Collections.Generic;
using Unit;
using UnityEngine;

public class PlayerBase : UnitBase
{
    public PlayerState playerState;
    
    public void AddState(PlayerState state)
    {
        playerState |= state;
    }
    
    public bool CheckState(PlayerState state)
    {
        return (playerState & state) == state;
    }
    
    public void RemoveState(PlayerState state)
    {
        playerState &= ~state;
    }
}
