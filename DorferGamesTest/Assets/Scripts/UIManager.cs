using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public EdibleCounter counter;
    public Text crystalText;
    public Text humanText;

    void Update()
    {
        crystalText.text = counter.GetCrystals().ToString();
        humanText.text = counter.GetHumans().ToString();
    }
}
