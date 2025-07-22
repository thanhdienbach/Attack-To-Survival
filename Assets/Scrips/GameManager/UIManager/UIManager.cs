using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    #region instance
    public static UIManager instance;
    void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void OnDisable()
    {
        instance = null;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
