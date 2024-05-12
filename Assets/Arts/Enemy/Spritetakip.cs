using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Spritetakip : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    void Start()
    {
        this.transform.DOScale(1.2f,0.6f).SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.gameObject.transform.position=enemy.transform.position+new Vector3(0,0.3f,0);
    }
}
