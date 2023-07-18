using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    public Color startcolor = Color.blue;
    public Color endcolor = Color.red;
    [Range(0,10)]
    public float speed = 1;

    Renderer ren;


    // Start is called before the first frame update
    void Awake()
    {
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ren.material.color = Color.Lerp(startcolor, endcolor, Mathf.PingPong(Time.time * speed, 1));
    }
}
