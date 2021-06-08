using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    public Snake snake;
    public GameObject startButton;
    public Text message;
    public EdibleCounter counter;
    public Text crystalText;
    public Text humanText;

    void Update()
    {
        crystalText.text = counter.GetCrystals().ToString();
        humanText.text = counter.GetHumans().ToString();
    }

    public void StartGame()
    {
        snake.Live();
        startButton.SetActive(false);
    }

    public void SetMessage(string mess)
    {
        message.text = mess;
    }

    public async void Restart()
    {
        await Task.Delay(3000);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
