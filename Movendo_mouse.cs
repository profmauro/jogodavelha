using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movendo_mouse : MonoBehaviour
{
    public Sprite SemMouse, ComMouse;
       
    public void MovendoLapis(){
      Vector3 mousepos;
      mousepos = Input.mousePosition;
      mousepos = Camera.main.ScreenToWorldPoint(mousepos);
      this.gameObject.transform.localPosition = new Vector3(mousepos.x, mousepos.y, 0);
    }

    public void semMouse(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = SemMouse;
    }

    public void comMouse(){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ComMouse;
    }
}
