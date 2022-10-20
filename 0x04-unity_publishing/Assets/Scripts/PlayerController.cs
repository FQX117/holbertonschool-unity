using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerBody;
    public float speed = 1000;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Image winLoseImg;
    public Text winLoseText;

    // triggered for interactables
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            SetWin();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    // Update the movement of the player
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        playerBody.AddForce(movement * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            // Debug.Log("Game Over!");
            SetLose();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    // Set ScoreText with the current player score
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Set HealthText with the current player health
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    // Set the Win when goal is trigger
    void SetWin()
    {
        winLoseImg.color = Color.green;
        winLoseText.color = Color.black;
        winLoseText.text = "You Win!";
        winLoseImg.gameObject.SetActive(true);
        StartCoroutine(LoadScene(3));
    }

    // Set the lose when player have no health
    void SetLose()
    {
        winLoseImg.color = Color.red;
        winLoseText.color = Color.white;
        winLoseText.text = "Game Over!";
        winLoseImg.gameObject.SetActive(true);
        StartCoroutine(LoadScene(3));
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
