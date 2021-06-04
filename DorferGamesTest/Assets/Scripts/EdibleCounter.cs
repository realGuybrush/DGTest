using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleCounter : MonoBehaviour
{
    private List<int> consumed = new List<int>();
    public Snake snake;
    private int feverCounter;
    public ConsumableType triggerType;
    public int feverTriggerAmount;

    private void Start()
    {
        for (int i = 0; i < System.Enum.GetValues(typeof(ConsumableType)).Length; i++)
        {
            consumed.Add(0);
        }
    }

    public void Increase(ConsumableType type)
    {
        consumed[(int)type]++;
        UpdateFever(type);
    }

    public void UpdateFever(ConsumableType type)
    {
        if (type == triggerType)
        {
            feverCounter++;
            if (feverCounter == feverTriggerAmount)
            {
                snake?.Fever();
                feverCounter = 0;
            }
        }
        else
        {
            feverCounter = 0;
        }
    }

}
