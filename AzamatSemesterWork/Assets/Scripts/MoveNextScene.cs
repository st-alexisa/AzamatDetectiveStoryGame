using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNextScene : MonoBehaviour
{
    public int ID;
    public GameObject Text;

    private void Start()
    {
        Text.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        Text.SetActive(true);
        if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(ID);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
    }
}
