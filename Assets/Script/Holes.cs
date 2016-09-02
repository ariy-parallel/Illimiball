using UnityEngine;
using System.Collections;

public class Holes : MonoBehaviour {

    public Hole red;
    public Hole blue;
    public Hole green;

    private Rect labelPosition = new Rect (0, 0, 100, 30);

    private string getLabel()
    {
        if (red.fallIn && blue.fallIn && green.fallIn)
        {
            return "Fall in hole!";
        }
        else
        {
            return "";
        }
    }

    void OnGUI()
    {
        GUI.Label (labelPosition, getLabel ());
    }
}
