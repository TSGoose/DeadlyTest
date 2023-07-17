using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DeadlyTest.Architecture
{
    public class Menu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartButtonClick()
        {
            Scenes.OpenGame();
        }

        public void SettingsButtonClick()
        {
            Scenes.OpenSettings();
        }

        public void ExitButtonClick()
        {
            Application.Quit();
        }
    }
}
