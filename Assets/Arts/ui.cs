using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ui : MonoBehaviour
{
    // Start is called before the first frame update
    public Image colorchanger;
   
    void Start()
    {
        this.transform.DOScale(0.8f,0.5f).SetLoops(-1,LoopType.Yoyo);
        colorchanger.DOColor(Color.red,2f).SetLoops(-1,LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
