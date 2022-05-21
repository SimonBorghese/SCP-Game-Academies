using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultItem", menuName = "Ryan'sCoolStuff/Item")]
public class Item : ScriptableObject
{
    new public string name;
    public Sprite icon;
    public bool throwable;
    public GameObject throwObject;

}