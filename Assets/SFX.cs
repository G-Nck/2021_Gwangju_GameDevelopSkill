using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    AudioSource m_AudioSource;


    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();   
    }
    void Start()


    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_AudioSource.isPlaying) Destroy(gameObject);   
    }
}
