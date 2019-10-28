using System;
using System.Collections.Generic;
using MiniBowser;

namespace MiniBowserGUI
{
    public partial class BookmarksWindow : Gtk.Window
    {
        public MainWindow ParentWin
        { get; set; }

        public BookmarksWindow(MainWindow mainWindow) :
                base(Gtk.WindowType.Toplevel)
        {
            ParentWin = mainWindow;
            Build();
            InitializeBookmarks();
        }

        // Methods
        public void InitializeBookmarks()
        {
            nameEntry1.Text = ParentWin.mb.BookmarkList[0].Name;
            nameEntry2.Text = ParentWin.mb.BookmarkList[1].Name;
            nameEntry3.Text = ParentWin.mb.BookmarkList[2].Name;
            nameEntry4.Text = ParentWin.mb.BookmarkList[3].Name;
            nameEntry5.Text = ParentWin.mb.BookmarkList[4].Name;
            nameEntry6.Text = ParentWin.mb.BookmarkList[5].Name;
            nameEntry7.Text = ParentWin.mb.BookmarkList[6].Name;
            nameEntry8.Text = ParentWin.mb.BookmarkList[7].Name;
            urlEntry1.Text = ParentWin.mb.BookmarkList[0].Url;
            urlEntry2.Text = ParentWin.mb.BookmarkList[1].Url;
            urlEntry3.Text = ParentWin.mb.BookmarkList[2].Url;
            urlEntry4.Text = ParentWin.mb.BookmarkList[3].Url;
            urlEntry5.Text = ParentWin.mb.BookmarkList[4].Url;
            urlEntry6.Text = ParentWin.mb.BookmarkList[5].Url;
            urlEntry7.Text = ParentWin.mb.BookmarkList[6].Url;
            urlEntry8.Text = ParentWin.mb.BookmarkList[7].Url;
        }

        public void SaveBookmarks()
        {
            Bookmark bm1 = new Bookmark(nameEntry1.Text, urlEntry1.Text);
            Bookmark bm2 = new Bookmark(nameEntry2.Text, urlEntry2.Text);
            Bookmark bm3 = new Bookmark(nameEntry3.Text, urlEntry3.Text);
            Bookmark bm4 = new Bookmark(nameEntry4.Text, urlEntry4.Text);
            Bookmark bm5 = new Bookmark(nameEntry5.Text, urlEntry5.Text);
            Bookmark bm6 = new Bookmark(nameEntry6.Text, urlEntry6.Text);
            Bookmark bm7 = new Bookmark(nameEntry7.Text, urlEntry7.Text);
            Bookmark bm8 = new Bookmark(nameEntry8.Text, urlEntry8.Text);

            ParentWin.mb.BookmarkList = new List<Bookmark>() { bm1, bm2, bm3, bm4,
                                                               bm5, bm6, bm7, bm8 };
        }

        // Event methods
        // Edition
        protected void EditButtonClicked(object sender, EventArgs e)
        {
            deleteButton1.Sensitive = true;
            deleteButton2.Sensitive = true;
            deleteButton3.Sensitive = true;
            deleteButton4.Sensitive = true;
            deleteButton5.Sensitive = true;
            deleteButton6.Sensitive = true;
            deleteButton7.Sensitive = true;
            deleteButton8.Sensitive = true;
            nameEntry1.Sensitive = true;
            urlEntry1.Sensitive = true;
            nameEntry2.Sensitive = true;
            urlEntry2.Sensitive = true;
            nameEntry3.Sensitive = true;
            urlEntry3.Sensitive = true;
            nameEntry4.Sensitive = true;
            urlEntry4.Sensitive = true;
            nameEntry5.Sensitive = true;
            urlEntry5.Sensitive = true;
            nameEntry6.Sensitive = true;
            urlEntry6.Sensitive = true;
            nameEntry7.Sensitive = true;
            urlEntry7.Sensitive = true;
            nameEntry8.Sensitive = true;
            urlEntry8.Sensitive = true;
            saveButton.Sensitive = true;
        }

        // Save edition
        protected void SaveButtonClicked(object sender, EventArgs e)
        {
            deleteButton1.Sensitive = false;
            deleteButton2.Sensitive = false;
            deleteButton3.Sensitive = false;
            deleteButton4.Sensitive = false;
            deleteButton5.Sensitive = false;
            deleteButton6.Sensitive = false;
            deleteButton7.Sensitive = false;
            deleteButton8.Sensitive = false;
            nameEntry1.Sensitive = false;
            urlEntry1.Sensitive = false;
            nameEntry2.Sensitive = false;
            urlEntry2.Sensitive = false;
            nameEntry3.Sensitive = false;
            urlEntry3.Sensitive = false;
            nameEntry4.Sensitive = false;
            urlEntry4.Sensitive = false;
            nameEntry5.Sensitive = false;
            urlEntry5.Sensitive = false;
            nameEntry6.Sensitive = false;
            urlEntry6.Sensitive = false;
            nameEntry7.Sensitive = false;
            urlEntry7.Sensitive = false;
            nameEntry8.Sensitive = false;
            urlEntry8.Sensitive = false;
            SaveBookmarks();
        }


        // Go Button Actions
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

        // Delete Buttons Actions
        protected void DeleteButton1Clicked(object sender, EventArgs e)
        {
            nameEntry1.Text = "";
            urlEntry1.Text = "";
        }

        protected void DeleteButton2Clicked(object sender, EventArgs e)
        {
            nameEntry2.Text = "";
            urlEntry2.Text = "";
        }

        protected void DeleteButton3Clicked(object sender, EventArgs e)
        {
            nameEntry3.Text = "";
            urlEntry3.Text = "";
        }

        protected void DeleteButton4Clicked(object sender, EventArgs e)
        {
            nameEntry4.Text = "";
            urlEntry4.Text = "";
        }

        protected void DeleteButton5Clicked(object sender, EventArgs e)
        {
            nameEntry5.Text = "";
            urlEntry5.Text = "";
        }

        protected void DeleteButton6Clicked(object sender, EventArgs e)
        {
            nameEntry6.Text = "";
            urlEntry6.Text = "";
        }

        protected void DeleteButton7Clicked(object sender, EventArgs e)
        {
            nameEntry7.Text = "";
            urlEntry7.Text = "";
        }

        protected void DeleteButton8Clicked(object sender, EventArgs e)
        {
            nameEntry8.Text = "";
            urlEntry8.Text = "";
        }
    }
}


