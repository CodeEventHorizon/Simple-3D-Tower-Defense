using UnityEngine;

public class Fading : MonoBehaviour
{
    public Texture2D fadeTexture;
    [SerializeField] [Range(0.0f,1.0f)] float speed = 0.1f;
    private float alpha = 1.0f;
    private int depth = -1000;
    private int fadeDirection = -1;
    void OnGUI()
    {
        alpha += fadeDirection * speed * Time.deltaTime;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = depth;
        Rect dimension = new Rect(0,0, Screen.width, Screen.height);
        GUI.DrawTexture(dimension, fadeTexture);
    }
}
