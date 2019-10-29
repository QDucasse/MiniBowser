using System;
using System.Collections.Generic;

namespace MiniBowserGUI
{
    public partial class HistWindow : Gtk.Window
    {
        public MainWindow ParentWin
        { get; set; }

        public HistWindow(MainWindow mainWindow) :
                base(Gtk.WindowType.Toplevel)
        {
            ParentWin = mainWindow;
            Build();
            InitializeHistory();
        }

        public void InitializeHistory()
        {
            int n = ParentWin.mb.History.UrlList.Count;
            urlEntry1.Text = ParentWin.mb.History.UrlList[n-1];
            urlEntry2.Text = ParentWin.mb.History.UrlList[n-2];
            urlEntry3.Text = ParentWin.mb.History.UrlList[n-3];
            urlEntry4.Text = ParentWin.mb.History.UrlList[n-4];
            urlEntry5.Text = ParentWin.mb.History.UrlList[n-5];
            urlEntry6.Text = ParentWin.mb.History.UrlList[n-6];
            urlEntry7.Text = ParentWin.mb.History.UrlList[n-7];
            urlEntry8.Text = ParentWin.mb.History.UrlList[n-8];
        }

        protected void GoButton1Clicked(object sender, EventArgs e)
        {
            string site = urlEntry1.Text;
            Destroy();
            ParentWin.LoadSite(site);
        }

        protected void GoButton2Clicked(object sender, EventArgs e)
        {
            string site = urlEntry2.Text;
            Destroy();
            ParentWin.LoadSite(site);
        }

        protected void GoButton3Clicked(object sender, EventArgs e)
        {
            string site = urlEntry3.Text;
            Destroy();
            ParentWin.LoadSite(site);
        }

        protected void GoButton4Clicked(object sender, EventArgs e)
        {
            string site = urlEntry4.Text;
            Destroy();
            ParentWin.LoadSite(site);
        }

        protected void GoButton5Clicked(object sender, EventArgs e)
        {
            string site = urlEntry5.Text;
            Destroy();
            ParentWin.LoadSite(site);
        }

        protected void GoButton6Clicked(object sender, EventArgs e)
        {
            string site = urlEntry6.Text;
            Destroy();
            ParentWin.LoadSite(site);
        }

        protected void GoButton7Clicked(object sender, EventArgs e)
        {
            string site = urlEntry7.Text;
            Destroy();
            ParentWin.LoadSite(site);
        }

        protected void GoButton8Clicked(object sender, EventArgs e)
        {
            string site = urlEntry8.Text;
            Destroy();
            ParentWin.LoadSite(site);
        }

        protected void ClearHistoryButtonClicked(object sender, EventArgs e)
        {
            urlEntry1.Text = "";
            urlEntry2.Text = "";
            urlEntry3.Text = "";
            urlEntry4.Text = "";
            urlEntry5.Text = "";
            urlEntry6.Text = "";
            urlEntry7.Text = "";
            urlEntry8.Text = "";
            ParentWin.mb.History.UrlList = new List<string>() { "", "", "", "", "", "", "", "" };
            ParentWin.mb.History.PreviousSites = new Stack<string>();
            ParentWin.mb.History.NextSites = new Stack<string>();
            ParentWin.CheckButtonsStatus();
            Destroy();
        }
    }
}
