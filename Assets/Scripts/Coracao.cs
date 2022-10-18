using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coracao : MonoBehaviour
{
    public float scale; 
    public float scaleTime; 
    public float showPrefabTime; 

    void Start(){
        Vector2 ls = gameObject.transform.localScale;
        Vector2 scaled = new Vector2(ls.x * scale, ls.y * scale);

        LeanTween.alpha(gameObject, 1f, showPrefabTime).setEase(LeanTweenType.easeInCirc);
        LeanTween.scale(gameObject, scaled, scaleTime).setEase(LeanTweenType.easeOutBounce).setLoopPingPong();
    }
}
