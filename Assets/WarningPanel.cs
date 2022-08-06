using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanel : MonoBehaviour
{

    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        particleSystem1?.gameObject.SetActive(true);
        particleSystem2?.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        try
        {
            particleSystem1.gameObject.SetActive(false);
            particleSystem2.gameObject.SetActive(false);
        }
        catch
        {

        }

    }
}
