using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Story1 : MonoBehaviour
{

    public Animator camera;
    public Sprite[] buttonSprites;
    public Image[] btn_answer;
    public Button[] btn_answer_condition;
    public Text[] change_answer;
    public Text life_text;
    public Text title_question;
    public InputField essay_answer;
    public Button[] btn_send;
    public Sprite[] question_image;
    public SpriteRenderer img_question;
    public GameObject[] question_destroy;
    public GameObject full_black;

    //new
    public Button[] btn_image;

    public Button btn_menu;
    public Button btn_skip;
    public Button btn_hint;
    
    public Button open_hint;
    
    public Color hintColor;
    public Color normalColor;
    
    public Text content_hint;
    
    public Text show_now_answer;

    public string[] true_answer = {"a","a","b","c","a","a","a","b","c","d" ,"c","c","b","c","a"};
    public string[] true_answer2 = {"c","b","d","d","c","b","c","a","b","a" ,"b","b","a","a","b"};
    public string[] true_answer3 = {"27,315,603,891","(1,11)(2,19)(3,27)(4,35)","51","0,2,12,30","42","-2/3","1,5,71,271","5,37,69,85","105","15"  ,"10","4","4","16","5"};
    public string[] true_answer3_backup = {"{27,315,603,891}","(1,11),(2,19),(3,27),(4,35)","51","{0,2,12,30}","42","-2/3","{1,5,71,271}","{5,37,69,85}","a=10,b=5","15"  ,"10","4","4","16","5"};
    
    public string[] save_answer1 = {"","","","","","","","","",""};
    public string[] save_answer2 = {"","","","","","","","","",""};
    public string[] save_answer3 = {"","","","","","","","","",""};
    public string[] save_answer3_backup = {"","","","","","","","","",""};

    //Bank Jawaban
    public string[] gambar_stage1 = {"7","2","2","-","6","5","5","5","-","-" ,"-","-","-","-","-"};
    public string[] gambar_stage2 = {"5","0","0","0","4","3","0","0","-","-" ,"-","-","-","-","-"};
    public string[,] jawaban_stage1 = {
        {"Gambar Pertama","Gambar Kedua","Keduanya benar","Keduanya salah"},{"4","5","6","9"},{"{(2,4),(3,9)}","{(2,4),(-2,4),\n(3,9),(-3,9}","{(2,4),(2,9)}","{(2,4),(4,9)}"},
        {"{2,3,4,5}","{2,4,5,6}","{3,4,5,6}","{2,3,5,6}"},{"Gambar Pertama","Gambar Kedua","Keduanya benar","Keduanya salah"},{"{(2,7),(3,9),\n(4,11),(5,13)}","{(2,9),(3,4),\n(4,11),(5,13)}","{(2,7),(3,9),\n(4,7),(5,13)}","{(2,7),(3,9),\n(4,11),(5,12)}"},
        {"Bijektif","Injektif","Surjektif","Tidak jelas"},{"4x + 3","2x + 3","5x - 3","6x + 7"},{"Kuadrat dari","Akar dari","Akar pangkat 3 dari","Pangkat 3 dari"},{"5","6","25","125"}
        ,{"{4,6,6,10}","{2,4,6,8}","{4,6,8,10}","{2,3,4,6}"},{"{5,6,8,16}","{6,12,7,14}","{5,6,7,8}","{10,6,7,8}"}
        ,{"{4,12,6,10}","{8,11,14,23}","{8,6,8,10}","{2,10,12,14}"},{"14","22","23","30"}
        ,{"10","6","5","15"}
        };
        
    public string[,] jawaban_stage2 = {
        {"11","12","15","16"},{"{1,3,4,5}","{1,2,3,4}","{4,5,6,7}","{2,3,4,6}"},{"{1,3,4,5}","{1,2,3,4}","{4,5,6,7}","{2,3,4,5}"},
        {"{1,3,4,5}","{1,2,3,4}","{4,5,6,7}","{2,3,4,5}"},{"Satu kurangnya dari","Dua lebihnya dari","Dua kurangnya dari","Satu lebihnya dari"},{"Kuadrat dari","Akar dari","Sama dengan","Lima kali dari"},
        {"Surjektif","Injektif","Bijektif","Tidak tahu"},{"{(1,2),(2,3),\n(3,4),(4,5)}","{(1,3),(2,2),\n(3,4),(4,5)}","{(1,2),(2,3),\n(3,5),(4,5)}","{(1,3),(2,1),\n(3,4),(4,5)}"},
        {"{3,13,25,45,65}","{3,13,27,45,67}","{3,10,25,47,67}","{3,13,25,45,67}"},{"{9,17,25,33}","{9,21,25,33}","{9,17,27,35}","{9,17,36,64}"}
        ,{"5","10","15","20"},{"2","4","3","6"}
        ,{"4","14","24","6"},{"16","20","25","14"}
        ,{"2","5","10","15"}
        };
    
    public string choose_answer = "";
    public int correct_answer = 0;
    public int tidak_tepat_answer = 0;
    public int lewati_answer = 0;
    public float life_now = 5;

    public int question_now = 1;
    public int question_last = 0;

    public bool true_last_answer = false;
    
    public bool start_game = false;
    public int change_img_question = 0;

    public GameObject game_over;

    public AudioSource click_sound;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 90;
        change_img_question = question_now;

        disable_menu();
        disable_skip();
        open_next_question();
        camera.SetBool("battle_slime", true);
        answer_change();

    }

    public void ReadStringInput (string value)
    {
        choose_answer = value;
        show_now_answer.text = value;
    }

    public void answer_change()
    {
        title_question.text = "~~ SOAL " + question_now + " ~~";

        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;
        
        //New
        Event_Random random = new Event_Random();
        Data_Output output = random.LoadFromJson();

        int select_random = 0;

        if(stage_save == 1)
        {
            select_random = output.random_stage1[question_last] - 1;  // menghasilkan soal ke berapa
            
            if(gambar_stage1[select_random] != "-")
            {
                int to_imgs1 = int.Parse(gambar_stage1[select_random]);  // menghasilkan gambar array ke berapa
                img_question.sprite = question_image[to_imgs1];
            }
            
            change_answer[0].text = jawaban_stage1[select_random,0];
            change_answer[1].text = jawaban_stage1[select_random,1];
            change_answer[2].text = jawaban_stage1[select_random,2];
            change_answer[3].text = jawaban_stage1[select_random,3];    
        }

        if(stage_save == 2)
        {
            select_random = output.random_stage2[question_last] - 1;  // menghasilkan soal ke berapa
            
            if(gambar_stage2[select_random] != "-")
            {
                int to_imgs2 = int.Parse(gambar_stage2[select_random]);  // menghasilkan gambar array ke berapa
                img_question.sprite = question_image[to_imgs2];
            }
            
            change_answer[0].text = jawaban_stage2[select_random,0];
            change_answer[1].text = jawaban_stage2[select_random,1];
            change_answer[2].text = jawaban_stage2[select_random,2];
            change_answer[3].text = jawaban_stage2[select_random,3];
        }
        
    }

    public void stop_question()
    {
        camera.SetBool("next_question", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(life_now <= 0 && question_last != 10)
        {
            game_over.SetActive(true);
            stop_question();
        }
        
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();

    }

    public void start_question()
    {
        start_game = true;
    }

    public void reset_true_answer()
    {
        true_last_answer = false;
    }

    public bool get_true_answer()
    {
        return true_last_answer;
    }

    public void reduce_life()
    {
        life_now = life_now - 1;
        life_text.text = life_now.ToString();
        tidak_tepat_answer = tidak_tepat_answer + 1;
    }

    public void add_life()
    {
        life_now = life_now + 1.5f;
        life_text.text = life_now.ToString();
    }

    public void skip_question()
    {
        disable_menu();
        disable_skip();
        disable_hint();
        lewati_answer = lewati_answer + 1;
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;

        Event_Random random = new Event_Random();
        Data_Output output = random.LoadFromJson();
        int select_random = 0;

        
        if(stage_save == 1)
        {
            select_random = output.random_stage1[question_last] - 1;
            btn_send[select_random].interactable = false;
            save_answer1[question_last] = choose_answer;
            next_question();
        }
        
        if(stage_save == 2)
        {
            select_random = output.random_stage2[question_last] - 1;
            btn_send[select_random].interactable = false;
            save_answer2[question_last] = choose_answer;
            next_question();
        }

        if(stage_save == 3)
        {
            select_random = output.random_stage3[question_last] - 1;
            btn_send[select_random].interactable = false;
            save_answer3[question_last] = choose_answer;
            stage3_next_question();
        }
    }

    public void close_battle()
    {
        camera.SetBool("battle_slime", false);
        camera.SetBool("battle_wolf", false);
        camera.SetBool("battle_zombie", false);
        camera.SetBool("battle_ghost", false);
        camera.SetBool("battle_mutant", false);
    }

    public void change_battle()
    {
        close_battle();
        if(question_now <= 3)
        {
            camera.SetBool("battle_slime", true);
        }else if(question_now > 3 && question_now <= 5)
        {
            camera.SetBool("battle_wolf", true);
        }else if(question_now == 6)
        {
            camera.SetBool("battle_zombie", true);
        }else if(question_now > 6 && question_now <= 8)
        {
            camera.SetBool("battle_ghost", true);
        }else if(question_now > 8)
        {
            camera.SetBool("battle_mutant", true);
        }
    }

    public void disable_btn()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;

        Event_Random random = new Event_Random();
        Data_Output output = random.LoadFromJson();

        if(stage_save == 1)
        {
            int select_random = output.random_stage1[question_last] - 1;
            btn_send[select_random].interactable = false;
            
            if(gambar_stage1[select_random] != "-")
            {
                btn_image[select_random].enabled = false;
            }
            
        }

        if(stage_save == 2)
        {
            int select_random = output.random_stage2[question_last] - 1;
            btn_send[select_random].interactable = false;

            if(gambar_stage1[select_random] != "-")
            {
                btn_image[select_random].enabled = false;
            }
            
        }

        btn_answer_condition[0].enabled = false;
        btn_answer_condition[1].enabled = false;
        btn_answer_condition[2].enabled = false;
        btn_answer_condition[3].enabled = false;
        disable_menu();
        disable_skip();
    }

    public void enable_btn()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;

        Event_Random random = new Event_Random();
        Data_Output output = random.LoadFromJson();

        if(stage_save == 1)
        {
            int select_random = output.random_stage1[question_last] - 1;
            btn_send[select_random].interactable = true;
            
            if(gambar_stage1[select_random] != "-")
            {
                btn_image[select_random].enabled = true;
            }
        }

        if(stage_save == 2)
        {
            int select_random = output.random_stage2[question_last] - 1;
            btn_send[select_random].interactable = true;

            if(gambar_stage2[select_random] != "-")
            {
                btn_image[select_random].enabled = true;
            }
        }
        
        btn_answer_condition[0].enabled = true;
        btn_answer_condition[1].enabled = true;
        btn_answer_condition[2].enabled = true;
        btn_answer_condition[3].enabled = true;
        enable_skip();
    }

    public void validate()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;

        Event_Random random = new Event_Random();
        Data_Output output = random.LoadFromJson();
        int select_random = 0;

        
        if(stage_save == 1 || stage_save == 2)
        {
            if(choose_answer == "a" ||choose_answer == "b" ||choose_answer == "c" ||choose_answer == "d" )
            {
                disable_skip();
                disable_menu();
                disable_hint();            

                if(stage_save == 1)
                {
                    select_random = output.random_stage1[question_last] - 1;
                    btn_send[select_random].interactable = false;

                    if(gambar_stage1[select_random] != "-")
                    {
                        btn_image[select_random].enabled = false;
                    }

                    if(choose_answer == true_answer[select_random])
                    {
                        correct_answer++;
                        true_last_answer = true;
                        add_life();
                    }
                    save_answer1[question_last] = choose_answer;
                    next_question();
                }

                if(stage_save == 2)
                {
                    select_random = output.random_stage2[question_last] - 1;
                    btn_send[select_random].interactable = false;

                    if(gambar_stage2[select_random] != "-")
                    {
                        btn_image[select_random].enabled = false;
                    }
                    
                    if(choose_answer == true_answer2[select_random])
                    {
                        correct_answer++;
                        true_last_answer = true;
                        add_life();
                    }
                    save_answer2[question_last] = choose_answer;
                    next_question();
                }
                
                
            }
        }

        if(stage_save == 3)
        {
            select_random = output.random_stage3[question_last] - 1;
            save_answer3_backup[question_last] = choose_answer;

            validate_answer_stage3 valid_try = new validate_answer_stage3();
            choose_answer = valid_try.receive_data(choose_answer, (select_random + 1));
            if(choose_answer != "")
            {
                disable_skip();
                disable_hint();
                disable_menu();
                btn_send[select_random].interactable = false;
                if((select_random + 1) == 6)
                {
                    if(choose_answer == "-0.66" || choose_answer == "-0,66" || choose_answer == "-2/3" || choose_answer == "-0.67" || choose_answer == "-0,67")
                    {
                        correct_answer++;
                        true_last_answer = true;
                        add_life();
                    }
                }else if(choose_answer == true_answer3[select_random])
                {
                    correct_answer++;
                    true_last_answer = true;
                    add_life();
                }
                save_answer3[question_last] = choose_answer;

                stage3_next_question();
            }
            
        }
        
    }

    public void disable_skip()
    {
        btn_skip.interactable = false;
    }

    public void enable_skip()
    {
        btn_skip.interactable = true;
    }

    public void disable_hint()
    {
        btn_hint.interactable = false;
    }

    public void enable_hint()
    {
        btn_hint.interactable = true;
    }

    public void disable_menu()
    {
        btn_menu.interactable = false;
    }

    public void enable_menu()
    {
        btn_menu.interactable = true;
    }

    public void off_menu()
    {
        btn_menu.enabled = false;
    }

    public void on_menu()
    {
        btn_menu.enabled = true;
    }

    public void disable_essay()
    {
        essay_answer.interactable = false;
    }

    public void enable_essay()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;

        if(stage_save == 3)
        {
            essay_answer.interactable = true;
        }
    }

    public void stage3_next_question()
    {
        question_now++;
        question_last++;

        camera.SetBool("close_answer", true);
        
        choose_answer = "";
        essay_answer.text = "";
        show_now_answer.text = "";

    }

    public void next_question()
    {
        question_now++;
        question_last++;

        camera.SetBool("close_answer", true);
        reset_answer();
    }

    public void all_end()
    {
        camera.SetBool("stage_end", true);
    }

    public void to_next_question()
    {
        camera.SetBool("next_question", true);
        change_img_question = question_now;
    }

    public void open_next_question()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;

        Event_Random random = new Event_Random();
        Data_Output output = random.LoadFromJson();
        int select_random = 0;

        if(stage_save == 1)
        {
            select_random = output.random_stage1[question_last];
        }

        if(stage_save == 2)
        {
            select_random = output.random_stage2[question_last];
        }

        if(stage_save == 3)
        {
            select_random = output.random_stage3[question_last];
        }
 
        camera.SetBool("question" + select_random, true);
    }

    public void close_last_question()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;

        Event_Random random = new Event_Random();
        Data_Output output = random.LoadFromJson();

        int select_random = 0;

        if(stage_save == 1)
        {
            select_random = output.random_stage1[question_last-1];
        }

        if(stage_save == 2)
        {
            select_random = output.random_stage2[question_last-1];
        }

        if(stage_save == 3)
        {
            select_random = output.random_stage3[question_last-1];
        }
        
        camera.SetBool("question" + select_random, false);
        camera.SetBool("close_answer", false);
        camera.SetBool("next_question", false);
        
    }

    public void destroy_question()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;

        Event_Random random = new Event_Random();
        Data_Output output = random.LoadFromJson();
        int select_random = 0;

        if(stage_save == 1)
        {
            select_random = output.random_stage1[question_last-1];
        }

        if(stage_save == 2)
        {
            select_random = output.random_stage2[question_last-1];
        }

        if(stage_save == 3)
        {
            select_random = output.random_stage3[question_last-1];
        }
     
        Destroy(question_destroy[select_random-1]);
    }

    public void reset_answer()
    {
        btn_answer[0].sprite = buttonSprites[0];
        btn_answer[1].sprite = buttonSprites[2];
        btn_answer[2].sprite = buttonSprites[4];
        btn_answer[3].sprite = buttonSprites[6];
        choose_answer = "";
    }

    public void select_answer1()
    {
        click_sound.Play();
        if (btn_answer[0].sprite == buttonSprites[1])
        {
            reset_answer();
        }
        else
        {
            reset_answer();
            btn_answer[0].sprite = buttonSprites[1];
            choose_answer = "a";
        }
    }

    public void select_answer2()
    {
        click_sound.Play();
        if (btn_answer[1].sprite == buttonSprites[3])
        {
            reset_answer();
        }
        else
        {
            reset_answer();
            btn_answer[1].sprite = buttonSprites[3];
            choose_answer = "b";
        }
    }

    public void select_answer3()
    {
        click_sound.Play();
        if (btn_answer[2].sprite == buttonSprites[5])
        {
            reset_answer();
        }
        else
        {
            reset_answer();
            btn_answer[2].sprite = buttonSprites[5];
            choose_answer = "c";
        }
    }

    public void select_answer4()
    {
        click_sound.Play();
        if (btn_answer[3].sprite == buttonSprites[7])
        {
            reset_answer();
        }
        else
        {
            reset_answer();
            btn_answer[3].sprite = buttonSprites[7];
            choose_answer = "d";
        }

    }

    public void hint()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        int stage_save = all.play_now;
        
        if(stage_save == 1)
        {
            if(all.save_answer_stage1.Length == 0)
            {
                notice_hint("zero");
            }else{
                string history = all.save_answer_stage1[question_last];
                
                if(history == "")
                {
                    notice_hint("");
                }else{
                    enable_btn();
                    switch_color(history,true);
                }
            }
        }

        if(stage_save == 2)
        {
            if(all.save_answer_stage2.Length == 0)
            {
                notice_hint("zero");
            }else{
                string history = all.save_answer_stage2[question_last];
                
                if(history == "")
                {
                    notice_hint("");
                }else{
                    enable_btn();
                    switch_color(history,true);
                }
            }
        }

        if(stage_save == 3)
        {
            if(all.save_answer_stage3.Length == 0)
            {
                notice_hint("zero");
            }else{
                string history = all.save_answer_stage3[question_last];
                
                if(history == "")
                {
                    notice_hint("");
                }else{
                    enable_btn();
                    enable_essay();
                    essay_answer.text = history;
                    show_now_answer.text = history;
                }
            }
        }
    }

    public void switch_color(string value, bool cekColor)
    {
        Color useThis = normalColor;

        if(cekColor == true)
        {
            useThis = hintColor;
        }else if(cekColor == false){
            useThis = normalColor;
        }

        if(value == "a")
        {
            btn_answer_condition[0].GetComponent<Image>().color = useThis;
        }

        if(value == "b")
        {
            btn_answer_condition[1].GetComponent<Image>().color = useThis;
        }

        if(value == "c")
        {
            btn_answer_condition[2].GetComponent<Image>().color = useThis;
        }

        if(value == "d")
        {
            btn_answer_condition[3].GetComponent<Image>().color = useThis;
        }

    }

    public void notice_hint(string value)
    {
        if(value == "zero")
        {
            content_hint.text = "Selesaikan Stage Ini Terlebih Dahulu !";
        }

        if(value == "")
        {
            content_hint.text = "Anda Belum Pernah Menjawab Pertanyaan Ini";
        }

        disable_btn();
        off_menu();
        open_hint.onClick.Invoke();
    }

}
