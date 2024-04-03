using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SugARTechnology.Scripts.UI 
{
    public class MainMenuMidView : MonoBehaviour
    {
        public void PlayButton() 
        {
            SceneManager.LoadScene("GameScene");
        }
        public void QuitButton() 
        {
            Application.Quit();
        }
    }
}
