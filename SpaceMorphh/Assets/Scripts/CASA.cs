using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CASA : MonoBehaviour
{
    // Start is called before the first frame update
    public void CambioCasa(string Casa)
    {
        SceneManager.LoadScene(Casa);
    }
}
