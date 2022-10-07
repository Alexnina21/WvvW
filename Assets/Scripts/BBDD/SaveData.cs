using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int checkpoint;
    public GameObject player;
    private float SpawnX;
    private float SpawnY;
    private List<int> itemsGot;
    private int totalItems;

    public int ActualGameId=0;
    private void Start()
    {
        itemsGot = new List<int>();
        totalItems = ItemManager.Instance.ReturnTotalItems();
        ActualGameId = DBManager.ActualGameId;
        Get();
    }


    public void Get()
    {
        itemsGot.Clear();
        Cosa cosa = DBManager.GetValues(ActualGameId);

        player.transform.position = new Vector3(cosa.SpawnX, cosa.SpawnY,0);

        itemsGot.Add(cosa.Item1);
        itemsGot.Add(cosa.Item2);
        itemsGot.Add(cosa.Item3);
        itemsGot.Add(cosa.Item4);
        itemsGot.Add(cosa.Item5);
        itemsGot.Add(cosa.Item6);
        itemsGot.Add(cosa.Item7);
        itemsGot.Add(cosa.Item8);
        itemsGot.Add(cosa.Item9);
        ItemManager.Instance.GetItemsByList(itemsGot);

        Debug.Log(player.transform.position);

    }

    public void Save()
    {
        SpawnX = Respawn.Instance.ReturnCurrentSpawpoint().CheckPointPos.position.x;
        
        SpawnY = Respawn.Instance.ReturnCurrentSpawpoint().CheckPointPos.position.y;

        string stringX = SpawnX.ToString();
        string stringY = SpawnY.ToString();

        stringX = stringX.Replace(",", ".");
        stringY = stringY.Replace(",", ".");

        itemsGot.Clear();
        List<bool> items = ItemManager.Instance.CheckIfItemPicked();
        for (int i = 0; i < totalItems; i++)
        {
            if (items[i])
            {
                itemsGot.Add(1);
            }
            else
            {
                itemsGot.Add(0);
            }

        }

        Cosa cosa = new Cosa()
        {
            SpawnX = SpawnX,
            SpawnY = SpawnY,
            stringX = stringX,
            stringY = stringY,
            Item1 = itemsGot[0],
            Item2 = itemsGot[1],
            Item3 = itemsGot[2],
            Item4 = itemsGot[3],
            Item5 = itemsGot[4],
            Item6 = itemsGot[5],
            Item7 = itemsGot[6],
            Item8 = itemsGot[7],
            Item9 = itemsGot[8]

        };            

        DBManager.SaveData(cosa);
    }
}
