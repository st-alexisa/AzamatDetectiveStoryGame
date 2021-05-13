using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    static List<Item> items;
    public static GameObject CellContainer;
    public KeyCode ShowInventory;

    public static void AddItem(Item item)
    {
        items.Add(item);
        foreach (var it in items)
        {
            if(it.Id == 0)
            {
                it.Description = item.Description;
                it.Id = item.Id;
                it.ItemName = item.ItemName;
                it.pathIcon = item.pathIcon;
                it.pathPrefab = item.pathPrefab;
                break;
            }
        }
        DisplayItems();
    }

    static void DisplayItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Transform cell = CellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            if (items[i].Id !=0)
            {
                img.enabled = true;
                img.sprite = Resources.Load<Sprite>(items[i].pathIcon);
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
            }
        }
    }

    void Start()
    {
        items = new List<Item>();
        CellContainer.SetActive(false);
        for (int i = 0; i < CellContainer.transform.childCount; i++)
        {
            items.Add(new Item());
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(ShowInventory))
        {
            if (CellContainer.activeSelf)
                CellContainer.SetActive(false);
            else
                CellContainer.SetActive(true);
        }
    }
}
