using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 10f;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start() // 게임 객체를 비활성화했다가 다시 활성화하는 경우에도 호출된다.
    {
        Destroy(gameObject, 1f); // gameObject = 바로 현재 Weapon. 1초 후에 파괴됨.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
