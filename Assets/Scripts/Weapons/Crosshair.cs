using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Texture2D crosshairTexture;

    public void Awake() {
        Cursor.visible = false;
    }

    public void OnGUI() {

        GUI.DrawTexture(new Rect(Input.mousePosition.x - 16, Screen.height-Input.mousePosition.y - 16, 32, 32), crosshairTexture, ScaleMode.ScaleToFit, true, 1.0f);

    }

}
