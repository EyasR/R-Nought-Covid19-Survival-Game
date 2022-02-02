using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AnyManager anyManager;
    bool gameStart;
    public GameObject playerReference;

    void Awake()
    {
        if (!gameStart)
        {
            anyManager = this;
            gameStart = true;
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
            playerReference.transform.position = new Vector3(-59f, -20f, 0f);
        }
    }

    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload(int scene)
    {
        yield return null;
        SceneManager.UnloadSceneAsync(scene);
    }
}
