using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3_2 : MonoBehaviour
{
    [SerializeField] private Transform karakterHareket;
    private Vector3 mesafe;
    [SerializeField] private float lerp;
    void Start()
    {
        mesafe = transform.position-karakterHareket.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 yeniPoz=Vector3.Lerp(transform.position,karakterHareket.position+mesafe,lerp*Time.deltaTime);
        transform.position=yeniPoz;
    }
}
