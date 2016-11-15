using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NeedleHeadScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Head") {
            GameManager.isCollide = true;
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            GameManager.isOver = true;
        }
    }
}
