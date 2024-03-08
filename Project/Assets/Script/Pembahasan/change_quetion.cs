using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_quetion : MonoBehaviour
{
    public List<GameObject> question;
    public int open_now = 0;
    public Text[] change_answer;
    public Text player_choose_answer;
    public List<GameObject> button_answer;
    public List<GameObject> change_answer_stage;
    public Text true_essay;
    public Sprite[] question_image;
    public SpriteRenderer img_question;
    public Button[] btn_control;
    public AudioSource click_sound;

    public Color trueColor;
    public Color falseColor;
    public Color normalColor;

    private string[] true_answer1 = {};
    private string[] true_answer2 = {};
    private string[] true_answer3 = {};
    private string[] true_answer3_backup = {};
    
    private string[] player_answer1 = {};
    private string[] player_answer2 = {};
    private string[] player_answer3 = {};

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 90;
        
        open_now = 1;
        Story1 story1 = new Story1();
        true_answer1 = story1.true_answer;
        true_answer2 = story1.true_answer2;
        true_answer3 = story1.true_answer3;
        true_answer3_backup = story1.true_answer3_backup;

        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        player_answer1 = all.save_answer_stage1;
        player_answer2 = all.save_answer_stage2;
        player_answer3 = all.save_answer_stage3;

        
    }

    public void next_open()
    {
        open_now = open_now + 1;
        click_sound.Play();
    }

    public void prev_open()
    {
        open_now = open_now - 1;
        click_sound.Play();
    }

    public void control_button()
    {
        if(open_now == 1)
        {
            btn_control[0].interactable = false;
        }else{
            btn_control[0].interactable = true;
        }

        if(open_now == 30)
        {
            btn_control[1].interactable = false;
        }else{
            btn_control[1].interactable = true;
        }

    }
    
    public void to_true(string valueTrue, string player)
    {
        button_answer[0].GetComponent<Image>().color = normalColor;
        button_answer[1].GetComponent<Image>().color = normalColor;
        button_answer[2].GetComponent<Image>().color = normalColor;
        button_answer[3].GetComponent<Image>().color = normalColor;

        if(valueTrue != player)
        {
            change_color(player,false);
        }

        change_color(valueTrue,true);

    }

    public void change_color(string value, bool answerPlayer)
    {
        Color useThis = trueColor;

        if(answerPlayer == true)
        {
            useThis = trueColor;
        }else if(answerPlayer == false){
            useThis = falseColor;
        }

        if(value == "a")
        {
            button_answer[0].GetComponent<Image>().color = useThis;
        }

        if(value == "b")
        {
            button_answer[1].GetComponent<Image>().color = useThis;
        }

        if(value == "c")
        {
            button_answer[2].GetComponent<Image>().color = useThis;
        }

        if(value == "d")
        {
            button_answer[3].GetComponent<Image>().color = useThis;
        }
    }

    // Update is called once per frame
    void Update()
    {
        control_button();

        disable_all();
        question[open_now-1].SetActive(true);
        
        if(open_now >= 1 && open_now <= 10)
        {
            stage1();
        }

        if(open_now >= 11 && open_now <= 20)
        {
            stage2();
            button_answer[0].SetActive(true);
            button_answer[1].SetActive(true);
            button_answer[2].SetActive(true);
            button_answer[3].SetActive(true);
            change_answer_stage[0].SetActive(false);
            change_answer_stage[1].SetActive(false);
            change_answer_stage[2].GetComponent<Image>().color = normalColor;
        }

        if(open_now >= 21 && open_now <= 30)
        {
            stage3();
            button_answer[0].SetActive(false);
            button_answer[1].SetActive(false);
            button_answer[2].SetActive(false);
            button_answer[3].SetActive(false);
            change_answer_stage[0].SetActive(true);
            change_answer_stage[1].SetActive(true);
        }
        
    }

    public void to_detail(string value)
    {
        if(value == "a")
        {
            player_choose_answer.text = change_answer[0].text;
        }else if(value == "b")
        {
            player_choose_answer.text = change_answer[1].text;
        }else if(value == "c")
        {
            player_choose_answer.text = change_answer[2].text;
        }else if(value == "d")
        {
            player_choose_answer.text = change_answer[3].text;
        }else{
            player_choose_answer.text = "";
        }
    }

    public void stage1()
    {
        switch(open_now)
        {
            case 1:
                img_question.sprite = question_image[7];
                change_answer[0].text = "Gambar Pertama";
                change_answer[1].text = "Gambar Kedua";
                change_answer[2].text = "Keduanya benar";
                change_answer[3].text = "Keduanya salah";
                break;
            case 2:
                img_question.sprite = question_image[2];
                change_answer[0].text = "4";
                change_answer[1].text = "5";
                change_answer[2].text = "6";
                change_answer[3].text = "9";
                break;
            case 3:
                img_question.sprite = question_image[2];
                change_answer[0].text = "{(2,4),(3,9)}";
                change_answer[1].text = "{(2,4),(-2,4),\n(3,9),(-3,9}";
                change_answer[2].text = "{(2,4),(2,9)}";
                change_answer[3].text = "{(2,4),(4,9)}";
                break;
            case 4:
                change_answer[0].text = "{2,3,4,5}";
                change_answer[1].text = "{2,4,5,6}";
                change_answer[2].text = "{3,4,5,6}";
                change_answer[3].text = "{2,3,5,6}";
                break;
            case 5:
                img_question.sprite = question_image[6];
                change_answer[0].text = "Gambar Pertama";
                change_answer[1].text = "Gambar Kedua";
                change_answer[2].text = "Keduanya benar";
                change_answer[3].text = "Keduanya salah";
                break;
            case 6:
                img_question.sprite = question_image[5];
                change_answer[0].text = "{(2,7),(3,9),\n(4,11),(5,13)}";
                change_answer[1].text = "{(2,9),(3,4),\n(4,11),(5,13)}";
                change_answer[2].text = "{(2,7),(3,9),\n(4,7),(5,13)}";
                change_answer[3].text = "{(2,7),(3,9),\n(4,11),(5,12)}";
                break;
            case 7:
                img_question.sprite = question_image[5];
                change_answer[0].text = "Bijektif";
                change_answer[1].text = "Injektif";
                change_answer[2].text = "Surjektif";
                change_answer[3].text = "Tidak jelas";
                break;
            case 8:
                img_question.sprite = question_image[5];
                change_answer[0].text = "4x + 3";
                change_answer[1].text = "2x + 3";
                change_answer[2].text = "5x - 3";
                change_answer[3].text = "6x + 7";
                break;
            case 9:
                change_answer[0].text = "Kuadrat dari";
                change_answer[1].text = "Akar dari";
                change_answer[2].text = "Akar pangkat 3 dari";
                change_answer[3].text = "Pangkat 3 dari";
                break;
            case 10:
                change_answer[0].text = "5";
                change_answer[1].text = "6";
                change_answer[2].text = "25";
                change_answer[3].text = "125";
                break;
        }
        to_true(true_answer1[open_now-1], player_answer1[open_now-1]);
        to_detail(player_answer1[open_now-1]);
    }

    public void stage2()
    {
        switch(open_now)
        {
            case 11:
                img_question.sprite = question_image[5];
                change_answer[0].text = "11";
                change_answer[1].text = "12";
                change_answer[2].text = "15";
                change_answer[3].text = "16";
                break;
            case 12:
                img_question.sprite = question_image[0];
                change_answer[0].text = "{1,3,4,5}";
                change_answer[1].text = "{1,2,3,4}";
                change_answer[2].text = "{4,5,6,7}";
                change_answer[3].text = "{2,3,4,6}";
                break;
            case 13:
                img_question.sprite = question_image[0];
                change_answer[0].text = "{1,3,4,5}";
                change_answer[1].text = "{1,2,3,4}";
                change_answer[2].text = "{4,5,6,7}";
                change_answer[3].text = "{2,3,4,5}";
                break;
            case 14:
                img_question.sprite = question_image[0];
                change_answer[0].text = "{1,3,4,5}";
                change_answer[1].text = "{1,2,3,4}";
                change_answer[2].text = "{4,5,6,7}";
                change_answer[3].text = "{2,3,4,5}";
                break;
            case 15:
                img_question.sprite = question_image[4];
                change_answer[0].text = "Satu kurangnya dari";
                change_answer[1].text = "Dua lebihnya dari";
                change_answer[2].text = "Dua kurangnya dari";
                change_answer[3].text = "Satu lebihnya dari";
                break;
            case 16:
                img_question.sprite = question_image[3];
                change_answer[0].text = "Kuadrat dari";
                change_answer[1].text = "Akar dari";
                change_answer[2].text = "Sama dengan";
                change_answer[3].text = "Lima kali dari";
                break;
            case 17:
                img_question.sprite = question_image[0];
                change_answer[0].text = "Surjektif";
                change_answer[1].text = "Injektif";
                change_answer[2].text = "Bijektif";
                change_answer[3].text = "Tidak tahu";
                break;
            case 18:
                img_question.sprite = question_image[0];
                change_answer[0].text = "{(1,2),(2,3),\n(3,4),(4,5)}";
                change_answer[1].text = "{(1,3),(2,2),\n(3,4),(4,5)}";
                change_answer[2].text = "{(1,2),(2,3),\n(3,5),(4,5)}";
                change_answer[3].text = "{(1,3),(2,1),\n(3,4),(4,5)}";
                break;
            case 19:
                change_answer[0].text = "{3,13,25,45,65}";
                change_answer[1].text = "{3,13,27,45,67}";
                change_answer[2].text = "{3,10,25,47,67}";
                change_answer[3].text = "(3,13,25,45,67}";
                break;
            case 20:
                change_answer[0].text = "{9,17,25,33}";
                change_answer[1].text = "{9,21,25,33}";
                change_answer[2].text = "{9,17,27,35}";
                change_answer[3].text = "{9,17,36,64}";
                break;
        }

        to_true(true_answer2[open_now-11], player_answer2[open_now-11]);
        to_detail(player_answer2[open_now-11]);
    }

    public void stage3()
    {
        if(player_answer3[open_now-21] != "")
        {
            player_choose_answer.text = player_answer3[open_now-21];
        }else{
            player_choose_answer.text = "";
        }
        
        true_essay.text = true_answer3_backup[open_now-21];
        validate_essay();
    }

    public void validate_essay()
    {
        string answer_essay = player_answer3[open_now-21];
        validate_answer_stage3 valid_try = new validate_answer_stage3();
        answer_essay = valid_try.receive_data(answer_essay, open_now-20);
        
        if(open_now == 26)
        {
            if(
                answer_essay == "-0.66" || 
                answer_essay == "-0,66" || 
                answer_essay == "-0.67" || 
                answer_essay == "-0,67" || 
                answer_essay == "-2/3"
                )
            {
                change_answer_stage[1].GetComponent<Image>().color = trueColor;
                change_answer_stage[2].GetComponent<Image>().color = trueColor;
            }else{
                change_answer_stage[1].GetComponent<Image>().color = trueColor;
                change_answer_stage[2].GetComponent<Image>().color = falseColor;
            }
        }else if(answer_essay == true_answer3[open_now-21])
        {
            change_answer_stage[1].GetComponent<Image>().color = trueColor;
            change_answer_stage[2].GetComponent<Image>().color = trueColor;
        }else{
            change_answer_stage[1].GetComponent<Image>().color = trueColor;
            change_answer_stage[2].GetComponent<Image>().color = falseColor;
        }
    }

    public void disable_all()
    {
        question[0].SetActive(false);
        question[1].SetActive(false);
        question[2].SetActive(false);
        question[3].SetActive(false);
        question[4].SetActive(false);
        question[5].SetActive(false);
        question[6].SetActive(false);
        question[7].SetActive(false);
        question[8].SetActive(false);
        question[9].SetActive(false);
        question[10].SetActive(false);
        question[11].SetActive(false);
        question[12].SetActive(false);
        question[13].SetActive(false);
        question[14].SetActive(false);
        question[15].SetActive(false);
        question[16].SetActive(false);
        question[17].SetActive(false);
        question[18].SetActive(false);
        question[19].SetActive(false);
        question[20].SetActive(false);
        question[21].SetActive(false);
        question[22].SetActive(false);
        question[23].SetActive(false);
        question[24].SetActive(false);
        question[25].SetActive(false);
        question[26].SetActive(false);
        question[27].SetActive(false);
        question[28].SetActive(false);
        question[29].SetActive(false);
    }
}
