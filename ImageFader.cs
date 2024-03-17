using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFader : MonoBehaviour
{
    // Start is called before the first frame update
    private CanvasGroup canvasGroup;
    
    // Start is called before the first frame update
    void Start()
    {
       canvasGroup = GetComponent<CanvasGroup>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime /4 ;
            if (canvasGroup.alpha <= 0)
            {
                Destroy(gameObject);
                
            }
        }



    }
    
}
