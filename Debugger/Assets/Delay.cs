using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delay : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoad = 10f;

    [SerializeField]
    private string sceneName;

    private float timeElapsed;
    // Update is called once per frame
    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed >= delayBeforeLoad)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
