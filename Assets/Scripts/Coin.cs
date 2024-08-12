using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;

    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    void Jump()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        float randomJumpForce = Random.Range(4f, 8f);
        Vector2 jumpVelopcity = Vector2.up * randomJumpForce;
        jumpVelopcity.x = Random.Range(-1f, 1f);

        rigidbody2D.AddForce(jumpVelopcity, ForceMode2D.Impulse);
    }
}
