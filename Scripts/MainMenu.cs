using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//
// Script was provided by Brackey below is a link to the youtube video
// https://www.youtube.com/watch?time_continue=743&v=zc8ac_qUXQY&feature=emb_title
//
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    // currently not showing debug log
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
