using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float y = mousePos.y;
        if (y > 25f)
        { y = 25f; }
        if (y < -25f)
        { y = -25f; }

        transform.position = new Vector3(transform.position.x, y, 0);

    }

    void MakeFood()
    {
        //Debug.Log("¹ä¸Ô¾î");
        float x = transform.position.x;
        float y = transform.position.y;

        Instantiate(food,new Vector2(x,y),Quaternion.identity);
    }
}
