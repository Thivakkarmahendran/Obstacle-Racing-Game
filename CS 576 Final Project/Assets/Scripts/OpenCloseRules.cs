using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseRules : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pnl;
    public void OpenCloseRule(){
        if(!pnl.activeSelf)
            pnl.SetActive(true);
        else
            pnl.SetActive(false);
    }
}
