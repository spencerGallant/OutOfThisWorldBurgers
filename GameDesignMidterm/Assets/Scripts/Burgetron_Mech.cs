using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burgetron_Mech : MonoBehaviour
{
    public AlienMovement alien;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((alien.transform.position - this.transform.position).sqrMagnitude < 2 * 2)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                alien.SpriteChange1();
            }
        }
    }
}
