using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour {

    private static AudioSystem _instance = null;
    public AudioSource[] m_Audiossource = new AudioSource[5];

    /*public static AudioSystem Instance
    {
        get
        {
            if (_instance == null)
                _instance = new AudioSystem();
            return _instance;
        }
    }

    public AudioSystem() {
        
    }*/

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
