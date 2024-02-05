using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class TimedSceneChange : MonoBehaviour
{
    public float sceneChangeDelay;
    public VisualEffect portal;

    public int sceneToLoad = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneChangeWithDelay());
    }

    IEnumerator SceneChangeWithDelay()
    {
        yield return new WaitForSeconds(2);
        portal.enabled = true;
        yield return new WaitForSeconds(sceneChangeDelay);
        SceneManager.LoadScene(sceneToLoad);
    }
}
