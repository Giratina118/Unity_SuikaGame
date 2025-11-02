using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankingBook : MonoBehaviour
{
    private string[] rankingScoreString;

    public void ShowRankingBook()
    {
        for (int i = 1; i < 21; i++)
        {
            rankingScoreString[i - 1] = PlayerPrefs.GetInt(i.ToString()).ToString();
            if (rankingScoreString[i - 1].Equals("0"))
                rankingScoreString[i - 1] = "------";
        }

        this.GetComponent<TMP_Text>().text = "1    " + rankingScoreString[0] + " \t\t11   " + rankingScoreString[10] + "\n2    " + rankingScoreString[1] + " \t\t12   " + rankingScoreString[11] +
            "\n3    " + rankingScoreString[2] + " \t\t13   " + rankingScoreString[12] + "\n4    " + rankingScoreString[3] + " \t\t14   " + rankingScoreString[13] +
            "\n5    " + rankingScoreString[4] + " \t\t15   " + rankingScoreString[14] + "\n6    " + rankingScoreString[5] + " \t\t16   " + rankingScoreString[15] +
            "\n7    " + rankingScoreString[6] + " \t\t17   " + rankingScoreString[16] + "\n8    " + rankingScoreString[7] + " \t\t18   " + rankingScoreString[17] +
            "\n9    " + rankingScoreString[8] + " \t\t19   " + rankingScoreString[18] + "\n10  " + rankingScoreString[9] + " \t\t20   " + rankingScoreString[19];
    }

    void Start()
    {
        rankingScoreString = new string[20];
        ShowRankingBook();
    }
}
