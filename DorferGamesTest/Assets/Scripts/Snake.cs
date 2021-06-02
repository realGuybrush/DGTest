using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : BaseFollow
{
    public LayerMask land;
    public Camera mainCamera;

    internal override void Init()
    {
        base.Init();
        follow = false;
        //gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
    }

    internal override void UpdateActions()
    {
        //CheckTouch();
        CheckClicked();
        if (follow)
        {
            //CastRayToTouchPoint();
            CastRayToClickPoint();
        }
        Follow();
    }

    void CheckTouch()
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

    public void CheckClicked()
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

    void CastRayToClickPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        RaycastHit[] hit = Physics.RaycastAll(ray, 100f, land);
        if (hit.Length > 0)
            SetFollowPoint(hit[0].point);
    }

    void CastRayToTouchPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f));
        RaycastHit[] hit = Physics.RaycastAll(ray, 100f, land);
        if (hit.Length > 0)
            SetFollowPoint(hit[0].point);
    }
}
