using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected int type; // 1. 획득 및 사용 템, 2. 아이템 사용이 필요한 아이템
    protected int spriteId;

    void Start()
    {

    }

    void Update()
    {

    }

    public int GetItemType()
    {
        return type;
    }

    public int GetSpriteId()
    {
        return spriteId;
    }
}
