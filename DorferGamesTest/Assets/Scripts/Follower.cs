using UnityEngine;

public class Follower : BaseFollow
{
    [SerializeField]
    private Transform head;
    
    private float baseDiffZ;

    protected override void Init()
    {
        baseDiffZ = Mathf.Abs(head.position.z - transform.position.z);
        base.Init();
    }
    protected override void UpdateActions()
    {
        if (head != null)
        {
            SetFollowPoint(head.position);
            Follow();
        }
    }
    protected override void Follow()
    {
        float diffX = pointToFollow.x - transform.position.x;
        float diffZ = (pointToFollow.z - transform.position.z);
        if (Mathf.Abs(diffX) > 1.0f)
            diffX = Mathf.Sign(diffX);
        if (diffZ < baseDiffZ)
            diffZ = 0;
        body.velocity = new Vector3(velocityX * diffX, 0.0f, velocityZ * diffZ);
    }
}
