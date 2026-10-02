using System.Collections.Generic;
using UnityEngine;

public class BackpackTrigger : MonoBehaviour
{
    public List<ItemType> packedItems =
        new List<ItemType>();

    private void OnTriggerEnter(Collider other)
    {
        ItemData item = other.GetComponent<ItemData>();

        if (item == null)
            return;

        packedItems.Add(item.itemType);

        other.gameObject.SetActive(false);
        UISoundManager.Instance.PlayBackpack();

    }
}