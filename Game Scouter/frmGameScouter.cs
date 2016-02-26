using Riot.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoL_Helper.Game_Scouter;
using System.Runtime.InteropServices;

namespace LoL_Helper
{
    public partial class frmGameScouter : LoL_Helper.CustomForm
    {

        public frmGameScouter()
        {
            InitializeComponent();
        }

        private CurrentGameInfo cgi;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            tGameTime.Stop();
            lblStatus.Text = "Loading...";
            tlpPlayers.Hide();

            
            try
            {
                cgi = CurrentGame.GetCurrentGame(Summoner.GetByName(txtName.Text).First().Value.SummonerID.ToString());
            }
            catch (RiotException ex) when (ex.Status.StatusCode == 404)
            {
                lblStatus.Text = "Summoner not in-game/not found";
                tResetStatus.Start();
                return;
            }

            int columnBlue = 0;
            int columnRed = 0;

            StringBuilder pStr = new StringBuilder();
            cgi.Participants.All(o => 
            {
                pStr.Append(o.SummonerID + ",");
                return true;
            });
            
            Dictionary<string, List<LeagueDto>> lInfo = new Dictionary<string, List<LeagueDto>>(); ;
            try
            {
                lInfo = League.GetEntryByID(pStr.ToString());
            }
            catch (RiotException ex) when (ex.Status.StatusCode == 404)
            {
                // Handle this
            }

            var pInfo = Summoner.GetByID(pStr.ToString());

            tlpPlayers.Controls.Clear();

            foreach (var item in cgi.Participants)
            {
                int team = (int)item.TeamID / 100;
                GamePlayerControl gpc = new GamePlayerControl();
                gpc.Participant = item;
                gpc.PlayerInfo = pInfo[item.SummonerName];
                gpc.QueryName = txtName.Text;

                if (lInfo.ContainsKey(item.SummonerName))
                    gpc.LeagueInfo = lInfo[item.SummonerName][0];

                gpc.UpdateInfo();
                //gpc.Visible = false;

                if (team == 1)
                {
                    tlpPlayers.Controls.Add(gpc, columnBlue, 0);
                    columnBlue++;
                }
                else
                {
                    tlpPlayers.Controls.Add(gpc, columnRed, 1);
                    columnRed++;
                }
            }

            tlpPlayers.Show();
            tGameTime.Start();
            lblStatus.Text = "---";
        }

        private void tResetStatus_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "---";
            tResetStatus.Stop();
        }

        private void tGameTime_Tick(object sender, EventArgs e)
        {
            if (cgi == null)
                return;
            long now = DateTime.Now.ToUnixTime();
            long gametime = cgi.GameStartTime / 1000;
            long elapsed = now - gametime;
            TimeSpan time = TimeSpan.FromSeconds(elapsed);
            string str = time.ToString(@"mm\:ss");
            lblGameTime.Text = str;
        }

        private void frmGameScouter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.C)
            {
                System.IO.File.CreateText("clearcache").Close();
                Application.Restart();
            }
        }
    }
}
