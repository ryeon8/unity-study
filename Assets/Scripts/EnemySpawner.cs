using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float[] arrPosX = { -2.2f, -1.1f, 0, 1.1f, 2.2f };
    [SerializeField]
    private GameObject[] enemise;

    private float lastSpawnTime;
    [SerializeField]
    private float spawnInterval = 1.5f;

    private int guaranteeEasyEnemySpawnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    // 코루틴을 이용한 방식
    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        // yield return new WaitForSeconds(spawnInterval);

        int spawnCount = 0;
        int index = 0;
        while (true)
        {
            foreach (float posX in arrPosX)
            {
                // int index = Random.Range(minEnemyLevel, maxEnemyLevel);
                SpawnEnemy(posX, index, spawnCount);
            }

            spawnCount++;
            if (spawnCount % 3 == 0)
            {
                index = ClampedEnemyIndex(++index);
            }
            yield return new WaitForSeconds(spawnInterval);
        }

    }

    // // 여태까지 배운 걸 기반해 내가 작성한 코드
    // void Update()
    // {
    //     if (Time.time - lastSpawnTime > spawnInterval)
    //     {
    //         SpawnEnemies();
    //         lastSpawnTime = Time.time;
    //     }
    // }

    // void SpawnEnemies()
    // {
    //     foreach (float posX in arrPosX)
    //     {
    //         int index = Random.Range(0, enemise.Length);
    //         SpawnEnemy(posX, index);
    //     }
    // }

    void SpawnEnemy(float posX, int index, int spawnCount)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, 0f);
        index = SometimesHiger(index, spawnCount);
        Instantiate(enemise[index], spawnPos, Quaternion.identity);
    }

    int SometimesHiger(int index, int spawnCount)
    {
        if (spawnCount > guaranteeEasyEnemySpawnCount && Random.Range(0, 5) == 0)
        { // 20% 확률로 한 단계 더 어려운 적 생성.
            return ClampedEnemyIndex(++index);
        }

        return index;
    }

    int ClampedEnemyIndex(int index)
    {
        return Mathf.Clamp(index, 0, enemise.Length);
    }
}
