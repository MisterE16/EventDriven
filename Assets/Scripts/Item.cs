using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class Item : MonoBehaviour
{

    public string itemName = "Item";
    public Sprite itemIcon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if object collided has player tag
        if (collision.CompareTag("Player"))
        {
           

            //get component from object that collided with item
            InventoryController inventoryController = collision.GetComponent<InventoryController>();

            //add item to player inventory if InventoryController is found
            if (inventoryController != null)
            {
                
                //add item to inventory
                bool itemAdded = inventoryController.AddItem(gameObject);

                //if added, destroy item in scene
                if (itemAdded)
                {
                    
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("!Inventory full or item not added!");
                }
            }
        }
    }
}
