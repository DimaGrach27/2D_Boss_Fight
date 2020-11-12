using UnityEngine;

public class TextToAmunition : MonoBehaviour
{

    [SerializeField] Canvas text;

    private float timeSee { get; set; }
    private bool isActive;

    public static bool wasReading = false;

    private void Start()
    {
        wasReading = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.gameObject.SetActive(true);
            wasReading = true;
            isActive = true;
            timeSee = 6f;

        }
    }

    private void Update()
    {
        if (isActive == true)
        {
            timeSee -= Time.deltaTime;
            if (timeSee < 0)
            {
                text.gameObject.SetActive(false);
                isActive = false;
            }
        }
    }
}
