using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Answer_Script : MonoBehaviour
{

    private TMP_Text user_input;

    //팝업추가!
    public GameObject popup;
    public TMP_Text popup_text;
    Image panel;
    private Color incorrect_Color;
    private Color correct_Color;

    //종료팝업
    public GameObject finish_popup;

    private int answer;
    private int user_answer;
    //List<string> userNum = new List<string>();

    //이스터에그
    float currentTime;
    bool isEasterEggActive;

    //씬 다시 시작
    bool isRestart;
    static int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        user_input = GameObject.Find("answer_text").GetComponent<TMP_Text>();

        currentTime = 0;
        isEasterEggActive = false;
        isRestart = false;

        finish_popup.SetActive(false);
        popup.SetActive(false);
        panel = popup.GetComponent<Image>();
        ColorUtility.TryParseHtmlString("#" + "E37B7B", out incorrect_Color);
        ColorUtility.TryParseHtmlString("#" + "C5E0B4" , out correct_Color);
    }

    // Update is called once per frame
    void Update()
    {
        if(isEasterEggActive){
            currentTime += Time.deltaTime;

            if(currentTime > 0.5){
                user_input.text = "";
                currentTime = 0;
                isEasterEggActive = false;
            }
        }

        if(isRestart){
            currentTime += Time.deltaTime;

            if(currentTime > 2){
                restartGame();
            }
        }
    }

    public void putNum(string num){

        if(user_input.text.Length > 0 && user_input.text.Length < 3){

            //userNum.Add(num);
            user_input.text += num;

        }else{

            if(num == "0" || user_input.text.Length > 3){
                // 아무것도 하지 않음
            }else{
                //userNum.Add(num);
                user_input.text += num;
            }
  
        }
        
    }

    public void deleteNum(){
        if(user_input.text.Length > 0){
            user_input.text = user_input.text.Substring(0,user_input.text.Length -1);
        }else {
            //이스터에그!
            user_input.text = "><";
            isEasterEggActive = true;
        }
    }

    public void putAnswer(){
        user_answer = int.Parse(user_input.text);
        //userNum.Clear();
        user_input.text = "";
        print("user_answer : " + user_answer);

        answer = GameObject.Find("Math").GetComponent<Math_Script>().answer;

        answerCheck();
    }

    public void answerCheck(){
        if(answer == user_answer){

            count += 1;
            print("count = " + count);

            if(count == 3){
                finishPopup();
                count = 0;
                isRestart = true;
            }else{
                showPopup("정답입니다!"+ "\n" + " 다음문제!");
                panel.color = correct_Color;
                isRestart = true;
            }

        }else {
            showPopup("다시 해보세요!");
            panel.color = incorrect_Color;
        }
    }

    public void showPopup(string message){
        popup_text.text = message;
        popup.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(HidePopup(popup));
    }

    IEnumerator HidePopup(GameObject input_popup){

        yield return new WaitForSeconds(3);

        GameObject hide_popup = input_popup;
        hide_popup.SetActive(false);
    }

    void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void finishPopup(){
        finish_popup.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(HidePopup(finish_popup));
    }
}
