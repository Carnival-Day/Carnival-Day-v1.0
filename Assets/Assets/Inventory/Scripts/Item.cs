using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable object/gameItem")]
//Initialize Item's attributes
public class Item : ScriptableObject {

    public string itemName;
    public string description;
    public Sprite image;
}
