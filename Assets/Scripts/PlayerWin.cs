using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField]
    public Player player;


    [SerializeField]
    private AudioSource winSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flag") && player.score == 25)
        {
            Destroy(collision.gameObject);
            winSound.Play();
            player.hasWon = true;
        }
    }
}
