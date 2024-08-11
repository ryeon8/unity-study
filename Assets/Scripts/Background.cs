using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f;
    private float height = -10f;

    // Update is called once per frame
    void Update() // 실행 기기 성능에 따라 1초에 한번 호출될 수도 있고, 3초에 한번 호출될 수도 있음.
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime; // Time.deltaTime fps와 관계 없이 동일 시간 내 동일한 이동 보장.
        if (transform.position.y < height)
        {
            transform.position += new Vector3(0, 10 * 2f, 0); // 띠용...? 객체를 할당하는데 위에서는 수식을 쓴 거야?? 뭐여...?
        }
    }
}
