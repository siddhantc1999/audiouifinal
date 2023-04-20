using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startpos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<RectTransform>().position = new Vector3(3.947571f, 0f, 0f);

        Debug.Log("the rect transform " + transform.GetComponent<RectTransform>().position);
    }
}
