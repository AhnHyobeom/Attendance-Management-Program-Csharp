using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; // Add for UART communication
using MySql.Data.MySqlClient; // Add for MySQL

namespace Attendance_Management_Program
{
    public partial class Form1 : Form
    {
        String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=tmp_db;Charset=UTF8";
        MySqlConnection conn;
        MySqlCommand cmd;
        String sql = "";
        MySqlDataReader reader;
        string datain = ""; // UART로 부터 들어온 data를 읽어 들이는 변수
        int[] inputSensorData; // UART로 부터 들어온 data Parsing Array
        int inputSensorDataIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // menu design
            menu = new List<Label>();
            menu.Add(btn_list_management);
            menu.Add(btn_record);
            menu.Add(btn_daily_TnA_status);
            menu.Add(btn_daily_TnA_chart);
            menu.Add(btn_monthly_TnA_status);
            menu.Add(btn_monthly_TnA_chart);
            menu.Add(btn_department_TnA_status);
            menu.Add(btn_employee_registration);

            //시작 TabPage 설정
            tabControl1.SelectedIndex = 0;

            /*conn = new MySqlConnection(connStr);
            conn.Open();
            cmd = new MySqlCommand("", conn);
            try
            {
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 115200;
                serialPort1.Open(); // 예외 처리 집어 넣을것
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("UART Open Execption Error" + Environment.NewLine);
            }*/
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            sql = "SELECT* FROM tmp WHERE t_date BETWEEN '2021-04-29-09-45-00' AND '2021-04-29-09-46-00'";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            reader.Read();
            DateTime date = new DateTime();
            date = (DateTime)reader["t_date"];
            int t_room1 = (int)reader["t_room1"];
            int t_room2 = (int)reader["t_room2"];
            int t_room3 = (int)reader["t_room3"];
            reader.Close();
        }
        // ------------------------- start menu design -------------------------
        private List<Label> menu;

        private void setMenuChgane(int index)
        {
            // 100, 120, 150, 150, 150, 150, 180, 170
            if (tabControl1.SelectedIndex != index)
            {
                menu[tabControl1.SelectedIndex].ForeColor = Color.FromArgb(111, 111, 111);
                menu[index].ForeColor = Color.White;
                Tab_Menu_Select_Bar.Width = menu[index].Size.Width;
                Tab_Menu_Select_Bar.Location = new Point(menu[index].Location.X, 0);
                tabControl1.SelectedIndex = index;
            }
        }
        private void btn_list_management_Click(object sender, EventArgs e)
        {
            setMenuChgane(0);
        }
        private void btn_record_Click(object sender, EventArgs e)
        {
            setMenuChgane(1);
        }
        private void btn_daily_TnA_status_Click(object sender, EventArgs e)
        {
            setMenuChgane(2);
        }
        private void btn_daily_TnA_chart_Click(object sender, EventArgs e)
        {
            setMenuChgane(3);
        }
        private void btn_monthly_TnA_status_Click(object sender, EventArgs e)
        {
            setMenuChgane(4);
        }
        private void btn_monthly_TnA_chart_Click(object sender, EventArgs e)
        {
            setMenuChgane(5);
        }
        private void btn_department_TnA_status_Click(object sender, EventArgs e)
        {
            setMenuChgane(6);
        }
        private void btn_employee_registration_Click(object sender, EventArgs e)
        {
            setMenuChgane(7);
        }
        // ------------------------- end menu design -------------------------
        // Reference address
        // https://program-day.tistory.com/18
        // https://blog.naver.com/r8jang/221624822165
        // ------------------------- start click miss ------------------------- 
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Tab_Menu_Back_Paint(object sender, PaintEventArgs e)
        {

        }
        // ------------------------- end click miss -------------------------
    }
}
