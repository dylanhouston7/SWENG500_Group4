using UnityEngine;
using UnityEngine.UI;
using Assets;

using System.Collections.Generic;

namespace Account
{
    public class AccountManager : MonoBehaviour
    {
        public InputField gamerTagInput;
        public InputField emailInput;
        public InputField passwordInput;
        public InputField confirmPassInput;

        private Account.AccountData activeUser;

        public void Awake()
        {
            activeUser = null;
        }

        public void createUser()
        {
            activeUser = AccountData.GetInstance();
        }

        public void registerUser()
        {
            activeUser = AccountData.GetInstance();

            if (activeUser != null && !activeUser.IsNull())
            {
                SetGamerTag(activeUser);
                setEmail(activeUser);
                setPassword(activeUser);
            }

            AccountDataSaveLoad.SaveAccountData(Application.persistentDataPath + "/Account.dat", activeUser);

            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainMenuScene);
        }

        private void SetGamerTag(Account.AccountData user)
        {
            if (user != null)
            {
                activeUser.gamerTag = gamerTagInput.text;
            }
        }

        private void setEmail(Account.AccountData user)
        {
            if (user != null)
            {
                activeUser.email = emailInput.text;
            }
        }

        private void setPassword(Account.AccountData user)
        {
            if (user != null)
            {
                if (passwordInput.text == confirmPassInput.text)
                {
                    activeUser.password = passwordInput.text;
                }
            }
        }

        /*public void SaveMazes()
        {
            MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/EasyMazes.dat", easyMazes);
            MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/MediumMazes.dat", mediumMazes);
            MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/HardMazes.dat", hardMazes);
            MazeDataSaveLoad.SaveMazeData(Application.persistentDataPath + "/EpicMazes.dat", epicMazes);
        }*/
    }
}
