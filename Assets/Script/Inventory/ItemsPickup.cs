using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickup : MonoBehaviour
{
    public Item Item;

    void Pickup()
    {
        Inventory.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
