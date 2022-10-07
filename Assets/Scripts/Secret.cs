using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Secret : MonoBehaviour
{
    public TilemapRenderer tile;
    
    // Start is called before the first frame update
    void Start()
    {
        tile = GetComponent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tile.enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tile.enabled = true;
    }
}
