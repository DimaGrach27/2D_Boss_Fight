using UnityEngine;

public class Camp : MonoBehaviour
{
    [SerializeField] GameObject hidenCamp;
    [SerializeField] Transform maskCamp;
    [SerializeField] SpriteRenderer [] hideElements;

    private bool isHidde;

    private void Start()
    {
        hidenCamp.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            maskCamp.position = new Vector3(maskCamp.position.x, maskCamp.position.y, 10);
            // hideElements.SetActive(false);
            isHidde = true;
            hidenCamp.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            maskCamp.position = new Vector3(maskCamp.position.x, maskCamp.position.y, 0);
            //hideElements.SetActive(true);
            isHidde = false;
            hidenCamp.SetActive(false);
        }
    }

    private void Update()
    {
        HiddeElements(isHidde);
    }

    void HiddeElements(bool hide)
    {
        if (hide)
        {
            for (int i = 0; i < hideElements.Length; i++)
            {
                hideElements[i].color = new Color(hideElements[i].color.r, hideElements[i].color.g, hideElements[i].color.b, hideElements[i].color.a - 0.7f * Time.deltaTime);
            }
        }
        else
        {
            for (int i = 0; i < hideElements.Length; i++)
            {
                hideElements[i].color = new Color(hideElements[i].color.r, hideElements[i].color.g, hideElements[i].color.b, 1f);
            }
        }
    }
}
