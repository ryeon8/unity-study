using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private GameObject coin;
    private float minY = -7f;
    [SerializeField]
    private float hp = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    // 충돌 감지.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;

            if (hp <= 0)
            {
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }

            Destroy(other.gameObject); // 쓰레기와 충돌한 미사일 객체 제거.
        }
    }

    // 물리적 충돌 처리.
    // private void OnCollisionEnter2D(Collision2D other)
    // {

    // }
}
