#define BUILD_RELEASE
//#undef BUILD_RELEASE

using UnityEngine;
using UnityEngine.UI;
using Assets;
using System;

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
            //Check to see if there is an active user. This is done so that if a user registers after completing mazes 
            //(And before exit) they don't lose their completed maze history

            if(!GameContext.m_context.m_activeUser.IsNull())
            {
                activeUser = GameContext.m_context.m_activeUser;
            }
            else
            { 
                activeUser = AccountData.GetInstance();
            }


            if (activeUser != null && !activeUser.IsNull())
            {
                SetGamerTag(activeUser);
                setEmail(activeUser);
                setPassword(activeUser);
            }

            String path = Application.persistentDataPath;

#if (BUILD_RELEASE)
            path = Application.dataPath;
#endif

            AccountDataSaveLoad.SaveAccountData(path + "/Account.dat", activeUser);

            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneConstants.MainMenuScene);
        }

        public void cancel()
        {
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
    }
}
