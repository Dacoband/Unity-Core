using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;  // Đối tượng Prefab của Pipe
    public float spawnInterval = 2f;  // Thời gian giữa các lần sinh Pipe
    public float pipeHeightOffset = 2f;  // Độ lệch cao độ của Pipe

    private float timeSinceLastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nếu đã đủ thời gian để sinh thêm pipe
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPipe();
            timeSinceLastSpawn = 0f;  // Reset lại thời gian
        }
        else
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
    }

    public void SpawnPipe()
    {
        // Tạo một vị trí ngẫu nhiên cho Pipe mới
        float randomHeight = Random.Range(-pipeHeightOffset, pipeHeightOffset);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomHeight, 0);

        // Sinh ra Pipe mới
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
