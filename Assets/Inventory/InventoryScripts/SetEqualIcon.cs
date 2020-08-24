using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetEqualIcon : MonoBehaviour
{
    [Header("设置装备背包")]
    public EquidBags playerEquidBags;

    [Header("设置标题栏")]
    public Text title;

    [Header("设置图标")]
    public Image cloth;
    public Image mainWeapon1;
    public Image subWeapon1;
    public Image mainWeapon2;
    public Image subWeapon2;

    [Header("设置进入后初始按钮")]
    public GameObject selectedBtn;

    Image[] selectedIcon;


    private void OnEnable()
    {
        //SetBeginSelectedBtn();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetIconImage();
        SetTitleText();

    }

    void SetIconImage()
    {
        if (playerEquidBags.Cloth != null)
        {
            cloth.color = new Color(255, 255, 255, 255);
            cloth.sprite = playerEquidBags.Cloth.itemImage;
            cloth.name = playerEquidBags.Cloth.itemName;
        }
        else
        {
            cloth.color = new Color(0, 0, 0, 0);
            cloth.name = "";
        }

        if (playerEquidBags.Main_Weapon1 != null)
        {
            mainWeapon1.color = new Color(255, 255, 255, 255);
            mainWeapon1.sprite = playerEquidBags.Main_Weapon1.itemImage;
            mainWeapon1.name = playerEquidBags.Main_Weapon1.itemName;
        }
        else
        {
            mainWeapon1.color = new Color(0, 0, 0, 0);
            mainWeapon1.name = "";
        }

        if (playerEquidBags.Sub_Weapon1 != null)
        {
            subWeapon1.color = new Color(255, 255, 255, 255);
            subWeapon1.sprite = playerEquidBags.Sub_Weapon1.itemImage;
            subWeapon1.name = playerEquidBags.Sub_Weapon1.itemName;
        }
        else
        {
            subWeapon1.color = new Color(0, 0, 0, 0);
            subWeapon1.name = "";
        }

        if (playerEquidBags.Main_Weapon2 != null)
        {
            mainWeapon2.color = new Color(255, 255, 255, 255);
            mainWeapon2.sprite = playerEquidBags.Main_Weapon2.itemImage;
            mainWeapon2.name = playerEquidBags.Main_Weapon2.itemName;
        }
        else
        {
            mainWeapon2.color = new Color(0, 0, 0, 0);
            mainWeapon2.name = "";
        }

        if (playerEquidBags.Sub_Weapon2 != null)
        {
            subWeapon2.color = new Color(255, 255, 255, 255);
            subWeapon2.sprite = playerEquidBags.Sub_Weapon2.itemImage;
            subWeapon2.name = playerEquidBags.Sub_Weapon2.itemName;
        }
        else
        {
            subWeapon2.color = new Color(0, 0, 0, 0);
            subWeapon2.name = "";
        }
    }

    void SetTitleText()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            title.text = "";
            return;
        }

        selectedIcon = EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Image>();
        if (selectedIcon[1] != null)
        {
            title.text = selectedIcon[1].name;
        }
        else
        {
            title.text = "";
        }
    }

    public void SetBeginSelectedBtn()
    {
        if (selectedBtn != null)
        {
            EventSystem.current.SetSelectedGameObject(selectedBtn.gameObject);
        }
    }
}
