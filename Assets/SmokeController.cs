using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    void destroyObject(){
        gameObject.SetActive(false);
        Destroy(this);
    }
}
