using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text message, crystalText, humanText;

    [SerializeField]
    private GameObject restartButton;


    public void UpdateCrystalsAmount(string crystalsAmount)
    {
        crystalText.text = crystalsAmount;
    }

    public void UpdateHumansAmount(string humansAmount)
    {
        humanText.text = humansAmount;
    }

    public void TheEnd(bool win)
    {
        message.text = win ? "Victory!" : "Dead.";
        restartButton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
