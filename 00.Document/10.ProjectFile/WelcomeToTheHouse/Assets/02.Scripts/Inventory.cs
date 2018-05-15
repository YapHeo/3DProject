using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject itemDB;
    GameObject[] arrSlot;
    Sprite[] itemSprite;

    void Start()
    {
        itemDB = GameObject.Find("ItemDatabase");

        arrSlot = new GameObject[8];

        for(int i = 0; i < 8; ++i)
        {
            // 슬롯 8개 찾아서 배열에 넣어줌
            arrSlot[i] = GameObject.Find("Slot" + i.ToString());
        }

        itemSprite = itemDB.GetComponent<ItemDatabase>().GetItem();
    }

    void Update()
    {

    }

    public void AddItem(int _itemID)
    {
        for (int i = 0; i < 8; ++i)
        {
            if (arrSlot[i].GetComponentInChildren<SpriteRenderer>().sprite == null)
            {
                arrSlot[i].GetComponentInChildren<SpriteRenderer>().sprite = itemSprite[_itemID];
                arrSlot[i].GetComponent<Slot>().SetID(_itemID);

                return;
            }
        }
    }

    public void DelItem()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    arrSlot[0].GetComponentInChildren<SpriteRenderer>().sprite = null;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    arrSlot[1].GetComponentInChildren<SpriteRenderer>().sprite = null;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    arrSlot[2].GetComponentInChildren<SpriteRenderer>().sprite = null;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    arrSlot[3].GetComponentInChildren<SpriteRenderer>().sprite = null;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    arrSlot[4].GetComponentInChildren<SpriteRenderer>().sprite = null;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    arrSlot[5].GetComponentInChildren<SpriteRenderer>().sprite = null;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha7))
        //{
        //    arrSlot[6].GetComponentInChildren<SpriteRenderer>().sprite = null;
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha8))
        //{
        //    arrSlot[7].GetComponentInChildren<SpriteRenderer>().sprite = null;
        //}
    }

    public void ResetItem()
    {
        for (int i = 0; i < 8; ++i)
            arrSlot[i].GetComponentInChildren<SpriteRenderer>().sprite = null;
    }
}
