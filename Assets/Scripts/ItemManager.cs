using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

[Serializable]
public class ItemData{
    public string Name;
    public GameObject ItemType;
    public bool picked;
}

public class ItemManager : MonoBehaviour
{
    private static ItemManager _instance;
    public static ItemManager Instance => _instance;
    public List<ItemData> itemslist = new List<ItemData>();
    private Dictionary<string, ItemData> ItemDictionary;
    public UnityEvent AllItemsPicked;
    public UnityEvent<float> Init;
    public UnityEvent<float> ItemPicked;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }

        ItemDictionary = new Dictionary<string, ItemData>();
        for(int i=0; i < itemslist.Count; i++)
        {
            ItemDictionary.Add(itemslist[i].Name, itemslist[i]);
        }
        Init.Invoke(ItemDictionary.Count);
        CheckItems();
    }

    public int ReturnTotalItems()
    {
        return ItemDictionary.Count;
    }

    public void GetItem(string Name)
    {
        if (ItemDictionary.ContainsKey(Name))
        {
            ItemDictionary[Name].picked = true;
            CheckItems();
        }
    }

    public List<bool> CheckIfItemPicked()
    {
        List<bool> itemsPick = new List<bool>();
        for (int i = 0; i < ItemDictionary.Count; i++)
        {
            if (ItemDictionary[itemslist[i].Name].picked)
            {
                itemsPick.Add(true);
            }
            else
            {
                itemsPick.Add(false);
            }

        }
        return itemsPick;
    }

    public void GetItemsByList(List<int> itemsListInt)
    {
        for (int i = 0; i < ItemDictionary.Count; i++)
        {
            if (itemsListInt[i]==1)
            {
                ItemDictionary[itemslist[i].Name].picked = true;
                ItemDictionary[itemslist[i].Name].ItemType.GetComponent<Item>().Apply(null);
            }
            else
            {
                ItemDictionary[itemslist[i].Name].picked = false;
            }

        }
        CheckItems();
    }

    public void CheckItems()
    {
        int total=0;
        for(int i=0; i < ItemDictionary.Count; i++)
        {
            if (ItemDictionary[itemslist[i].Name].picked)
            {
                total++;
            }
                 
        }
        ItemPicked.Invoke(total);
        if (total == ItemDictionary.Count)
        {
            AllItemsPicked.Invoke();
        }
    }
}
