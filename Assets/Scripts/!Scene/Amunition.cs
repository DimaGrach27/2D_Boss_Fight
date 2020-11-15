using UnityEngine;

public class Amunition : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerSw;

    [SerializeField] GameObject pressText;

    [SerializeField] UnityEngine.Playables.PlayableDirector playbel;

    public static bool isPlayerWhitSword;
    private void Start()
    {
        isPlayerWhitSword = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isPlayerWhitSword)
        {
            if (collision.gameObject.tag == "Player" && TextToAmunition.wasReading)
            {
                pressText.SetActive(true);
            }
            if (collision.gameObject.tag == "Player" && TextToAmunition.wasReading && Input.GetKey(KeyCode.E))
            {
                playbel.Play();
                isPlayerWhitSword = true;
                Invoke("ChangePlayer", 2.9f);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            pressText.SetActive(false);
    }

    void ChangePlayer()
    {
        playerSw.SetActive(true);
        player.SetActive(false);
    }

    
}
