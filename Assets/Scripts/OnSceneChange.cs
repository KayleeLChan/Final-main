using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSceneChange : MonoBehaviour
{
    //Load new scene depending on build's scene index
    public void ChangeLevel (int levelIndex)
    {
        DelayChange();
        SceneManager.LoadScene(levelIndex);
    }

    public void DelayChange()
    {
        StartCoroutine(FinishFade());
    }

    //Wait for black screen to fade in
    IEnumerator FinishFade()
    {
        yield return new WaitForSeconds(1);
    }
}
