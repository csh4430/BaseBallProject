using System.Collections;
using System.Collections.Generic;
using Unit;
using UnityEngine;

public class PlayerAnimation : PlayerBehaviour
{
    private Animator animator;
    private int swingHash = Animator.StringToHash("Swing");
    private int pitchHash = Animator.StringToHash("Pitch");

    public override void Awake()
    {
        animator = Unit.GetComponent<Animator>();
    }

    public override void Start()
    {
        
    }

    public override void Update()
    {
        if(Player.CheckState(PlayerState.Swing))
        {
            PlaySwingAnimation();
            Player.RemoveState(PlayerState.Swing);
        }
    }

    public override void Destroy()
    {
        
    }
    
    public void PlaySwingAnimation()
    {
        animator.SetTrigger(swingHash);
    }
    
    public void PlayPitchAnimation()
    {
        animator.SetTrigger(pitchHash);
    }
}
