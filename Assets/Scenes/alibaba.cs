using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class alibaba : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool bikere=true;
    public Health player;
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
    public  void playerdead()
    {

        SceneManager.LoadScene(3);
    }
    void Update()
    {
        if(player!=null)
        {
             if(player.currentHealth<=0)
        {
            playerdead();
        }
        }
       
    }
}
