using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cam;
    public GameObject bakgrou;
    public Transform Pos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.transform.position = new Vector3(Pos.position.x, Pos.position.y, cam.transform.position.z);
        bakgrou.transform.position = new Vector3(Pos.position.x, Pos.position.y);
    }
}
