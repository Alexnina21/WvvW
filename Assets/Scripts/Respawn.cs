using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class SpawnPoint
{
    public Transform CameraPoint;
    public Transform CheckPointPos;
    public Sprite Active;
    public Sprite NotActive;
    public ChekoPointo CheckScript;
}

public class Respawn : MonoBehaviour
{
    private static Respawn _instance;
    public static Respawn Instance => _instance;

    public GameObject cam;
    public GameObject bakgrou;
    public SpawnPoint DefaultSpawn;
    public UnityEvent<Vector3> Tp;

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
        
    }
    private void Start()
    {
        DefaultSpawn.CheckScript.Activate();
        Init();
    }

    public void SetRespawn(SpawnPoint spawn)
    {
        DefaultSpawn = spawn;
        DefaultSpawn.CheckScript.Activate();
        Init();
    }


    public void StartRespawn()
    {
        //GetComponent<Animator>().SetTrigger("Hit");

        cam.transform.position = new Vector3(DefaultSpawn.CameraPoint.position.x, DefaultSpawn.CameraPoint.position.y, cam.transform.position.z);
        bakgrou.transform.position = new Vector3(DefaultSpawn.CameraPoint.position.x, DefaultSpawn.CameraPoint.position.y);
        Tp.Invoke(DefaultSpawn.CheckPointPos.position);
    }
    public void Init()
    {
        //GetComponent<Animator>().SetTrigger("Hit");

        cam.transform.position = new Vector3(DefaultSpawn.CameraPoint.position.x, DefaultSpawn.CameraPoint.position.y, cam.transform.position.z);
        bakgrou.transform.position = new Vector3(DefaultSpawn.CameraPoint.position.x, DefaultSpawn.CameraPoint.position.y);
    }
    public SpawnPoint ReturnCurrentSpawpoint()
    {
        return DefaultSpawn;
    }

}
