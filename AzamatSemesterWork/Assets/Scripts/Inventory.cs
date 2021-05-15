using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    List<Item> items;
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode takeButton;

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
        if (Input.GetKeyDown(takeButton)) 
        {
            // ѕускаем луч туда куда смотрим
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            // —мотрим врезалс€ ли куда-нибудь луч
            if (Physics.Raycast(ray, out RaycastHit hit, 2f))
            {
                // if мы смотрим на объект, у которого есть скрипт Item
                if (hit.collider.GetComponent<Item>())
                {
                    for (int i = 0; i < items.Count; ++i) 
                    {
                        if (items[i].IsEmpty())
                        {
                            // в пустую €чейку кладем объект
                            items[i] = hit.collider.GetComponent<Item>();
                            // обновл€ем визуальное представление инвентар€
                            DisplayItems();
                            // уничтожаем объект в игровой сцене
                            Destroy(hit.collider.GetComponent<Item>().gameObject);
                            break;
                        }
                    }
                }
            }
        }
    }

    void ToggleInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            if (cellContainer.activeSelf)
                cellContainer.SetActive(false);
            else
                cellContainer.SetActive(true);
        }
    }

    void DisplayItems() 
    {
        for(int i = 0; i < items.Count; ++i)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            if (!items[i].IsEmpty())
            {
                img.enabled = true;
                img.sprite = Resources.Load<Sprite>(items[i].IconPath);
            }
            else 
            {
                img.enabled = false;
                img.sprite = null;
            }
        }
    }
}
