using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public static AsyncOperation CurrentOperation => currentOperation;

    private static AsyncOperation currentOperation = null;

    public static bool LoadSceneAsync(string sceneName) {
        //Look up if scene name exists
        bool sceneExists = IsSceneNameInList(sceneName);

        if (sceneExists) 
            currentOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        return sceneExists;
    }

    public static bool LoadSceneAsyncAdditive(string sceneName) {
        //Look up if scene name exists
        bool sceneExists = IsSceneNameInList(sceneName);

        if (sceneExists)
            currentOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        return sceneExists;
    }

    private static bool IsSceneNameInList(string sceneName) {
        return Application.CanStreamedLevelBeLoaded(sceneName);
    }

    public static bool? IsSceneLoaded() {
        bool? isSceneLoaded = null;
        if (currentOperation != null)
            isSceneLoaded = currentOperation.isDone;

        return isSceneLoaded;
    }

    public static float? GetProgress() {
        float? progress = null;
        if (currentOperation != null)
            progress = currentOperation.progress;

        return progress;
    }
}