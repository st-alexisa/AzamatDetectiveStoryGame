using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<Item> items;
    public GameObject cellContainer;
    public KeyCode showInventory;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();

        cellContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(showInventory))
        {
            if (cellContainer.activeSelf)
                cellContainer.SetActive(false);
            else
                cellContainer.SetActive(true);
        }
    }
}
