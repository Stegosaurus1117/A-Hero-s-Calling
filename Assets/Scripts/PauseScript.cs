using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private GameObject pauseMenu;
    private GameObject Panel;
    public GameObject UpgradeButton;



    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("Pause Menu");
        Panel = GameObject.Find("Panel");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Cursor.visible);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivatePauseMenu();
        }
    }

    public void ActivatePauseMenu()
    {
        if (!Score.UpgradeMenuActive)
        {
            UpgradeButton.SetActive(!UpgradeButton.activeSelf);
            Score.PauseActive = !Score.PauseActive;
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            Score.isPlaying = !Score.isPlaying;
            Cursor.visible = false;
            Cursor.visible = pauseMenu.activeSelf;
            Color col = Color.black;

            if (pauseMenu.activeSelf)
            {
                col = new Color(0f, 0f, 0f, 0.7f);
                Time.timeScale = 0;
            }
            else
            {
                col = new Color(0f, 0f, 0f, 0f);
                Time.timeScale = 1;
            }

            Panel.GetComponent<Image>().color = col;
        }
    }
}
