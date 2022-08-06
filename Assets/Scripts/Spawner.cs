using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject clone;

    public float delay;
    private float timer;

    public Vector2 minPos;
    public Vector2 maxPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= delay)
        {
            Spawn();
            timer = 0;
        }

    }

    public void Spawn()
    {
        Vector2 pos = new Vector2(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y));

        Vector2 viewPos = Camera.main.ViewportToWorldPoint(pos);

        GameObject cloneObject = Instantiate(clone, viewPos, Quaternion.identity);
        cloneObject.GetComponent<LivingEntity>().isClone = true;
    }

}
