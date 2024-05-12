using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class finishtext : MonoBehaviour
{
    public Text intro;
    public string introtext;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Textmachine());
    }
    public IEnumerator Textmachine()
    {   
      
        
        
         char[] currentChars = introtext.ToCharArray();
                for (int i = 0; i < currentChars.Length; i++)
                {
                   yield return new WaitForSeconds(0.05f);
                   intro.text += currentChars[i];
                }
                
                yield return new WaitForSeconds(1);

                SceneManager.LoadScene(0);
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
