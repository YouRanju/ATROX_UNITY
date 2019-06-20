using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class RankingView : MonoBehaviour
{
    string m_strPath = "./RankingSave.txt";
    List<string[]> ranking = new List<string[]>();
    int cnt;

    public Text first;
    public Text second;
    public Text third;

    private void Start()
    {
        cnt = 0;
    }

    public void Parse()
    {
        FileStream fs = new FileStream(m_strPath, FileMode.Open);
        StreamReader sr = new StreamReader(fs);

        string source = sr.ReadLine();
        string[] values;             

        while (source != null)
        {
            values = source.Split(',');

            if (values.Length == 0)
            {
                sr.Close();
                return;
            }

            ranking.Add(new string[2]);
            ranking[cnt][0] = values[0];
            ranking[cnt++][1] = values[1];

            source = sr.ReadLine(); 
            
        }

        if(ranking != null)
        {
            SortingRank(0, ranking.Count - 1);

            first.text = ranking[0][0] + "\n" + ranking[0][1];

            if(ranking.Count >= 2)
            {
                second.text = ranking[1][0] + "\n" + ranking[1][1];
                if(ranking.Count >= 3)
                {
                    third.text = ranking[2][0] + "\n" + ranking[2][1];
                } else
                {
                    third.text = "None" + "\n" + "0";
                }
            } else
            {
                second.text = "None" + "\n" + "0";
                third.text = "None" + "\n" + "0";
            }
        } else
        {
            first.text = "None" + "\n" + "0";
            second.text = "None" + "\n" + "0";
            third.text = "None" + "\n" + "0";
        }
        
    }

    string Tempname;
    string Tempscore;

    void SortingRank(int left, int right)
    {
        int pivot = left;
        int j = pivot;
        int i = left + 1;

        if (left < right)
        {
            for (; i <= right; i++)
            {
                if (int.Parse(ranking[i][1]) > int.Parse(ranking[pivot][1]))
                {
                    j++;

                    Tempname = ranking[j][0];
                    Tempscore = ranking[j][1];

                    ranking[j][0] = ranking[i][0];
                    ranking[j][1] = ranking[i][1];

                    ranking[i][0] = Tempname;
                    ranking[i][1] = Tempscore;

                }
            }

            Tempname = ranking[left][0];
            Tempscore = ranking[left][1];

            ranking[left][0] = ranking[j][0];
            ranking[left][1] = ranking[j][1];

            ranking[j][0] = Tempname;
            ranking[j][1] = Tempscore;

            pivot = j;

            SortingRank(left, pivot - 1);
            SortingRank(pivot+1, right);
        }
    }
}
