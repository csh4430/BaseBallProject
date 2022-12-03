using System.Collections;
using System.Collections.Generic;
using Unit;
using UnityEngine;

public class HitterSwing : PlayerBehaviour
{
    private GameObject _battingAimObject;
    private Vector3 _originalMousePoint;
    
    private Vector3 _originalAimPoint;
    public override void Awake()
    {
        
    }

    public override void Start()
    {
        _battingAimObject = GameObject.Find("BattingAim");
    }

    public override void Update()
    {
        Vector3 mousPos = Input.mousePosition;
        mousPos.z = 1;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousPos);
            _originalAimPoint = _battingAimObject.transform.position;
            _originalMousePoint = mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mousPos); 
            Vector3 dir = _originalMousePoint - mousePosition;
            Debug.Log(mousePosition);
            _battingAimObject.transform.position = _originalAimPoint - dir;
        }
        if (Input.GetMouseButtonUp(0))
        {            
            Swing();
        }
    }

    public override void Destroy()
    {
        
    }

    public void Swing()
    {
        Player.AddState(PlayerState.Swing);
    }
}
