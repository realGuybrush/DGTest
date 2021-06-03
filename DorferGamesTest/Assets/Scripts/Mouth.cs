using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public float coneWidth;
    public LayerMask edibles;
    private Physics p;
    private RaycastHit[] coneHits;

    void Update()
    {
        CheckConeInFront();
    }

    void CheckConeInFront()
    {
        coneHits = p.ConeCastAll(transform.position, 5f, transform.forward, 2f, coneWidth, edibles);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (coneHits.Length > 0)
        {
            for (int i = 0; i < coneHits.Length; i++)
            {
                if (coneHits[i].collider?.gameObject == collision.gameObject)
                {
                    Consumable collisionConsumable = collision.gameObject.GetComponent<Consumable>();
                    if ((collisionConsumable!=null)&&
                        ((collision.gameObject.GetComponent<Renderer>().material.color == this.gameObject.GetComponent<Renderer>().material.color)
                        ||
                        (collisionConsumable.type == ConsumableType.Crystal)))
                    {
                        collisionConsumable.GetEaten();
                    }
                    else
                    {
                        this.GetComponent<Snake>().Die();
                    }
                }
            }
        }
    }
}
