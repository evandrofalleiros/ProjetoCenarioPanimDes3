using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBoxAnimController : MonoBehaviour
{
    public Animator animatorBox;
    public Animator animatorSmoke;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            animatorBox.SetTrigger("playBrokenAnim");
            animatorSmoke.SetTrigger("playSmokeAnim");

            destroyObject();
        }
    }

    void destroyObject(){
        Destroy(gameObject, 5);
    }
}
