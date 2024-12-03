using System.Collections.Generic;
using UnityEngine;

public class EdibleCounter : MonoBehaviour
{
    public static EdibleCounter Instance;

    [SerializeField]
    private UIManager uiManager;
    
    [SerializeField]
    private Snake snake;
    
    [SerializeField]
    private ConsumableType triggerType;
    
    [SerializeField]
    private int feverTriggerAmount;

    [SerializeField]
    private float feverTime;

    private float currentFeverTimer;
    
    private List<int> consumedItems = new List<int>();
    private int feverCounter;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        int consumablesTypesAmount = System.Enum.GetValues(typeof(ConsumableType)).Length; 
        for (int i = 0; i < consumablesTypesAmount; i++)
        {
            consumedItems.Add(0);
        }
        snake.OnDie += EndGame;
    }

    private void Update()
    {
        if (currentFeverTimer > 0)
        {
            currentFeverTimer -= Time.deltaTime;
            if(currentFeverTimer <= 0)
                snake?.EndFever();
        }
    }

    public void Increase(ConsumableType type)
    {
        int indexByType = (int) type;
        consumedItems[indexByType]++;
        UpdateFeverTriggerValues(type);
        if(type == ConsumableType.Crystal)
            uiManager.UpdateCrystalsAmount(consumedItems[indexByType].ToString());
        if(type == ConsumableType.Human)
            uiManager.UpdateHumansAmount(consumedItems[indexByType].ToString());
    }

    private void UpdateFeverTriggerValues(ConsumableType type)
    {
        if (type == triggerType)
        {
            feverCounter++;
            if (feverCounter == feverTriggerAmount)
            {
                snake?.StartFever();
                feverCounter = 0;
                currentFeverTimer = feverTime;
            }
        }
        else
        {
            feverCounter = 0;
        }
    }

    private void EndGame(bool win)
    {
        uiManager.TheEnd(win);
    }

}
