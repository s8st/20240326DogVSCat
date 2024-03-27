using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public int type;
    bool isFull = false;
    float full = 5.0f;
    float energy = .0f;
    
    float speed = 0.05f;

    public RectTransform front;

    public GameObject hungryCat;
    public GameObject fullCat;


    // Start is called before the first frame update
    void Start()
    {
        

        float y = Random.Range(-20.5f, 20.5f);
        float x = 40f;
        transform.position = new Vector3(x, y, 0);

        if (type == 0)
        {
            speed = 0.05f;
            full = 5.0f;
        }
        else if (type == 1)
        {
            speed = .02f;
            full = 10.0f;
        }
        else if (type == 2)
        {
            speed = .02f;
            full = 10.0f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            if (type == 0)
            { transform.position += new Vector3(-.05f, 0f, .0f); }
            //{ transform.position += Vector3.left * speed; }

            else if (type == 1)
            { transform.position += new Vector3(-.03f, 0f, .0f); }
            //{ transform.position += Vector3.left * speed; }

            else if (type == 2)
            { transform.position += new Vector3(-.1f, 0f, .0f); }
            //{ transform.position += Vector3.left*speed; }


            if (transform.position.x < -45f)
            {
                GameManager.I.GameOver();
            }
        }
        else
        {
            if (transform.position.y > 0)
            {
                transform.position += new Vector3(0f, .05f, .0f);
            }
            else
            {
                transform.position += new Vector3(0f, -.05f, .0f);
            }
            Destroy(gameObject, 2.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Food")
        if (collision.gameObject.CompareTag("Food"))
        {

            if (energy < full)
            {
                energy += 1f;
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);

                Destroy(collision.gameObject);
                //gameObject.transform.Find("Hungry/Canvas/Front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
                //Debug.Log("맞았다");

                if(energy == 5.0f)
                {
                    //if(isFull == false)
                    if (!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 3.0f);
                        GameManager.I.AddScore();

                    }

                   
                }
            }
            //else
            //{

            //    if (isFull == false)
            //    {
            //        GameManager.I.AddCat();

            //        hungryCat.SetActive(false);
            //        fullCat.SetActive(true);

            //        //gameObject.transform.Find("Hungry").gameObject.SetActive(false);
            //        //gameObject.transform.Find("Full").gameObject.SetActive(true);
            //        isFull = true;
            //    }



                // Debug.Log("배가 다 찼어요"); 

            //}
        }
    }
}
