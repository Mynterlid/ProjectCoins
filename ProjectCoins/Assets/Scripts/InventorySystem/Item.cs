using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "InventorySystem/Item", order = 2)]
public class Item : ScriptableObject
{
    public string Name = "Item";
    public Sprite Icon;
    public int StackCounter;
}
