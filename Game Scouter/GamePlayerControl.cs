using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Riot.NET;
using Riot.NET.StaticData;

namespace LoL_Helper.Game_Scouter
{
    public partial class GamePlayerControl : UserControl
    {
        public Color ColorRedTeam { get; set; } = Color.LightCoral;
        public Color ColorBlueTeam { get; set; } = Color.SteelBlue;

        public CurrentGameParticipant Participant { get; set; }
        
        public string QueryName { get; set; }

        public LeagueDto LeagueInfo { get; set; }
        public PlayerSBN PlayerInfo { get; set; }

        public GamePlayerControl()
        {
            InitializeComponent();
        }

        public void UpdateInfo()
        {
            if (Participant == null)
                return;

            this.BackColor = Participant.TeamID == 100 ? ColorBlueTeam : ColorRedTeam;

            if (Participant.SummonerName.ToLower() == QueryName.ToLower())
                this.BackColor = this.BackColor.Brighten(25);

            lblSummName.Text = Participant.SummonerName;
            picChampIcon.BackgroundImage = SChampion.GetChampionIcon((int)Participant.ChampionID);

            if (LeagueInfo != null)
            {
                lblRank.Text = LeagueInfo.Tier.FirstUpper() + " " + LeagueInfo.Entries[0].Division;

                if (LeagueInfo.Tier == "MASTER" || LeagueInfo.Tier == "CHALLENGER")
                    picLeague.BackgroundImage = Image.FromFile("TierIcons/" + LeagueInfo.Tier.ToLower() + ".png");
                else
                    picLeague.BackgroundImage = Image.FromFile("TierIcons/" + LeagueInfo.Tier.ToLower() + "_" + LeagueInfo.Entries[0].Division.ToLower() + ".png");
                lblLP.Text = LeagueInfo.Entries[0].LeaguePoints.ToString();

                if (LeagueInfo.Entries[0].MiniSeries != null)
                {
                    MiniSeriesDto msd = LeagueInfo.Entries[0].MiniSeries;
                    lblSeries.Visible = true;
                    label2.Visible = true;
                    lblSeries.Text = msd.Progress.Replace("N", " - ").Replace("L", " L").Replace("W"," W ");
                }
            } else if (PlayerInfo.SummonerLevel == 30)
            {
                lblRank.Text = "Unranked";
                picLeague.BackgroundImage = Image.FromFile("TierIcons/provisional.png");
            } else if (PlayerInfo.SummonerLevel < 30)
            {
                lblRank.Text = "Level " + PlayerInfo.SummonerLevel;
            }

            picSumm1.BackgroundImage = SSummSpells.GetIcon((int)Participant.Spell1ID);
            picSumm2.BackgroundImage = SSummSpells.GetIcon((int)Participant.Spell2ID);
        }

        private void GamePlayerControl_Load(object sender, EventArgs e)
        {

        }

        private void picLeague_Click(object sender, EventArgs e)
        {
            panLeagueInfo.Show();
            tPanelReset.Start();
        }

        private void tPanelReset_Tick(object sender, EventArgs e)
        {
            panLeagueInfo.Hide();
            tPanelReset.Stop();
        }

        private void panLeagueInfo_Click(object sender, EventArgs e)
        {
            panLeagueInfo.Hide();
            tPanelReset.Stop();
        }
    }
}
