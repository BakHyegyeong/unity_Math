using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumPard_Delete_Script : MonoBehaviour
{

    private Camera main_camera;

    private SpriteRenderer sp_Render;
    private Color originColor;
    private Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        main_camera = Camera.main;
        sp_Render = GetComponent<SpriteRenderer>();
        originColor = sp_Render.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            //화면에서 마우스 위치를 반환
            Vector3 worldPoint = main_camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null){
                if(hit.collider.gameObject == gameObject){
                    GameObject.Find("Answer").GetComponent<Answer_Script>().deleteNum();

                    changeColor();
                }
            }
                  
        }
    }

    void changeColor(){

        ColorUtility.TryParseHtmlString("#" + "E37B7B", out newColor);
        sp_Render.color = newColor;

        StopAllCoroutines();
        StartCoroutine(ResetColor(0.3f));
    }

    IEnumerator ResetColor(float second){
        yield return new WaitForSeconds(second);

        sp_Render.color = originColor;
    }
}
