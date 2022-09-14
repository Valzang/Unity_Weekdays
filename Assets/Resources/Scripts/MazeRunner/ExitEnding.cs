using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitEnding : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (MazeManager.Instance.itemLeft == 0 && other.CompareTag("Player"))
            SceneManager.LoadScene("Escape");
    }
}
