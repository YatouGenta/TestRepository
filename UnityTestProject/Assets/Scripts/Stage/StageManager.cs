using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public void OnClickReturnButton()
    {
        SceneManager.LoadScene("Title");
    }
}
