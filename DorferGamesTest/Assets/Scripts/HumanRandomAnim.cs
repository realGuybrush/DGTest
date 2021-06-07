using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HumanRandomAnim : MonoBehaviour
{
    private string[] names = { "Scratch", "WaveDance", "RussianDance", "HeadSpin" };
    private int[] chances = { 25, 10, 10, 1 };
    int rand;
    int tempSum;
    public Animator anim;

    void Update()
    {
        AsyncUpdate();
    }

    async void AsyncUpdate()
    {
        rand = Random.Range(0, 100);
        tempSum = 0;
        for (int i = 0; i < chances.Length; i++)
        {
            tempSum += chances[i];
            if (rand < tempSum)
            {
                if (anim != null)
                    anim.SetBool(names[i], true);
                await Task.Delay(500);
                if (anim != null)
                    anim.SetBool(names[i], false);
                break;
            }
        }
    }
}
