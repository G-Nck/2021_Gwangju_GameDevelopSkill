using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCell : Character
{
    public Item[] item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropItem()
    {

        Instantiate(item[Random.Range(0, item.Length)], transform.position, transform.rotation);

    }

}
