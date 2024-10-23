using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            FindAnyObjectByType<GameManager>().AddCollectible();
            Destroy(gameObject);
        }
    }
}
