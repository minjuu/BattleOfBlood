using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shooterchar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject character;
    // Start is called before the first frame update

    public void PanelControl(Toggle toggletest)
    {
        if (toggletest.isOn)
            character.gameObject.tag = "Team";
        else
            character.gameObject.tag = "Enemy";
    }
}
