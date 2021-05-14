using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject E;
    public GameObject Evidence;
    public GameObject Trigger;

    private void Start()
    {
        E.SetActive(false);    
    }

    private void OnTriggerStay(Collider other)
    {
        E.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            E.SetActive(false);
            Evidence.SetActive(false);
            Trigger.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        E.SetActive(false);
    }
}
