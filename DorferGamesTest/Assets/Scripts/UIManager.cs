using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public List<UIPositionChange> movingParts;

    public Snake snake;
    public GameObject startButton;
    public Text message;
    public EdibleCounter counter;
    public Text crystalText;
    public Text humanText;
    bool landscape = true;

    void Update()
    {
        crystalText.text = counter.GetCrystals().ToString();
        humanText.text = counter.GetHumans().ToString();
        if (((Screen.orientation == ScreenOrientation.Landscape) || (Screen.orientation == ScreenOrientation.LandscapeLeft) || (Screen.orientation == ScreenOrientation.LandscapeRight)) != landscape)
        {
            landscape = !landscape;
            AdjustPositions();
        }
    }

    private void AdjustPositions()
    {
        for(int i=0; i<movingParts.Count; i++)
            movingParts[i].Adjust((Screen.orientation == ScreenOrientation.Landscape) || (Screen.orientation == ScreenOrientation.LandscapeLeft) || (Screen.orientation == ScreenOrientation.LandscapeRight));
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
