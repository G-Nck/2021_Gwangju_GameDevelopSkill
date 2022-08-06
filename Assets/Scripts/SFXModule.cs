using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXModule : MonoBehaviour
{

    public AudioSource source;
    


    public void PlaySource()
    {
        Instantiate(source, transform.position, transform.rotation);
    }
}
