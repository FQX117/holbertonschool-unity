using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CutsceneController : MonoBehaviour
{
    
    public GameObject m_TimerCanvas;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // end cut scene
    public void cutsceneEnd()
    {
        
        m_TimerCanvas.SetActive(true);
    }
}