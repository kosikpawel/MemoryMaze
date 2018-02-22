using UnityEngine;
using UnityEngine.UI;
public class ChangeControl : MonoBehaviour {
    Text changeControl;
    private int phase;
    public static int phaseStatic;

    void Start() {
        changeControl = GetComponentInChildren<Text>();
        phase = phaseStatic;
        if (phase == 2) {
            changeControl.text = "Pad control";
        }
        else if (phase == 3) {
            changeControl.text = "Swipe control";
        }
        else {
            changeControl.text = "Classic control";
        }
    }
    public void onClickOne() {
        if (phase == 1) {
            changeControl.text = "Pad control";
            phase = 2;
            phaseStatic = phase;
        }
        else if (phase == 2) {
            changeControl.text = "Swipe control";
            phase = 3;
            phaseStatic = phase;
        }
        else {
            changeControl.text = "Classic control";
            phase = 1;
            phaseStatic = phase;
        }
    }
}
