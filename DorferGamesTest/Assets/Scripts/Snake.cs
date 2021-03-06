using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Snake : BaseFollow
{
    public LayerMask land;
    public Camera mainCamera;
    public Mouth mouth;
    private bool fever = false;
    public UIManager ui;

    internal override void Init()
    {
        base.Init();
        follow = false;
    }

    internal override void UpdateActions()
    {
        if (fever)
        {
            SetFollowPoint(new Vector3(0, 0, 0));
        }
        else
        {
            //CheckClicked();
            CheckTouch();
            if (follow)
            {
                CastRayToTouchPoint();
                //CastRayToClickPoint();
            }
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

    void CastRayToTouchPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0f));
        RaycastHit[] hit = Physics.RaycastAll(ray, 100f, land);
        if (hit.Length > 0)
            SetFollowPoint(hit[0].point);
    }

    void CastRayToClickPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        RaycastHit[] hit = Physics.RaycastAll(ray, 100f, land);
        if (hit.Length > 0)
            SetFollowPoint(hit[0].point);
    }

    public async void Fever()
    {
        fever = true;
        mouth.fever = true;
        velocityX *= 3;
        velocityZ *= 3;
        await Task.Delay(5000);
        fever = false;
        mouth.fever = false;
        velocityX /= 3;
        velocityZ /= 3;
        mouth.counter.DropCounter(ConsumableType.Crystal);
    }
    public void Live()
    {
        alive = true;
    }

    public void Die(bool lose=true)
    {
        alive = false;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        if (lose)
        {
            ui.SetMessage("Dead.");
        }
        else
        {
            ui.SetMessage("Victory!");
        }
        ui.Restart();
    }
}
