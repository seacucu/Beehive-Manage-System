using System;
using System.Windows;
using System.Windows.Threading;

namespace BeehiveManageSystem
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯程式
    /// </summary>
    public partial class MainWindow : Window
    {
        /*-------- 常數 --------*/
        private const double SECOND_PER_DAY = 1.2;

        /*---- 屬性&支援欄位 ----*/
        private QueenBee queen = new QueenBee();
        public static int DaysPassed { get; private set; } = 0;
        private DispatcherTimer timer = new DispatcherTimer();

        /*----- 事件處理常式 -----*/
        public MainWindow()
        {
            InitializeComponent();
            Report.Text = queen.StatusReport;
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(SECOND_PER_DAY);
            timer.Start();
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            WorkShift_Click(this, new RoutedEventArgs());
        }

        private void WorkShift_Click(object sender, RoutedEventArgs e)
        {
            DaysPassed++;
            queen.WorkNextShift();
            Report.Text = queen.StatusReport;            
        }

        private void JobAssign_Click(object sender, RoutedEventArgs e)
        {
            queen.AssignBee(jobSelector.Text);
            Report.Text = queen.StatusReport;            
        }
    }
}