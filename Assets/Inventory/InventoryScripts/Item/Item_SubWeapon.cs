using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Items/New Item_SubWeapon")]
public class Item_SubWeapon : Item
{
    public SubWeaponType subWeaponType;
    public int atk;
    public int cost;
}

public enum SubWeaponType { Shield }