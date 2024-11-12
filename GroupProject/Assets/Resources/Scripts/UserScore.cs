using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class UserScore
{
    public string Name { get; set; }
    public int Score { get; set; }
    public UserScore() { }
    public UserScore(string name, int score)
    {
        Name = name;
        Score = score;
    }
    public static List<UserScore> GetScores()
    {
        try
        {
            using FileStream file = File.Open("scores.xml", FileMode.Open);
            var xs = new XmlSerializer(typeof(List<UserScore>));
            return (List<UserScore>)xs.Deserialize(file);
        }
        catch
        {
            return new List<UserScore>();
        }
    }

    public static void SaveScores(List<UserScore> scores)
    {
        try
        {
            using FileStream file = File.Open("scores.xml", FileMode.Create);
            file.SetLength(0);
            var xs = new XmlSerializer(typeof(List<UserScore>));
            xs.Serialize(file, scores);
        }
        catch 
        {
            using FileStream file = File.Create("scores.xml");
            file.SetLength(0);
            var xs = new XmlSerializer(typeof(List<UserScore>));
            xs.Serialize(file, scores);
        }
    }
}
