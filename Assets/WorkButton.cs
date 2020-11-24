using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WorkButton : MonoBehaviour
{
    public clickScript toggle;
    void OnMouseDown()
    {
        toggle.ToggleVisibility();
    }
}
