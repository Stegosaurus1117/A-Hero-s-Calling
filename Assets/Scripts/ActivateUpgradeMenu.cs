using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateUpgradeMenu : MonoBehaviour
{
    private GameObject upgradeMenu;
    private GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
        upgradeMenu = GameObject.Find("UpgradeMenu");
        Panel = GameObject.Find("Panel");
        upgradeMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            AppearUpgradeMenu();
        }
    }

    public void AppearUpgradeMenu()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);

        Color col = Color.black;

        if (upgradeMenu.activeSelf)
        {
            col = new Color(50f, 50f, 50f, 0.8f);
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
