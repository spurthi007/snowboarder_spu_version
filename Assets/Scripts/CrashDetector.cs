using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeDelay=2f;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] AudioClip crashSFX;
    AudioSource audioSource;
    bool crashed=true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
   void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Ground" && crashed)
            {
                crashParticle.Play();
                audioSource.PlayOneShot(crashSFX);
                //crashSFX.Play();
                FindObjectOfType<PlayerController>().DisableControls();
                crashed=false;
                Invoke("ReloadScene", invokeDelay);  
            }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Crashing");
    }

}
