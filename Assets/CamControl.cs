using UnityEngine;

public class CamControl : MonoBehaviour
{
    [SerializeField] Transform target;



    void Update()
    {
        if (target.rotation.y == -1f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.localPosition = new Vector3(0f, 0f, 10f);
        } 
        else if(target.rotation.y == 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.localPosition = new Vector3(0f, 0f, -10f);
        }

        Debug.Log(target.rotation.y);
    }
}
