using UnityEngine;
using System.Collections;

public class GameContext : MonoBehaviour {

    public static GameContext m_context;

    // Public Persistent Storage between Scenes
    public int m_difficultyLevel = 0;

    void Awake()
    {
        if(m_context == null)
        {
            DontDestroyOnLoad(gameObject);
            m_context = this;
        }
        else if(m_context != this)
        {
            // Ensure the same context persists between scenes
            Destroy(gameObject);
        }
    }
}
