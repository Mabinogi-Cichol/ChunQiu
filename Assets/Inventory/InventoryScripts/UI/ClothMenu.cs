using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum EquidType { Cloth,MainWeapon1,SubWeapon1,MainWeapon2,SubWeapon2}

public class ClothMenu : MonoBehaviour
{

    public static ClothMenu instance;

    [Header("设置装备类型")]
    public EquidType equidType;

    [Header("设置图标列表")]
    public GameObject slotGrid;
    [Header("设置图标插槽")]
    public GameObject iconSlot;
    [Header("设置背包")]
    public ItemBags itemBag;
    [Header("设置描述文字")]
    public Text itemName;
    public Text itemDesciption;

    public List<Item> clothList = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();//管理生成的slots

    Image[] selectedIcon;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        SetIconSlot();
    }


    private void Start()
    {
    }
    private void Update()
    {
        if (itemName != null && itemDesciption != null)
        {
            SetTextArea();
        }
    }

    public void SetIconSlot()
    {
        //循环删除slotGrid下的子集物体
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        instance.slots.Clear();
        instance.clothList.Clear();
        int index = 0;


        //遍历背包中的服装类型的Item

        if (equidType == EquidType.Cloth)
        {
            for (int i = 0; i < instance.itemBag.itemList.Count; i++)
            {
                if (instance.itemBag.itemList[i] is Item_clothes)
                {
                    instance.clothList.Add(instance.itemBag.itemList[i]);
                    if (instance.gameObject.activeSelf == false)
                    {
                        break;
                    }
                    instance.slots.Add(Instantiate(instance.iconSlot));
                    instance.slots[index].transform.SetParent(instance.slotGrid.transform);
                    Image[] iconImages = instance.slots[index].GetComponent<Button>().GetComponentsInChildren<Image>();//获取slots中的图片子物体
                    iconImages[1].sprite = instance.clothList[index].itemImage;//因为slots中也包含image，所以用数组取【1】

                    instance.slots[index].GetComponent<SlotInfo>().item = instance.itemBag.itemList[i];//给按键的Item插槽赋值遍历的Item


                    index++;
                }
            }
        }

        if (equidType == EquidType.MainWeapon1)
        {
            for (int i = 0; i < instance.itemBag.itemList.Count; i++)
            {
                if (instance.itemBag.itemList[i] is Item_MainWeapon)
                {
                    instance.clothList.Add(instance.itemBag.itemList[i]);
                    if (instance.gameObject.activeSelf == false)
                    {
                        break;
                    }
                    instance.slots.Add(Instantiate(instance.iconSlot));
                    instance.slots[index].transform.SetParent(instance.slotGrid.transform);
                    Image[] iconImages = instance.slots[index].GetComponent<Button>().GetComponentsInChildren<Image>();//获取slots中的图片子物体
                    iconImages[1].sprite = instance.clothList[index].itemImage;//因为slots中也包含image，所以用数组取【1】

                    instance.slots[index].GetComponent<SlotInfo>().item = instance.itemBag.itemList[i];//给按键的Item插槽赋值遍历的Item


                    index++;
                }
            }
        }

        if (equidType == EquidType.MainWeapon2)
        {
            for (int i = 0; i < instance.itemBag.itemList.Count; i++)
            {
                if (instance.itemBag.itemList[i] is Item_MainWeapon)
                {
                    instance.clothList.Add(instance.itemBag.itemList[i]);
                    if (instance.gameObject.activeSelf == false)
                    {
                        break;
                    }
                    instance.slots.Add(Instantiate(instance.iconSlot));
                    instance.slots[index].transform.SetParent(instance.slotGrid.transform);
                    Image[] iconImages = instance.slots[index].GetComponent<Button>().GetComponentsInChildren<Image>();//获取slots中的图片子物体
                    iconImages[1].sprite = instance.clothList[index].itemImage;//因为slots中也包含image，所以用数组取【1】

                    instance.slots[index].GetComponent<SlotInfo>().item = instance.itemBag.itemList[i];//给按键的Item插槽赋值遍历的Item


                    index++;
                }
            }
        }

        if (equidType == EquidType.SubWeapon1)
        {
            for (int i = 0; i < instance.itemBag.itemList.Count; i++)
            {
                if (instance.itemBag.itemList[i] is Item_SubWeapon)
                {
                    instance.clothList.Add(instance.itemBag.itemList[i]);
                    if (instance.gameObject.activeSelf == false)
                    {
                        break;
                    }
                    instance.slots.Add(Instantiate(instance.iconSlot));
                    instance.slots[index].transform.SetParent(instance.slotGrid.transform);
                    Image[] iconImages = instance.slots[index].GetComponent<Button>().GetComponentsInChildren<Image>();//获取slots中的图片子物体
                    iconImages[1].sprite = instance.clothList[index].itemImage;//因为slots中也包含image，所以用数组取【1】

                    instance.slots[index].GetComponent<SlotInfo>().item = instance.itemBag.itemList[i];//给按键的Item插槽赋值遍历的Item


                    index++;
                }
            }
        }

        if (equidType == EquidType.SubWeapon2)
        {
            for (int i = 0; i < instance.itemBag.itemList.Count; i++)
            {
                if (instance.itemBag.itemList[i] is Item_SubWeapon)
                {
                    instance.clothList.Add(instance.itemBag.itemList[i]);
                    if (instance.gameObject.activeSelf == false)
                    {
                        break;
                    }
                    instance.slots.Add(Instantiate(instance.iconSlot));
                    instance.slots[index].transform.SetParent(instance.slotGrid.transform);
                    Image[] iconImages = instance.slots[index].GetComponent<Button>().GetComponentsInChildren<Image>();//获取slots中的图片子物体
                    iconImages[1].sprite = instance.clothList[index].itemImage;//因为slots中也包含image，所以用数组取【1】

                    instance.slots[index].GetComponent<SlotInfo>().item = instance.itemBag.itemList[i];//给按键的Item插槽赋值遍历的Item


                    index++;
                }
            }
        }

    }

    void SetTextArea()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            itemName.text = "";
            itemDesciption.text = "";
        }
        else
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<SlotInfo>() != null)
            {
                itemName.text = EventSystem.current.currentSelectedGameObject.GetComponent<SlotInfo>().item.itemName;
                itemDesciption.text = EventSystem.current.currentSelectedGameObject.GetComponent<SlotInfo>().item.itemInfo;
            }
        }
    }

    public void SetBeginSelectedBtn()
    {
        if (slots[0] != null)
        {
            EventSystem.current.SetSelectedGameObject(slots[0]);
        }
    }
}
