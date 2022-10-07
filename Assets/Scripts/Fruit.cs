using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit: Item
{
    public Sprite sprite;
    public override void Apply(GameObject target)
    {
        ItemManager.Instance.GetItem(Name);
        gameObject.SetActive(false);
    }
}
