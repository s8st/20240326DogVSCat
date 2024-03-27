using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
   
    public static GameManager I;
    public GameObject retryBtn;

    public Text levelText;
    //public GameObject levelFront;

    public RectTransform levelFront2;



    int level = 0;
    int score = 0;


    //int level = 0;
    //int cat = 0;


    void Awake()
    {
        if(I == null)
        {
            I = this;
        }
        

        // 모든  컴퓨터의 프레임 일정하게 통일
        Application.targetFrameRate = 60;
    }



  

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
      //  InvokeRepeating("MakeFood", 0f, .05f);
        InvokeRepeating("MakeCat", .0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }



    //void MakeFood()
    //{
    //    float x = dog.transform.position.x+2.0f;
    //    float y = dog.transform.position.y;
    //    Instantiate(food, new Vector3(x, y, 0), Quaternion.identity);
    //}

    void MakeCat()
    {

        Instantiate(normalCat);

        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            float p = Random.Range(0, 10);
            if (p < 5) { Instantiate(normalCat); }
        }
        else if (level == 3)
        {
            float p = Random.Range(0, 10);
            if (p < 6) Instantiate(normalCat);
            Instantiate(fatCat);
        }
        else if (level >= 4)
        {
            float p = Random.Range(0, 10);
            if (p < 8) Instantiate(normalCat);
            Instantiate(fatCat);
            Instantiate(pirateCat);
        }

    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;

    }

    //public void AddCat()
    //{
    //    cat += 1;
    //    level = cat / 5;
    //    levelText.text = level.ToString();
    //    levelFront.transform.localScale = new Vector3((cat - level * 5) / 5f, 1f, 1f);
    //}


public void AddScore()
    {
        score++;
        level = score / 5;
        levelText.text = level.ToString();
        //levelFront.transform.localScale = new Vector3((score - level * 5) / 5f, 1f, 1f);
        levelFront2.localScale = new Vector3((score - level * 5) / 5f, 1f, 1f);

    }







}
