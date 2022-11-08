using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBoxAnimController : MonoBehaviour
{
    public Animator animatorBox;
    public Animator animatorSmoke;
    private BoxCollider2D bc2d;

    private void Awake() {
        bc2d = GetComponent<BoxCollider2D>();    
    }
    
    public void DestroyBox(){
        animatorBox.SetTrigger("playBrokenAnim");
        animatorSmoke.SetTrigger("playSmokeAnim");
        
        Destroy(bc2d);            
        Destroy(gameObject, 5);
    }
}
