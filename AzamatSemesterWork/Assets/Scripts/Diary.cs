using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    List<Item> items;
    public GameObject cellContainer;
    public KeyCode showDiary;
    
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        cellContainer.SetActive(false);

        for (int i = 0; i < cellContainer.transform.childCount; ++i)
        {
            items.Add(new Item());
        }
    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();
        DisplayItems();
    }

    void ToggleInventory()
    {
        if (Input.GetKeyDown(showDiary))
        {
            if (cellContainer.activeSelf)
                cellContainer.SetActive(false);
            else
                cellContainer.SetActive(true);
        }
    }

    void DisplayItems()
    {
        for (int i = 0; i < items.Count; ++i)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            //Transform txtbox = cell.GetChild(1);
            Image img = icon.GetComponent<Image>();
            //Text txt = txtbox.GetComponent<Text>();
            if (!items[i].IsEmpty())
            {
                img.enabled = true;
                img.sprite = Resources.Load<Sprite>(items[i].IconPath);
                //txt.enabled = true;
                //txt.text = items[i].Description;
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
            }
        }
    }
}
