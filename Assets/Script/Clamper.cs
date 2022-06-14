using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamper : MonoBehaviour
{
    float setZ;
    private void Update()
    {
     transform.position=new Vector3 (transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -18.5f,-1.95f ));
    }

}
