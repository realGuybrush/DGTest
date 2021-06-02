using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : BaseFollow
{
    public Transform head;
    private float baseDiffZ;

    internal override void Init()
    {
        baseDiffZ = Mathf.Abs(head.position.z - transform.position.z);
        base.Init();
    }
    internal override void UpdateActions()
    {
        if (head != null)
            SetFollowPoint(head.position);
        Follow();
    }
    internal override void Follow()
    {
        float diffX = pointToFollow.x - transform.position.x;
        float diffZ = (pointToFollow.z - transform.position.z)/baseDiffZ;
        if (Mathf.Abs(diffX) > 1.0f)
            diffX = Mathf.Sign(diffX);
        if (diffZ < baseDiffZ)
            diffZ = Mathf.Sign(diffZ);
        body.velocity = new Vector3(velocityX * diffX, 0.0f, velocityZ * diffZ);
    }
}
