using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Bags/New EquidBag")]
public class EquidBags : ScriptableObject
{
    public Item_clothes Cloth;
    public Item_MainWeapon Main_Weapon1;
    public Item_SubWeapon Sub_Weapon1;
    public Item_MainWeapon Main_Weapon2;
    public Item_SubWeapon Sub_Weapon2;
}
