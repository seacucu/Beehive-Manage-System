using System.Windows;

namespace BeehiveManageSystem
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯程式
    /// </summary>
    public partial class MainWindow : Window
    {
        /*---- 屬性&支援欄位 ----*/
        private QueenBee queen = new QueenBee();
        public static int DaysPassed { get; private set; } = 0;

        /*----- 事件處理常式 -----*/
        public MainWindow()
        {
            InitializeComponent();
            Report.Text = queen.StatusReport;
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