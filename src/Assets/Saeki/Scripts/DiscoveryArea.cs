using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveryArea : MonoBehaviour
{
    [SerializeField]
    EnemyDiscoveryController[] enemy;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (EnemyDiscoveryController enemies in enemy)
            {
                enemies.IsDiscobery();
            }
            this.gameObject.SetActive(false);
        }
    }
}
