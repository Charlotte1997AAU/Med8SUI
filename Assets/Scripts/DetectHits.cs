using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DetectHits : MonoBehaviour
{
    public int hits;
    public GameObject[] targets; //Array for the prefabs
    string filename;
    float startTime;
    bool savingData = false;
    float saveDelay = 60f; // Time delay before saving data in seconds

    // Start is called before the first frame update
    void Start()
    {
        filename = Application.dataPath + "/TxtFiles/TimestampsTest.txt";
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!savingData && Time.time >= saveDelay)
        {
            savingData = true;
            saveData();
            Debug.Log("SAVED");
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedBullet") && gameObject.CompareTag("RedTarget"))
        {
            hits += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            spawnTarget();
        }

        if (collision.gameObject.CompareTag("BlueBullet") && gameObject.CompareTag("BlueTarget"))
        {
            hits += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            spawnTarget();
        }

        if (collision.gameObject.CompareTag("GreenBullet") && gameObject.CompareTag("GreenTarget"))
        {
            hits += 1;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            spawnTarget();
        }
    }

    void spawnTarget()
    {
        if (targets.Length > 0)
        {
            float randomX = Random.Range(-7f, 7f);
            float randomY = Random.Range(0f, 5f);
            float randomZ = Random.Range(1f, 13f);
            Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

            float randomScale = Random.Range(0.35f, 1f);

            int randomIndex = Random.Range(0, targets.Length);
            GameObject spawnedTarget = Instantiate(targets[randomIndex], randomPosition, Quaternion.identity);

            spawnedTarget.transform.localScale = Vector3.one * randomScale;

            WriteTimestampToFile(Time.time);
        }
    }

    void WriteTimestampToFile(float timestamp)
    {
        using (TextWriter tw = new StreamWriter(filename, true))
        {
            tw.WriteLine(timestamp);
        }
    }

    void saveData()
    {
        string timeStamp = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
        string newFilename = Application.dataPath + "/TxtFiles/Timestamps_" + timeStamp + ".txt";

        File.Move(filename, newFilename);

        Debug.Log("File Saved");

        UnityEditor.EditorApplication.isPlaying = false;
    }
}
