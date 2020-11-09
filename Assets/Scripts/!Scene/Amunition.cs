using UnityEngine;

public class Amunition : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerSw;

    [SerializeField] GameObject pressText;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && RoadSignText.wasReading)
        {
            pressText.SetActive(true);
        }
        if(collision.gameObject.tag == "Player" && RoadSignText.wasReading && Input.GetKey(KeyCode.E))
        {
            playerSw.SetActive(true);
            player.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            pressText.SetActive(false);
    }

}
