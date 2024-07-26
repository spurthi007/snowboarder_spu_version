using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeDelay=2f;
    [SerializeField] ParticleSystem crashParticle;
    
   void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.tag=="Ground")
        {
            crashParticle.Play();
            Invoke("ReloadScene", invokeDelay);  
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Crashing");
    }

}
