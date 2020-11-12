using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class EndLevel : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                timeline.Play();
                Invoke("LoadNextScene", 4.2f);
            }
        }
    }

    void LoadNextScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
