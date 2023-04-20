using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class knobmovment : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public VideoPlayer currentvideo;
    public double currentvideolength;
    public double currentvideotime;
    bool istouched;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        slidervaluechanged();
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log(this.gameObject.name + " Was Clicked.");
    //}
    public void slidervaluechanged()
    {
        
        this.currentvideo = FindObjectOfType<buttonuimanager>().currentvideo;
        
        if (currentvideo != null && !istouched)
        {
           

            currentvideolength = currentvideo.length;
            currentvideotime = currentvideo.time;
            if (currentvideotime > 0)
            {
                GetComponent<Slider>().value = (float)(currentvideotime / currentvideolength);
            }
          
        }
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        istouched = true;
        currentvideo.Pause();
        
       
        

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        currentvideo.time = GetComponent<Slider>().value * currentvideolength;
        StartCoroutine(slidervalue());
        
    }

    IEnumerator slidervalue()
    {
        yield return new WaitForSeconds(0.4f);
        istouched = false;
        currentvideo.Play();
        //currentvideo.time = GetComponent<Slider>().value * currentvideolength;
    }
}
