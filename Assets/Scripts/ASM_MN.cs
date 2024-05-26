using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Threading;
using System;
using UnityEngine.SocialPlatforms.Impl;

[SerializeField]
public class Region
{
    public int ID;
    public string Name;
    public Region(int ID, string Name)
    {
        this.ID = ID;
        this.Name = Name;
    }
}

[SerializeField]
public class Players
{
    public int Id {get;set;}
    public string Name {get;set;}
    public int Score {get;set;}
    public Region PlayerRegion {get;set;}
    public string Rank { get; set; }
    ScoreKeeper sc;
    public Players(int id, string name, int score, Region region)
    {
        Id = id;
        Name = name;
        Score = score;
        PlayerRegion = region;
        Rank = calculate_rank(score);
    }
    private string calculate_rank(int score)
    {
        if (score < 100)
        {
            return "Hạng Đồng";
        }
        else if (score >= 100 && score < 500)
        {
            return "Bạc";
        }
        else if (score >= 500 && score < 1000)
        {
            return "Vàng";
        }
        else
        {
            return "Kim cương";
        }
    }
}

public class ASM_MN : Singleton<ASM_MN>
{
    public List<Region> listRegion = new List<Region>();
    public List<Players> listPlayer = new List<Players>();

    private void Start()
    {
        createRegion();
    }

    public void createRegion()
    {
        listRegion.Add(new Region(0, "VN"));
        listRegion.Add(new Region(1, "VN1"));
        listRegion.Add(new Region(2, "VN2"));
        listRegion.Add(new Region(3, "JS"));
        listRegion.Add(new Region(4, "VS"));
    }

    public void YC1()
    {

        String name = ScoreKeeper.Instance.GetUserName();
        int id = ScoreKeeper.Instance.GetID();
        int idR = ScoreKeeper.Instance.GetIDregion();

        int score = ScoreKeeper.Instance.GetScore();
        String regionName = ""; 

        if(idR == 0)
        {
            regionName = "VN";
        }
        else if (idR == 1)  
        {
            regionName = "VN1";
        }
        

        Players player1 = new Players(id, "Nam", 50, new Region(1, "VN1"));
        listPlayer.Add(player1);

        Players player2 = new Players(id, "Bin", 400, new Region(2, "VN2"));
        listPlayer.Add(player2);

        Players player3 = new Players(id, "Thor", 200, new Region(3, "JS"));
        listPlayer.Add(player3);

        Players player4 = new Players(id, "Hulk", 300, new Region(4, "VS"));
        listPlayer.Add(player4);
        /*thêm thông tin người chơi mới khi nhập từ text */
        Region playerRegion1 = new Region(idR, regionName);
        Players player0 = new Players(id, name, score, playerRegion1);
        listPlayer.Add(player0);
    }
    public void YC2()
    {
        foreach (Players player in listPlayer)
        {

            Debug.Log("Player Name: " + player.Name + " - Score: " + player.Score+" - Region: " + player.PlayerRegion.Name);    
        }
    }
    public void YC3()
    {
        int currentPlayerScore = ScoreKeeper.Instance.GetScore();

        foreach (Players player in listPlayer)
        {
            if (player.Score < currentPlayerScore)
            {
                Debug.Log("Player ID: " + player.Id + " - Name: " + player.Name + " - Score: " + player.Score + " - Region: " + player.PlayerRegion.Name + " - Rank: " + player.Rank);
            }
        }

    }
    public void YC4()
    {
        // sinh viên viết tiếp code ở đây
    }
    public void YC5()
    {
        // sinh viên viết tiếp code ở đây
    }
    public void YC6()
    {
        // sinh viên viết tiếp code ở đây
    }
    public void YC7()
    {
        // sinh viên viết tiếp code ở đây
    }
    void CalculateAndSaveAverageScoreByRegion()
    {
        // sinh viên viết tiếp code ở đây
    }

}

