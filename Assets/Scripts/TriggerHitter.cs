using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHitter : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.TryGetComponent(out HealthBehaviour healthBehaviour))
        {
            healthBehaviour.Hurt(1);
        }
    }
}
