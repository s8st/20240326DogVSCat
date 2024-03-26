using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        //transform.position += new Vector3(1f, 0, 0);
        transform.position -= Vector3.left*.5f;
        if (transform.position.x > 45f)
        { Destroy(gameObject); }
    }
}
