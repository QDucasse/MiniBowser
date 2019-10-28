using System;
using Gtk;
using MiniBowserGUI;

public partial class MainWindow : Gtk.Window
{

    public MiniBowser.MiniBowser mb;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        mb = new MiniBowser.MiniBowser();
        urlEntry.Text = mb.Homepage;
        // add the site to the history
        mb.CurrentSite = mb.Homepage;
        // http load homepage
        // display html content(tostring)
        htmlTextView.Buffer.Text = mb.RequestResult(mb.Homepage);
        CheckButtonsStatus();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        mb.Store();
        Application.Quit();
        a.RetVal = true;
    }

    protected void HomeButtonClicked(object sender, EventArgs e)
    {
        // url set homepage
        urlEntry.Text = mb.Homepage;
        // add the previous site to the history if different from the homepage
        if (mb.CurrentSite != mb.Homepage)
        {
            mb.History.AddNewSite(mb.CurrentSite);
            mb.CurrentSite = mb.Homepage;
        }
        // http load homepage
        // display html content(tostring)
        htmlTextView.Buffer.Text = mb.RequestResult(mb.Homepage);
        // check button status
        CheckButtonsStatus();
    }

    protected void PreviousButtonClicked(object sender, EventArgs e)
    {
        // history return previous
        string previousSite = mb.History.ReturnPreviousSite(mb.CurrentSite);
        mb.CurrentSite = previousSite;
        // url set previous
        urlEntry.Text = previousSite;
        // http load page
        // display html content(tostring)
        htmlTextView.Buffer.Text = mb.RequestResult(previousSite);
        // check button status
        CheckButtonsStatus();
    }

    protected void NextButtonClicked(object sender, EventArgs e)
    {
        // history return next
        string nextSite = mb.History.ReturnNextSite(mb.CurrentSite);
        mb.CurrentSite = nextSite;
        // url set next
        urlEntry.Text = nextSite;
        // http load page
        // display html content(tostring)
        htmlTextView.Buffer.Text = mb.RequestResult(nextSite);
        // check button status
        CheckButtonsStatus();
    }

    protected void SearchButtonClicked(object sender, EventArgs e)
    {
        // url get
        string site = urlEntry.Text;
        // add current site to history if different from last one
        if (site != mb.CurrentSite)
        {
            mb.History.AddNewSite(mb.CurrentSite);
            mb.CurrentSite = site;
        }
        // http load page
        // display html content(tostring)
        htmlTextView.Buffer.Text = mb.RequestResult(site);
        // check button status
        CheckButtonsStatus();
    }

    protected void ReloadButtonClicked(object sender, EventArgs e)
    {
        // http load current page again
        // display html content(tostring)
        htmlTextView.Buffer.Text = mb.RequestResult(mb.CurrentSite);
    }

    protected void BookmarksButtonClicked(object sender, EventArgs e)
    {
        // diplay bookmarks frame (list?)
        BookmarksWindow bmWindow = new BookmarksWindow(this);
        bmWindow.Show();
        // names - url - go
        // click -> close new frame 
    }

    protected void HistoryButtonClicked(object sender, EventArgs e)
    {
        // display history frame (list?)
        HistWindow histWindow = new HistWindow(this);
        histWindow.Show();
        // names - url - go
        // click -> close new frame 
    }

    protected void SetHomeButtonClicked(object sender, EventArgs e)
    {
        mb.Homepage = mb.CurrentSite;
    }

    public void CheckButtonsStatus()
    {
        if (mb.History.PreviousSites.Count == 0)
        {
            previousButton.Sensitive = false;
        }
        else
        {
            previousButton.Sensitive = true;
        }

        if (mb.History.NextSites.Count == 0)
        {
            nextButton.Sensitive = false;
        }
        else
        {
            nextButton.Sensitive = true;
        }
    }

    public void LoadSite(string url)
    {
        urlEntry.Text = url;
        htmlTextView.Buffer.Text = "";
    }


}

