using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetSelectedBotton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        EventSystem.current.SetSelectedGameObject(this.gameObject);
    }

    public void OpenClothMenu()
    {
        ClothMenu.instance.equidType = EquidType.Cloth;
    }

    public void OpenMainWeapon1Menu()
    {
        ClothMenu.instance.equidType = EquidType.MainWeapon1;
    }

    public void OpenMainWeapon2Menu()
    {
        ClothMenu.instance.equidType = EquidType.MainWeapon2;
    }
    public void OpenSubWeapon1Menu()
    {
        ClothMenu.instance.equidType = EquidType.SubWeapon1;
    }

    public void OpenSubWeapon2Menu()
    {
        ClothMenu.instance.equidType = EquidType.SubWeapon2;
    }
}
