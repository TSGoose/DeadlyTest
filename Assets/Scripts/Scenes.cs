using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DeadlyTest.Architecture
{
    public class Scenes : MonoBehaviour
    {
        private void Start()
        {
            //SceneManager.LoadScene(0);
        }
        public static void OpenGame()
        {
            SceneManager.LoadScene(0);
        }

        public static void OpenMenu()
        {
            SceneManager.LoadScene(1);
        }

        public static void OpenSettings()
        {
            SceneManager.LoadScene(2);
        }

        public static void OpenDeadScreen()
        {
            SceneManager.LoadScene(3);
        }
    }
}