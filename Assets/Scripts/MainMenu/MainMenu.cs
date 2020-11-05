using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] Button exitBtn;
    //[SerializeField] Button startBtn;

    public void StartPlay() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void ExitApp() => Application.Quit();

    
}
