using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SysScript : MonoBehaviour
{
    [SerializeField] GameObject nigthDay;
    [SerializeField] Text dataTime;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] AudioClip onClickButton;

    private AudioSource audioSource;

    private void Start() => audioSource = GetComponent<AudioSource>();

    void Update()
    {

        DateTime someDate = DateTime.Now;

        someDate.ToLocalTime();
        dataTime.text = someDate.ToShortTimeString();

        //if (someDate.Hour > 12)
        //    nigthDay.SetActive(true);
        //else
        //    nigthDay.SetActive(false);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }

        }
    }

    public void ResumePlay()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitApp() => Application.Quit();

    public void IfClickSound() => audioSource.PlayOneShot(onClickButton);
}
