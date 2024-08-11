using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] // unity Inspector > Script에서 설정 가능.
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.1f;
    private float lastShotTime = 0f;

    private float edgeY = 2.35f;

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxisRaw("Horizontal"); // 키보드 방향키 좌우 입력값.
        // float verticalInput = Input.GetAxisRaw("Vertical"); // 키보드 방향키 상하 입력값.
        // verticalInput = 0f;

        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0f); // z 값은 2D라 의미 없음.
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        // if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     transform.position -= moveTo;
        // }
        // else if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     transform.position += moveTo;
        // }

        // Debug.Log(Input.mousePosition); // 마우스 포지션 값은 화면상 해상도 값과 같지 않음. 유니티 화면은 가운데가 0, 0이지만 마우스는 좌측 하단 꼭지점이 0, 0

        // 마우스로 캐릭터 이동
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, edgeY * -1, edgeY); // x, min, max. min보다 작으면 min, max보다 크다면 max 차용.
        transform.position = new Vector3(toX, transform.position.y, 0f);

        // 미사일 쏘기
        Shoot();

    }

    void Shoot()
    {
        if (Time.time - lastShotTime > shootInterval)
        {
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time; // Time.time: 게임이 시작된 이후 현재까지의 시간.
        }

    }
}
