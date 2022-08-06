using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RedCell : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public UnityEvent OnDetectBullet;


    bool dashStarted = false;
    public void OnProjDetected()
    {
        if (dashStarted) return;
        dashStarted = true;

        OnDetectBullet?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (dashStarted) return;
        Projectile proj;
        RaycastHit2D[] result = Physics2D.BoxCastAll(transform.position, new Vector2(2, 2), 0, Vector2.down, 0.1f);
        foreach(RaycastHit2D hit in result)
        {
            if(hit.collider.TryGetComponent<Projectile>(out proj))
            {
                OnProjDetected();
            }
        }


    }
}
