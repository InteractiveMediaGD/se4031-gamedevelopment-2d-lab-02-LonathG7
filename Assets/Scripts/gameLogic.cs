using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLogic : MonoBehaviour
{
    [Header("Game Stats")]
    public int health = 100;
    public int score = 0;

    [Header("UI References")]
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI scoreDisplay;

    void Start()
    {
        // Ensure UI matches starting stats
        UpdateUI();
    }

    // Consolidated: Only ONE OnTriggerEnter2D is allowed per script
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Check for the original Obstacle (Matches by Object Name)
        if (other.gameObject.name == "Obstacle")
        {
            health -= 10;
            score += 5; // Reward for surviving the hit
            // Usually, we don't Destroy the floor or static obstacles
        }

        // 2. Check for Enemies (Matches by Tag)
        if (other.CompareTag("Enemy"))
        {
            health -= 20; // Red things hurt more!
            Destroy(other.gameObject); // Remove enemy after impact
        }

        // 3. Check for Health Packs (Matches by Tag)
        if (other.CompareTag("HealthPack"))
        {
            health += 15; // Green things heal!

            // Keep health from going over the maximum
            if (health > 100)
            {
                health = 100;
            }

            Destroy(other.gameObject); // Remove pack after pickup
        }

        // Always update the UI after a collision happens
        UpdateUI();

        // Optional: Check if the player died
        if (health <= 0)
        {
            Debug.Log("Game Over!");
            // You could add SceneManager.LoadScene(0); here to restarta
        }
    }

    void UpdateUI()
    {
        // Check to make sure you dragged the UI into the Inspector slots
        if (healthDisplay != null) healthDisplay.text = "Health: " + health;
        if (scoreDisplay != null) scoreDisplay.text = "Score: " + score;
    }
}