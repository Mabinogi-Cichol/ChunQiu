using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInfo : MonoBehaviour
{
    public int slotID;
    public Item item;

    public Image slotIcon;
    // Start is called before the first frame update
    void Start()
    {
        slotIcon.name = item.itemName;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
