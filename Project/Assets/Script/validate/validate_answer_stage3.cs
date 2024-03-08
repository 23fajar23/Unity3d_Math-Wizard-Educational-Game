using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validate_answer_stage3 : MonoBehaviour
{

    public string receive_data(string value, int question)
    {
        value = replace_space(value);
        string back_value = "";
        switch(question)
        {
            case 1:
                back_value = verify_normal(value);
                break;
            case 2:
                back_value = del_curly_brackets_from_normal(value);
                back_value = del_elbow_brackets_from_normal(back_value);
                back_value = del_double_normal_brackets(back_value);
                back_value = change_brackets_coma(back_value);
                back_value = del_double_normal_brackets(back_value);
                back_value = del_double_normal_brackets(back_value);
                back_value = del_double_normal_brackets(back_value);
                break;
            case 3:
                back_value = verify_normal(value);
                break;
            case 4:
                back_value = verify_normal(value);
                break;
            case 5:
                back_value = verify_normal(value);
                break;
            case 6:
                back_value = verify_normal(value);
                break;
            case 7:
                back_value = verify_normal(value);
                break;
            case 8:
                back_value = verify_normal(value);
                break;
            case 9:
                back_value = value_char(value);
                back_value = del_coma(back_value);
                back_value = del_variable(back_value);
                back_value = del_variable_up(back_value);
                break;
            case 10:
                back_value = verify_normal(value);
                break;
        }

        return back_value;
    }

    public string del_variable(string value)
    {
        string value2 = value.Replace("a", "");
        return value2.Replace("b", "");
    }

    public string del_variable_up(string value)
    {
        string value2 = value.Replace("A", "");
        return value2.Replace("B", "");
    }

    public string replace_space(string value)
    {
        return value.Replace(" ", "");
    }

    public string del_normal_brackets(string value)
    {
        string value2 = value.Replace("(", "");
        return value2.Replace(")", "");
    }

    public string del_curly_brackets(string value)
    {
        string value2 = value.Replace("{", "");
        return value2.Replace("}", "");
    }

    public string del_elbow_brackets(string value)
    {
        string value2 = value.Replace("[", "");
        return value2.Replace("]", "");
    }

    public string del_dot_zero(string value)
    {
        return value.Replace(".0", "");
    }

    public string del_curly_brackets_from_normal(string value)
    {
        string value2 = value.Replace("{", "(");
        return value2.Replace("}", ")");
    }

    public string del_elbow_brackets_from_normal(string value)
    {
        string value2 = value.Replace("[", "(");
        return value2.Replace("]", ")");
    }
    
    public string del_double_normal_brackets(string value)
    {
        string value2 = value.Replace("((", "(");
        return value2.Replace("))", ")");
    }

    public string change_brackets_coma(string value)
    {
        string value2 = value.Replace("),", ")");
        return value2.Replace(",(", "(");
    }

    public string del_coma(string value)
    {
        return value.Replace(",", "");
    }

    public string value_char(string value)
    {
        string value2 = value.Replace("=", "");
        value2 = value2.Replace(";", "");
        return value2.Replace(":", "");
    }

    public string verify_normal(string value)
    {
        string back_value = del_normal_brackets(value);
        back_value = del_curly_brackets(back_value);
        back_value = del_elbow_brackets(back_value);
        back_value = del_dot_zero(back_value);
        return back_value;
    }

}
