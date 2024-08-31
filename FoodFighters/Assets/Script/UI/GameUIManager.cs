using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pause;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(!pause.activeSelf);
            Time.timeScale = !pause.activeSelf ? 1.0f : 0.0f;
        }
    }
}
