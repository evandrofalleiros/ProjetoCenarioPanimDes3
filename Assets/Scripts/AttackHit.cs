using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other){
            if (other.gameObject.CompareTag("Box")){
                other.gameObject.GetComponent<BrokenBoxAnimController>().DestroyBox();
            }
        }        
    }
}
