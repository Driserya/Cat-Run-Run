using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouae : MonoBehaviour
{
    public Texture2D texture2D;

    private void Start()
    {
        Cursor.SetCursor(texture2D, Vector2.zero, CursorMode.Auto); //修改光标材质
    }

}
