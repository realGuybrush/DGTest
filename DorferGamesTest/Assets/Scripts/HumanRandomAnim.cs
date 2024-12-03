using System.Threading.Tasks;
using UnityEngine;

public class HumanRandomAnim : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    
    private string[] animationNames = { "Scratch", "WaveDance", "RussianDance", "HeadSpin" };
    private int[] animationChances = { 25, 10, 10, 1 };
    private int rand;
    private int tempSum;

    void Update()
    {
        if (anim != null)
            AsyncUpdate();
    }

    async void AsyncUpdate()
    {
        rand = Random.Range(0, 100);
        tempSum = 0;
        for (int i = 0; i < animationChances.Length; i++)
        {
            tempSum += animationChances[i];
            if (rand < tempSum)
            {
                anim.SetBool(animationNames[i], true);
                await Task.Delay(500);
                anim.SetBool(animationNames[i], false);
                break;
            }
        }
    }
}
