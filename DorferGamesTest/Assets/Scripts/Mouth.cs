using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public EdibleCounter counter;
    public Animator anim;
    public ConeChecker checker;
    public bool fever = false;

    public void OnTriggerEnter(Collider collider)
    {
        bool eating = false;
        if (checker.coneHits.Count > 0)
        {
            for (int i = 0; i < checker.coneHits.Count; i++)
            {
                if (checker.coneHits[i]?.gameObject == collider.gameObject)
                {
                    Consumable collisionConsumable = collider.gameObject.GetComponent<Consumable>();
                    if (fever||
                        ((collisionConsumable!=null)&&
                        ((collider.gameObject.GetComponent<Renderer>().material.color == this.gameObject.GetComponent<Renderer>().material.color)
                        ||
                        (collisionConsumable.type == ConsumableType.Crystal))))
                    {
                        collisionConsumable.GetEaten();
                        counter.Increase(collisionConsumable.type);
                        eating = true;
                        checker.coneHits.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        this.GetComponent<Snake>().Die();
                    }
                }
            }
        }
        if (eating && (anim != null))
            Eat();
    }

    async void Eat()
    {
        anim.SetBool("Eating", true);
        await Task.Delay(500);
        anim.SetBool("Eating", false);
    }

}
