using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{


    public Vector2 moveDir;

    public float moveSpeed;

    public UnityEvent OnFireInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDir * Time.fixedDeltaTime * moveSpeed);
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0, 1);
        viewPos.y = Mathf.Clamp(viewPos.y, 0, 1);

        transform.position = Camera.main.ViewportToWorldPoint(viewPos);


    }

    void Update()
    {

        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if(Input.GetAxisRaw("Fire1") == 1) OnFireInput?.Invoke();
    }

    private void LateUpdate()
    {
    }
}
