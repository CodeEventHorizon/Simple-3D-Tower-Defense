using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    private void Start() {
        StartCoroutine(goToMain());
    }
    IEnumerator goToMain() {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(1);
    }
}
