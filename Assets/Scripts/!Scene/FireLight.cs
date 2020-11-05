using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    [SerializeField] float minRange = 3.85f;
    [SerializeField] float maxRange = 4f;

    private Transform area;

    private void Start()
    {
        area = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float areaLight = Random.Range(minRange, maxRange);
        area.localScale = new Vector3(areaLight, areaLight);
    }
}
