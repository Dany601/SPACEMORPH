using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Casa2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void CAMBIOPISO(string Casa2)
    {
        SceneManager.LoadScene(Casa2);
    }
}
