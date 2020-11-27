using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HiResScreenShots : MonoBehaviour
{
    private int resWidth = 1280;
    private int resHeight = 752;

    private int filenum = 0;
    private bool takeHiResShot = false;

    [SerializeField]
    private GameObject model;

    void Awake()
    {
        resWidth = Screen.width;
        resHeight = Screen.height;
        //StartCoroutine(CountTime(2f));
    }

    IEnumerator CountTime(float delayTime)
    {
        StartScreenShotRoutine();
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(CountTime(2f));
    }

    public string ScreenShotName(int width, int height, int filenum)
    {
        return string.Format("{0}/{1}_{2}_{3}.png",
                             Application.dataPath + "/ScreenShot/" + model.name,
                             model.name,
                             filenum, 
                             this.gameObject.name);
    }

    public void TakeHiResShot()
    {
        takeHiResShot = true;
    }

    void ScreenShot()
    {
        takeHiResShot = false;

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        GetComponent<Camera>().targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        GetComponent<Camera>().Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        GetComponent<Camera>().targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);

        // 파일로 저장.
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenShotName(resWidth, resHeight,filenum++);
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));
    }

    void StartScreenShotRoutine(float yAngle=0f)
    {
        for (int i = 0; i < 8; i++, yAngle += 45)
        {
            GetComponent<Camera>().transform.Rotate(0, yAngle, 0);
            ScreenShot();
        }
    }

    
}