using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChekoPointo : MonoBehaviour
{
    public SpawnPoint spawnData;

    private SpriteRenderer _renderer;

    public static UnityAction TakeSpawn;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        ChekoPointo.TakeSpawn += Desactivate;
    }
    private void OnDisable()
    {
        ChekoPointo.TakeSpawn -= Desactivate;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Respawn.Instance.SetRespawn(spawnData);
    }
    public SpawnPoint ReturnCurrentSpawpoint()
    {
        return spawnData;
    }

    public void Activate()
    {
        TakeSpawn.Invoke();
        _renderer.sprite = spawnData.Active;
    }

    public void Desactivate()
    {
        _renderer.sprite = spawnData.NotActive;
    }
}
