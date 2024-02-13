using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    void Update()
    {
        transform.Translate(0,-0.01f,0);
        if(transform.position.y<-10){
            transform.position = new Vector3(0,9.74f,1);
        }
    }
}
