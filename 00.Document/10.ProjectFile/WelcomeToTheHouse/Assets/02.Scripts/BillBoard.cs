using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    Transform camTr;


    void Start()
    {
        camTr = Camera.main.transform;
    }


    void Update()
    {
        transform.LookAt(camTr);
    }
}
