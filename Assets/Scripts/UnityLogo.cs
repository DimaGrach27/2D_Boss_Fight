using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityLogo : MonoBehaviour
{
    [SerializeField] Transform endPoint;
    [SerializeField] GameObject[] thanks;

    [SerializeField] float speed = 2f;

    private SpriteRenderer sprite;
    private float invisible = 255f;

    private void Start() 
    { 
        sprite = GetComponent<SpriteRenderer>();
        invisible = 1f;
        thanks[0].SetActive(false);
        thanks[1].SetActive(false);
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);

        if (transform.position == endPoint.position)
        {
            thanks[0].SetActive(true);
            thanks[1].SetActive(true);

            invisible -= 0.0005f * Time.deltaTime;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a * invisible);
            Debug.Log(sprite.color.a);

            Invoke("LoadMEinMenu", 10f);

        }
    }

    void LoadMEinMenu() => SceneManager.LoadScene("MainMenu");

}
