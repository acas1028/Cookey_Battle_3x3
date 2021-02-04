using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string itemExplain;
    public string itemproperty;
    public ItemType itemtype;
    public Sprite itemimage;
    public GameObject itemPrefeb;

    public enum ItemType
    {
        Used,
        Equipment,
        Ingredient,
        Armor,
        Etc
    }
}
