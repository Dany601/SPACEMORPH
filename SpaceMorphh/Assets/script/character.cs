using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float velocityMovement = 2.5f;
    public float velocityRotation = 100.0f;
    private Animator anim;
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Horizontal");
        x = Input.GetAxis("Vertical");

        transform.Rotate(0, y * Time.deltaTime * velocityRotation, 0);
        transform.Translate(x, 0, 0 * Time.deltaTime * velocityMovement);


    }
}
