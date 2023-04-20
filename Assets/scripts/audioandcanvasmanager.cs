using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class audioandcanvasmanager : MonoBehaviour
{

    public AudioClip[] myaudioclips;
    public Canvas[] mycanvases;
  /*  public string currentaudio;
    public string currentvideo;*/
    public Canvas currentcanvas;
    public buttonuimanager mybuttonuimanager;
    public static audioandcanvasmanager instance
    {
        get;
        private set;
    }
    public AudioSource myaudiosource;
    
  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void findvideo(string myvideoname)
    {
        if (mybuttonuimanager.currentvideo != null)
        {
            mybuttonuimanager.videodefault();
        }
        mybuttonuimanager.currentvideo = null;
        foreach (Canvas canvas in mycanvases)

        {
            if(canvas.name== myvideoname)
            {
               
                canvas.GetComponent<Canvas>().enabled=true;
                if (canvas.gameObject.GetComponentInChildren<VideoPlayer>()!=null)
                {
                  
                    VideoPlayer videoplayer = canvas.gameObject.GetComponentInChildren<VideoPlayer>();
                    mybuttonuimanager.currentvideo = videoplayer;
                    videoplayer.Play();
                 
                }
                
                if(canvas.gameObject.GetComponentInChildren<SphereCollider>())
                {
                    GameObject spheregameobject = canvas.gameObject.GetComponentInChildren<SphereCollider>().gameObject;
                    spheregameobject.GetComponent<MeshRenderer>().enabled = true;
                }
               
            }
            else
            {
                canvas.GetComponent<Canvas>().enabled=false;
                if (canvas.gameObject.GetComponentInChildren<VideoPlayer>() != null)
                {
                    VideoPlayer videoplayer = canvas.gameObject.GetComponentInChildren<VideoPlayer>();
                    videoplayer.Stop();
                }
                if (canvas.gameObject.GetComponentInChildren<SphereCollider>())
                {
                    GameObject spheregameobject = canvas.gameObject.GetComponentInChildren<SphereCollider>().gameObject;
                    spheregameobject.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
       
    }
    public void findaudio(string mysoundname)
    {
        if (mysoundname != "none")
        {
            foreach (AudioClip audioclips in myaudioclips)
            {

                if (audioclips.name == mysoundname)
                {
                    myaudiosource.PlayOneShot(audioclips);
                }


            }
        }

    }
   
    public enum soundname
    {
        buttonclick1,
        buttonclick2,
        buttonclick3,
        none
    }
    public enum nextcanvas
    {
        menu,
        normalvideo,
        panaromicvideo,
        urlvideoplayer
    }



}


    
    

