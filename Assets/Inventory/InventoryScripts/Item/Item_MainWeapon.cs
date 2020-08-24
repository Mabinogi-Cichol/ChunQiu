using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Items/New Item_MainWeapon")]
public class Item_MainWeapon : Item
{
    public MainWeaponType mainWeaponType;
    public int atk;
    public int cost;

}

public enum MainWeaponType { Sword,Lance}