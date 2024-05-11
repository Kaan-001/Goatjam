using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spritetakip : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     this.gameObject.transform.position=enemy.transform.position+new Vector3(0,0.3f,0);
    }
}
