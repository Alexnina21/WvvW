using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    public Sprite sprite;
    public string Name;
    public abstract void Apply(GameObject target);
    public Sprite returnSprite()
    {
        return sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Apply(collision.gameObject);
    }
}
