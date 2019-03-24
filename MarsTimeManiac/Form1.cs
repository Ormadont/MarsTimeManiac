using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsTimeManiac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SysEventLog sysLog = new SysEventLog();

            string todayTime = sysLog.ChoiceDayTime(DateTime.Now.DayOfYear).ToString();
            label_TodayTime.Text = $"Сегодня компьютер начал работать {todayTime} назад.";

            string yesterdayTime = sysLog.ChoiceDayTime(DateTime.Now.DayOfYear-1).ToString();
            label_YesterdayTime.Text = $"Вчерашний интервал работы компьютера {yesterdayTime}";

            string monthTime = sysLog.CurMonthTime().ToString();
            label_monthTime.Text = $"Время с начала месяца до сегодняшнего дня: {monthTime}";
        }
    }
}
