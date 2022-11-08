using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    // Prefab do coração
    public GameObject prefab;

    void destroyObject(){
        gameObject.SetActive(false);
        Destroy(this);
    }

    void spawnLife(){
        bool lifeStatus = Random.value > 0.5;
        Vector2 position = gameObject.transform.position;
        Quaternion rotation = gameObject.transform.rotation;
        
        if (lifeStatus){
            Instantiate(prefab, new Vector2(position.x, position.y + 0.5f), Quaternion.identity);
        }
    }

}
