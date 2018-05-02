using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    int id;

    void Start()
    {
        id = -1;
    }

    void Update()
    {

    }

    public void SetID(int _id)
    {
        id = _id;
    }
    public int GetID()
    {
        return id;
    }
}
