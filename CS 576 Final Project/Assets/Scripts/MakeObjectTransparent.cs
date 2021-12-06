using UnityEngine;

public class MakeObjectTransparent : MonoBehaviour
{

    public GameObject currentGameObject;
    public bool transparent = false;
    public float alpha = 0f;//half transparency
    //Get current material
    private Material currentMat;


    // Start is called before the first frame update
    void Start()
    {
        //currentGameObject = gameObject;
        currentMat = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (transparent == true)
        {
            ChangeAlpha(currentMat, 0.0f);
            Color oldColor = currentMat.color;
            Debug.Log(oldColor.b);
        }
        else
        {
            ChangeAlpha(currentMat, 0.1f);
        }
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);

    }


}

