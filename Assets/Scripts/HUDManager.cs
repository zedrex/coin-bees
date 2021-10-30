using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI gameText;

    [SerializeField]
    private TextMeshProUGUI guideText;

    [SerializeField]
    private Image heart0;

    [SerializeField]
    private Image heart1;

    [SerializeField]
    private Image heart2;

    [SerializeField]
    private Sprite heartFull;

    [SerializeField]
    private Sprite heartEmpty;

    // Start is called before the first frame update
    void Start()
    {
        gameText.SetText("Collect Coins & Avoid Bees");
        scoreText.SetText(" x " + player.score + " of 25");
        Invoke("VanishGameText", 3.0f);
        Invoke("VanishGuideText", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(" x " + player.score + " of 25");
        Debug.Log(player.score);

        if (player.hasWon)
        {
            gameText.SetText("You Win!");
            Invoke("RestartLevel", 1.5f);
        }


        if (player.isDead)
        {
            gameText.SetText("Game Over");
            Invoke("RestartLevel", 1.5f);
        }


        if (player.life == 0)
        {
            heart0.sprite = heartEmpty;
            heart1.sprite = heartEmpty;
            heart2.sprite = heartEmpty;
        }
        else if (player.life == 1)
        {
            heart0.sprite = heartFull;
            heart1.sprite = heartEmpty;
            heart2.sprite = heartEmpty;
        }
        else if (player.life == 2)
        {
            heart0.sprite = heartFull;
            heart1.sprite = heartFull;
            heart2.sprite = heartEmpty;
        }
        else if (player.life == 3)
        {
            heart0.sprite = heartFull;
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
        }
    }


    void VanishGameText()
    {
        gameText.SetText("");
    }

    void VanishGuideText()
    {
        guideText.SetText("");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }
}
