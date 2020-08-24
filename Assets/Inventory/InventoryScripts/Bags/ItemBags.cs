﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory/Bags/New Bag")]
public class ItemBags : ScriptableObject
{
    public List<Item> itemList = new List<Item>();
}
