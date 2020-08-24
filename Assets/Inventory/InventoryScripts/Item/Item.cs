using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item",menuName ="Inventory/Items/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int itemSkinType;
    public string itemSkinID;
    public Sprite itemImage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;

    public bool equid;
}
