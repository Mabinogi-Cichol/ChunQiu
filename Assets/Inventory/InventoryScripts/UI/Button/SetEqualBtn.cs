using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SetEqualBtn : MonoBehaviour
{
    public EquidBags playerBag;
    public SlotInfo slotInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCloth()
    {
        ClothMenu clothMenu = GetComponentInParent<ClothMenu>();

        if (clothMenu.equidType == EquidType.Cloth)
        {
            playerBag.Cloth = (Item_clothes)slotInfo.item;
        }


        if (clothMenu.equidType == EquidType.MainWeapon1)
        {
            if (slotInfo.item != playerBag.Main_Weapon1)
            {
                playerBag.Main_Weapon1 = (Item_MainWeapon)slotInfo.item;
            }
            else
            {
                playerBag.Main_Weapon1 = null;
            }
        }

        if (clothMenu.equidType == EquidType.SubWeapon1)
        {
            if (slotInfo.item != playerBag.Sub_Weapon1)
            {
                playerBag.Sub_Weapon1 = (Item_SubWeapon)slotInfo.item;
            }
            else
            {
                playerBag.Sub_Weapon1 = null;
            }
        }

        if (clothMenu.equidType == EquidType.MainWeapon2)
        {
            if (slotInfo.item != playerBag.Main_Weapon2)
            {
                playerBag.Main_Weapon2 = (Item_MainWeapon)slotInfo.item;
            }
            else
            {
                playerBag.Main_Weapon2 = null;
            }
        }

        if (clothMenu.equidType == EquidType.SubWeapon2)
        {
            if (slotInfo.item != playerBag.Sub_Weapon2)
            {
                playerBag.Sub_Weapon2 = (Item_SubWeapon)slotInfo.item;
            }
            else
            {
                playerBag.Sub_Weapon2 = null;
            }
        }



    }
    
}
