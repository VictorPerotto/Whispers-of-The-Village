using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject 
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemIcon;
    [SerializeField, TextArea] private string itemDescription;

    public string GetItemName() => itemName;
    public Sprite GetItemIcon() => itemIcon;
    public string GetItemDescription() => itemDescription;

}
