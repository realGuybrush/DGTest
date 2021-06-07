using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public EdibleCounter counter;
    public float coneWidth;
    public LayerMask edibles;
    public Animator anim;
    private Physics p;
    private RaycastHit[] coneHits;
    public bool fever = false;

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
        bool eating = false;
        if (coneHits.Length > 0)
        {
            for (int i = 0; i < coneHits.Length; i++)
            {
                if (coneHits[i].collider?.gameObject == collision.gameObject)
                {
                    Consumable collisionConsumable = collision.gameObject.GetComponent<Consumable>();
                    if (fever||
                        ((collisionConsumable!=null)&&
                        ((collision.gameObject.GetComponent<Renderer>().material.color == this.gameObject.GetComponent<Renderer>().material.color)
                        ||
                        (collisionConsumable.type == ConsumableType.Crystal))))
                    {
                        collisionConsumable.GetEaten();
                        counter.Increase(collisionConsumable.type);
                        eating = true;
                    }
                    else
                    {
                        this.GetComponent<Snake>().Die();
                    }
                }
            }
        }
        if (eating)
            Eat();
    }

    async void Eat()
    {
        anim.SetBool("Eating", true);
        await Task.Delay(500);
        anim.SetBool("Eating", false);
    }

}
