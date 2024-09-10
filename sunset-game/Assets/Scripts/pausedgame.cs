using UnityEngine;

public class pausedgame : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject UI;

    Interagir interagir;

    void Start()
    {
        interagir = FindAnyObjectByType<Interagir>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !interagir.cartaAberta)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        UI.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        UI.SetActive(false);
    }
}
