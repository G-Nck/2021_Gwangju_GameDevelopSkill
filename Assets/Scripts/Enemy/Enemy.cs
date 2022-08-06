using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Character
{

    public UnityEvent OnEnemyDisabled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableCharacter()
    {
        OnEnemyDisabled?.Invoke();
    }


    public void StartSpawnAnim()
    {
        StartCoroutine(SpawnEffect());
    }

    IEnumerator SpawnEffect()
    {
        float timer = 1.5f;
        float scale = transform.lossyScale.x;
        while (timer > 0)
        {
            timer -= Time.deltaTime;

            float tempScale = Mathf.Lerp(0, scale, 1.5f - timer / 1.5f);
            transform.localScale = new Vector3(tempScale, tempScale, tempScale);


            yield return null;
        }
        yield break;
    }


}
