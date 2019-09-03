using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public bool _isButton = false;

    private void Update()
    {
        if (_isButton)
        {
            GetComponent<Button>().Select();
        }
    }

    public void ChangeScene(string scene)
    {
        print("ok");
        SceneManager.LoadScene(scene);
    }
}
