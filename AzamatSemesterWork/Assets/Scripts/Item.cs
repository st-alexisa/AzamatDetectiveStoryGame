using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;
    public int Id;
    [Multiline(5)]
    public string Description;
    public string IconPath;
    public string PrefabPath;
    public string Note;

    public bool IsEmpty() 
    {
        return Id == 0;
    }
}
