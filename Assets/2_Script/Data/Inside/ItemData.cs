using UnityEngine;

public class ItemData : MonoBehaviour
{
    public ItemType itemType;
}

public enum ItemType
{
    Water,
    Light,
    Doll,
    Book,
    Battery,
    Clothes
}
