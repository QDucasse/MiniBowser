using System;
using Gtk;
using MiniBowser;
using System.Threading.Tasks;

public partial class MainWindow : Gtk.Window
{

    public MiniBowser.MiniBowser mb;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        mb = new MiniBowser.MiniBowser();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
        mb.Store();
    }

    protected void HomeButtonClicked(object sender, EventArgs e)
    {
        // url set homepage
        urlEntry.Text = mb.Homepage;
        // add the site to the history
        mb.History.AddNewSite(mb.Homepage);
        // http load homepage
        HttpData requestRes = new HttpData();
        Task<HttpData> taskRes = mb.httpHandler.RequestResponse(mb.Homepage);
        requestRes = taskRes.Result;
        // display html content(tostring)
        htmlTextView.Buffer.Text = requestRes.ToString();
    }

    protected void PreviousButtonClicked(object sender, EventArgs e)
    {
        if (mb.History.PreviousSites.Count == 0)
        {
            return;
        }
        else
        {
            // get current site
            string currentSite = mb.History.GetCurrentSite();
            // history return previous
            string previousSite = mb.History.ReturnPreviousSite(currentSite);
            // url set previous
            urlEntry.Text = previousSite;
            // http load page
            HttpData requestRes = new HttpData();
            Task<HttpData> taskRes = mb.httpHandler.RequestResponse(previousSite);
            requestRes = taskRes.Result;
            // display html content(tostring)
            htmlTextView.Buffer.Text = requestRes.ToString();
            // check button status
            // TODO + remove if/else
        }
    }

    protected void NextButtonClicked(object sender, EventArgs e)
    {
        if (mb.History.NextSites.Count == 0)
        {
            return;
        }
        else
        {
            // get current site
            string currentSite = mb.History.GetCurrentSite();
            // history return next
            string nextSite = mb.History.ReturnNextSite(currentSite);
            // url set next
            urlEntry.Text = nextSite;
            // http load page
            HttpData requestRes = new HttpData();
            Task<HttpData> taskRes = mb.httpHandler.RequestResponse(nextSite);
            requestRes = taskRes.Result;
            // display html content(tostring)
            htmlTextView.Buffer.Text = requestRes.ToString();
            // check button status
            // TODO + remove if/else
        }
    }

    protected void SearchButtonClicked(object sender, EventArgs e)
    {
        // url get
        string site = urlEntry.Text;
        // add current site to history
        mb.History.AddNewSite(site);
        // http load page
        HttpData requestRes = new HttpData();
        Task<HttpData> taskRes = mb.httpHandler.RequestResponse(site);
        requestRes = taskRes.Result;
        // display html content(tostring)
        htmlTextView.Buffer.Text = requestRes.ToString();
    }

    protected void ReloadButtonClicked(object sender, EventArgs e)
    {
        // TODO choose one option
        // string site = urlEntry.Text;
        string currentSite = mb.History.GetCurrentSite();
        // http load current page again
        HttpData requestRes = new HttpData();
        Task<HttpData> taskRes = mb.httpHandler.RequestResponse(currentSite);
        requestRes = taskRes.Result;
        // display html content(tostring)
        htmlTextView.Buffer.Text = requestRes.ToString();
    }

    protected void BookmarksButtonClicked(object sender, EventArgs e)
    {
        // diplay bookmarks frame (list?)
        // names - url - go
        // click -> close new frame 
    }

    protected void HistoryButtonClicked(object sender, EventArgs e)
    {
        // display history frame (list?)
        // names - url - go
        // click -> close new frame 
    }

    protected void CheckButtonsStatus()
    {
    }
}

