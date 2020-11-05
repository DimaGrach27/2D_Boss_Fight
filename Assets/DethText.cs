using UnityEngine;
using UnityEngine.UI;

public class DethText : MonoBehaviour
{
    [SerializeField] Text txt;

    private float alpha;

    private void Start()
    {
        alpha = 0;
    }
    private void Update()
    {
        if (txt.enabled)
        {
            alpha += (0.25f * Time.deltaTime);
            txt.color = new Color(255, 0, 0, alpha);
        }
    }
}
