using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class EndLevel : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline;
    [SerializeField] GameObject canv;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Amunition.isPlayerWhitSword)
        {
            if (collision.gameObject.tag == "Player")
            {
                canv.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    timeline.Play();
                    Invoke("LoadNextScene", 4.2f);
                }
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            canv.SetActive(false);
    }


    void LoadNextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
