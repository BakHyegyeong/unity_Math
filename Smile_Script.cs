using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Smile_Script : MonoBehaviour
{
    private Camera main_camera;

    public GameObject smile;
    Image smile_image;

    Color[] colors = {Color.red, Color.blue, Color.green, Color.black};
    int index = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        main_camera = Camera.main;
        smile_image = smile.GetComponent<Image>();
        
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

                    if(index >= colors.Length){
                        index = 0;
                    }

                    changeSmile(colors[index]);
                    index ++;
                }
            }
                  
        }
    }

    void changeSmile(Color smile_color){

        smile_image.color = smile_color;
        
        smile_image.transform.Rotate(new Vector3(0f, 0f, 90f));
        
    }
}
