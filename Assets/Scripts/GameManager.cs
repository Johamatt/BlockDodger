using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject box;
    public GameObject stone;
    public float maxX;
    public Transform spawnPoint;

    private bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    public AudioClip soundClip;
    private AudioSource audioSource;

    private int score = 0;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
    }

    private void Update()
    {
        if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            audioSource.Play();
            tapText.SetActive(false);
            StartSpawning();
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnStone), 0.5f, 0.3f); 
        InvokeRepeating(nameof(SpawnBox), 10f, 1f); 
    }

    private void SpawnStone()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(stone, spawnPos, Quaternion.identity);
        UpdateScore(1);
    }

    private void SpawnBox()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(box, spawnPos, Quaternion.identity);
        UpdateScore(2);
    }

    private void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
