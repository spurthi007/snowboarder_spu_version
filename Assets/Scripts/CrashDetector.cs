using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeDelay=2f;
    [SerializeField] ParticleSystem crashParticle;
    
   void OnCollisionEnter2D(Collision2D other)
    {
                if(other.gameObject.tag=="Ground")
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
