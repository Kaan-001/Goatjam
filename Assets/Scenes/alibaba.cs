using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alibaba : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool bikere=true;
    void Start()
    {
        if(bikere)
        {
            DontDestroyOnLoad(this.gameObject);
            bikere=false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
