using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Math_Script : MonoBehaviour
{
    private TMP_Text math;

    private int firstNum;
    private int secondNum;
    private int symbol;
    public int answer;

    // Start is called before the first frame update
    void Start()
    {
        math = GameObject.Find("math_text").GetComponent<TMP_Text>();
        CreateProblem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 문제를 생성하는 함수
    void CreateProblem(){

        firstNum = Random.Range(1,100);
        secondNum = Random.Range(1,99);
        symbol = Random.Range(0,2);

        if(symbol == 0){
            math.text = $"{firstNum}+{secondNum} ?";
            answer = firstNum + secondNum;
        }else {
            if (secondNum > firstNum){
                math.text = $"{secondNum}-{firstNum} ?";
                answer = secondNum - firstNum;
            }else {
                math.text = $"{firstNum}-{secondNum} ?";
                answer = firstNum - secondNum;
            }
            
        }

        print(answer);
        
    }
}
