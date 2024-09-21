namespace BreakTime;


public partial class MainPage : ContentPage
{ 
    bool isrunning = false;
    
    public MainPage()
    {
        InitializeComponent();
        Title = "Break Timer";
    }


    private void Start_OnClicked(object sender, EventArgs e)
    {
        isrunning = false;
        Thread.Sleep(2000);
        
        
        isrunning = true ;
        int isec = 0;
        bool isRed = false;
        var myButton = (Button)sender;
        var myMin = Int32.Parse(myButton.CommandParameter.ToString());

        lblDisplay.Text = myMin.ToString() + " Minutes Left";
        
        
        
        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if(!isrunning)
            {
                return false;
            }
            if (myMin==0)
            {
                lblDisplay.Text = " Time is Up";
                if (isRed)
                {
                    frmMain.Background = Colors.White;
                    isRed = false;
                }
                else
                {
                    frmMain.Background = Colors.Red;
                    isRed = true;
                }
            }
            else
            {
                isec++;
                if (isec==59)
                {
                    isec = 0;
                    myMin--;
                    lblDisplay.Text = myMin.ToString() + " Minutes Left";

                }

            }
            
            return isrunning;
        } );
    }

    private void Reset_OnClicked(object sender, EventArgs e)
    {
        lblDisplay.Text = "Take A break";
        isrunning = false ; 
    }
}