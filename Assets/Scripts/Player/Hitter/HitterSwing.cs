using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unit;
using UnityEngine;

public class HitterSwing : PlayerBehaviour
{
    private Sequence seq;
    private GameObject _battingAimObject;
    private GameObject _batObject;
    private Vector3 _originalMousePoint;
    private Vector3 _originalAimPoint;
    public override void Awake()
    {
        
    }

    public override void Start()
    {
        _batObject = GameObject.Find("Bat");
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
        seq = DOTween.Sequence();
        seq.AppendInterval(1f);
        seq.Append(_batObject.transform.DOLocalRotate(new Vector3(0, 0, 90 * (_battingAimObject.transform.localPosition.y + 0.5f)), 1f));
        seq.Append(_batObject.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f));
        seq.AppendCallback(() =>
        {
            seq.Kill();
        });
    }
}
