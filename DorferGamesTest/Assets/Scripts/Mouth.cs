using System.Threading.Tasks;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    [SerializeField]
    private Snake snake;
    
    [SerializeField]
    private Animator anim;

    public void OnTriggerEnter(Collider collider)
    {
        Consumable collisionConsumable = collider.gameObject.GetComponent<Consumable>();
        if (collisionConsumable == null) return;
        if(collisionConsumable.IsFinish)
            snake.HitObstacle(true);
        else
        {
            if (snake.IsInFever || collisionConsumable.Color == snake.Color || collisionConsumable.IsCrystal)
            {
                collisionConsumable.GetEaten();
                Eat();
            } else
            {
                snake.HitObstacle(false);
            }
        }
    }

    async void Eat()
    {
        if (anim == null) return;
        anim.SetBool("Eating", true);
        await Task.Delay(500);
        anim.SetBool("Eating", false);
    }

}
