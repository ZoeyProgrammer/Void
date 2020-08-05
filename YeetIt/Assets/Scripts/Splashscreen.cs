using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splashscreen : MonoBehaviour
{
    public Image logo;
    public Image gaLogo;

    private bool loadingMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gaLogo.color.a >= 0)
        {
            gaLogo.color = new Color(gaLogo.color.r, gaLogo.color.g, gaLogo.color.b, gaLogo.color.a - 0.01f);
        }
        else if (logo.color.a <= 1)
        {
            logo.color = new Color(logo.color.r, logo.color.g, logo.color.b, logo.color.a + 0.01f);
        }
        else if (loadingMenu == false && gaLogo.color.a <= 0 && logo.color.a >= 1)
        {
            loadingMenu = true;
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}
