using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataBase : MonoBehaviour
{
    public TextAsset txt;
    string[,] Sentence;
    int lineSize, rowSize;

    // Start is called before the first frame update
    void Start()
    {
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        rowSize = line[0].Split('\t').Length;
        Sentence = new string[lineSize, rowSize];

        // 한줄에서 탭으로 가능
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++)
            {
                Sentence[i, j] = row[j];
                print(i + "," + j + "," + Sentence[i, j]);
            }
        }
    }
}
