using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.SceneManagement;
public class TextMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public String[] introtext;
    public Transform[] newtransf;
    public Camera camera;
    public int introNum;
    public Text intro;
    public Button next;
    public IEnumerator Textmachine()
    {   
        camera.transform.DOMove(newtransf[introNum].position+new Vector3(0,0,-10),1f).SetEase(Ease.OutElastic); 
        yield return new WaitForSeconds(1);
        
         char[] currentChars = introtext[introNum].ToCharArray();
                for (int i = 0; i < currentChars.Length; i++)
                {
                   yield return new WaitForSeconds(0.05f);
                   intro.text += currentChars[i];
                }
                next.gameObject.SetActive(true);
    }
    void Start()
    {
         StartCoroutine(Textmachine());
    }
    public void EkranaTikla()
    {
       
        if(introNum==3)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
        intro.text= "";
        next.gameObject.SetActive(false);
        introNum+=1;
        StartCoroutine(Textmachine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
