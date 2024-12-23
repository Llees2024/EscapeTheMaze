using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class AIBackAndForth : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;
    public float gameTime = 360f;

    private NavMeshAgent agent;
    private bool movingToB = true;
    private bool isGameOver = false;
    private float timer;

    private bool isFrozen = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.SetDestination(pointB.position);
        gameOverText.gameObject.SetActive(false);
        timer = gameTime;
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            GameOver();
        }

        if (isFrozen) return;

        if (Vector3.Distance(agent.transform.position, agent.destination) < 0.1f)
        {
            if (movingToB)
            {
                agent.SetDestination(pointA.position);
            }
            else
            {
                agent.SetDestination(pointB.position);
            }

            movingToB = !movingToB;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver();
        }

        if (other.CompareTag("BlueCube"))
        {
            FreezeEnemy();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    void UpdateTimerUI()
    {
        timerText.text = "Time Left: " + Mathf.Max(0, Mathf.FloorToInt(timer)).ToString();
    }


    void FreezeEnemy()
    {
        isFrozen = true;
        agent.isStopped = true;

    }
}
