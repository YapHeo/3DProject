using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    Material mate;

    float color;
    void Start()
    {
        mate = gameObject.GetComponent<MeshRenderer>().material;
        mate.color = Color.white;
    }

    void Update()
    {
        color = Mathf.PingPong(Time.time * 255, 255);

        mate.color = new Color(color / 255, color / 255, color / 255, 1);
    }
}
