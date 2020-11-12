using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] Button exitBtn;
    //[SerializeField] Button startBtn;
    [SerializeField] AudioClip onClickButton;
    [SerializeField] AudioClip onButton;

    private AudioSource audioSource;

    private void Start() => audioSource = GetComponent<AudioSource>();

    public void StartPlay() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void ExitApp() => Application.Quit();

    public void IfClickSound() => audioSource.PlayOneShot(onClickButton);

    public void IfOnButton() => audioSource.PlayOneShot(onButton);


}
