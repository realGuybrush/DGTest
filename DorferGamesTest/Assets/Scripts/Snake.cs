using System;
using UnityEngine;

public class Snake : BaseFollow
{
    [SerializeField]
    private LayerMask land;
    
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float feverVelocityBonus = 3f;
    private bool fever = false;
    
    public Action<bool> OnDie = delegate {  };

    

    private void OnCollisionEnter(Collision other)
    {
        if(!fever)
            HitObstacle(false);
    }
    
    protected override void Init()
    {
        base.Init();
        follow = false;
    }

    protected override void UpdateActions()
    {
        if (fever)
        {
            SetFollowPoint(new Vector3(0, 0, 0));
        }
        else
        {
#if UNITY_ANDROID
            CheckTouch();
            if (follow)
            {
                CastRayToTouchPoint();
            }
#endif
#if !UNITY_ANDROID            
            CheckClicked();
            if (follow)
            {
                CastRayToClickPoint();
            }
#endif
        }
        Follow();
    }

    private void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            follow = true;
        }
        if (Input.touchCount == 0)
        {
            follow = false;
        }
    }

    private void CheckClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            follow = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            follow = false;
        }
    }

    private void CastRayToTouchPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f));
        RaycastHit[] hit = Physics.RaycastAll(ray, 100f, land);
        if (hit.Length > 0)
            SetFollowPoint(hit[0].point);
    }

    private void CastRayToClickPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        RaycastHit[] hit = Physics.RaycastAll(ray, 100f, land);
        if (hit.Length > 0)
            SetFollowPoint(hit[0].point);
    }

    public void StartFever()
    {
        fever = true;
        velocityX *= feverVelocityBonus;
        velocityZ *= feverVelocityBonus;
    }

    public void EndFever()
    {
        fever = false;
        velocityX /= feverVelocityBonus;
        velocityZ /= feverVelocityBonus;
    }

    public void Live()
    {
        alive = true;
    }

    public void HitObstacle(bool win)
    {
        alive = false;
        body.velocity = Vector3.zero;
        OnDie?.Invoke(win);
    }

    public bool IsInFever => fever;
}
