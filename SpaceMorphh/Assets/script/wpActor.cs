using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wpActor : MonoBehaviour
{
    public float speed = 7.0f;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("waypoint"))
        {
            target = other.gameObject.GetComponent<waypoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
    }
}
