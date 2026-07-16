using System.Collections;

namespace InventoryManagement.inventory;

public class inventory
{
    SortedList inventoryItems = new SortedList();

    public void addItem(int id, string Item)
    {
        inventoryItems.Add(id, Item);
        Console.WriteLine($"Added item {Item} to the inventory");
    }
    public void removeItem(int id)
    {
        if (inventoryItems.ContainsKey(id))
        {
            Console.WriteLine($"Removed item {id} from the inventory");
            inventoryItems.Remove(id);
        }
        else
        {
            Console.WriteLine($"Item {id} was not found in the inventory");
        }
    }
    public void removeItemValue(string item)
    {
        int value = inventoryItems.IndexOfValue(item);
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (value == inventoryItems.IndexOfValue(i))
            {
                
                inventoryItems.RemoveAt(i);
                
            }
        }
    }
    public void SearchItem(int id)
    {
        if (inventoryItems.ContainsKey(id))
        {
            Console.WriteLine($"Find item {id} from the inventory");
             
        }
        else
        {
            Console.WriteLine($"Item {id} was not found in the inventory");
        }
    }
    public void SearchItemValue(string item)
    {
        int value = inventoryItems.IndexOfValue(item);
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (value == inventoryItems.IndexOfValue(i))
            {
                
                inventoryItems.RemoveAt(i);
                
            }
        }
    }
    public void displayInventory()
    {
        foreach (DictionaryEntry i in inventoryItems)
        {
            Console.WriteLine($"{i.Key} - {i.Value}");
        }
    }
}