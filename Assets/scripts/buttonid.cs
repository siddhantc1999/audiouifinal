using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class buttonid:MonoBehaviour
{
  
    public audioandcanvasmanager.nextcanvas mynextcanvas;
    public audioandcanvasmanager.soundname mysoundtype;


    public void nextcanvas()
    {

        foreach (var name in audioandcanvasmanager.nextcanvas.GetNames(mynextcanvas.GetType()))
        {
            if (name == mynextcanvas.ToString())
            {

                audioandcanvasmanager.instance.findvideo(name);
            }
        }
    }
    public void theaudio()
    {

        foreach (var name in audioandcanvasmanager.soundname.GetNames(mysoundtype.GetType()))
        {
            if (name == mysoundtype.ToString())
            {

                audioandcanvasmanager.instance.findaudio(name);
            }
        }
    }


}
