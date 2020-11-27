using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    private Text numScreenShot;
    private float timeCount = 0;
    private int getCount = 0;
    private int finish = 1;

    // Start is called before the first frame update
    void Start()
    {
        numScreenShot = GameObject.Find("numScreenShot").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(finish == 0)
        {
            timeCount += Time.deltaTime;
            SetCountText();
        }
    }

    void SetCountText()
    {
        //numScreenShot = ;
        //if(getCount >= 1)
        //{
        //    numScreenShot = "[ScreenShot Count]: " + getCount.ToString() + "[Time]:" + timeCount.ToString(); ;
        //    finish = 1;
        //}
    }
}
