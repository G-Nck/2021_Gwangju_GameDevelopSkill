using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public Background partner;


    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.fixedDeltaTime * scrollSpeed);


 
    }

    // Update is called once per frame
    void Update()

    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.y <= -1)
        {
            transform.position = partner.transform.position + new Vector3(0, 20, 0);
        }
    }
}
