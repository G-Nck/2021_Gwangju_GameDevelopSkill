using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public float damageMultiplier;

    public float damage;

    [HideInInspector]
    public Character.Team team;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * Time.fixedDeltaTime * moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x > 1.1f || viewPos.x < -0.1f)
        {
            Destroy(gameObject);
        }
        else if (viewPos.y > 1.05f || viewPos.y < -0.1f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out LivingEntity entity))
        {
            if (entity.attackedThisFrame) return;
            if (entity.isGod) return;
            if(entity.team != this.team)
            {
                entity.GetDamage(damage * damageMultiplier);
                Destroy(gameObject);
            }
        }
    }

}
