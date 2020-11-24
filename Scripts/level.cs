using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;
    
    
    
    public void CountBlocks()
    {
        breakableBlocks++;
    }
    public void DestroyedBlocks()
    {
        breakableBlocks--;
        
        
        if (breakableBlocks == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
