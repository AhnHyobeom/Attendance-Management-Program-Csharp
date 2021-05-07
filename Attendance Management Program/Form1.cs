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
        // using DB
        String connStr = "Server=127.0.0.1;Uid=root;Pwd=1234;Database=amp_db;Charset=UTF8";
        MySqlConnection conn;
        MySqlCommand cmd;
        String sql = "";
        MySqlDataReader reader;
        // using UART
        string datain = ""; // UART로 부터 들어온 data를 읽어 들이는 변수
        int[] inputSensorData; // UART로 부터 들어온 data Parsing Array
        int inputSensorDataIndex = 0;

        string[] department_name = { "사장실", "임원진", "관리팀", "컨텐츠팀", "개발팀", 
                                    "고객지원팀", "기획팀", "디자인팀", "업무지원팀" }; 
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

            // list_management list_DataGridView init Columns
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "No.";
            dataGridView1.Columns[1].Name = "부서명";
            dataGridView1.Columns[2].Name = "부서 코드";

            // list_management list_DataGridView init Columns
            dataGridView2.ColumnCount = 6;
            dataGridView2.Columns[0].Name = "No.";
            dataGridView2.Columns[1].Name = "상태";
            dataGridView2.Columns[2].Name = "구분";
            dataGridView2.Columns[3].Name = "성명";
            dataGridView2.Columns[4].Name = "부서";
            dataGridView2.Columns[5].Name = "직위";

            // record DataGridView init Columns
            dgv_record.ColumnCount = 11;
            dgv_record.Columns[0].Name = "근무일자";
            dgv_record.Columns[1].Name = "부서명";
            dgv_record.Columns[2].Name = "이름";
            dgv_record.Columns[3].Name = "직금";
            dgv_record.Columns[4].Name = "출근시간";
            dgv_record.Columns[5].Name = "퇴근시간";
            dgv_record.Columns[6].Name = "출근구분";
            dgv_record.Columns[7].Name = "퇴근구분";
            dgv_record.Columns[8].Name = "연장근무시간";
            dgv_record.Columns[9].Name = "휴일근무시간";
            dgv_record.Columns[10].Name = "총근무시간";

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                cmd = new MySqlCommand("", conn);
            }
            catch(MySqlException)
            {
                MessageBox.Show("MySQL Connection Exception Error !!!" + Environment.NewLine);
            }
            
            try
            {
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 115200;
                serialPort1.Open(); // 예외 처리 집어 넣을것
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("UART Open Execption Error !!!" + Environment.NewLine);
            }

            // list_management_DataGridViewInit From DB
            list_management_list_DataGridViewInit();
            list_management_employee_DataGridViewInit();
        }

        // ------------------------- start list management TAB -------------------------
        private void list_management_list_DataGridViewInit()
        {
            int noIndex = 0;
            sql = "SELECT * FROM department";
            try
            {
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();

                int dm_id = 0;
                string dm_name = "";
                string temp_dm_id = "";
                // init Rows
                while (reader.Read())
                {
                    dm_name = (string)reader["dm_name"];
                    dm_id = (int)reader["dm_id"];
                    temp_dm_id = string.Format("{0:D3}", dm_id);
                    dataGridView1.Rows.Add(++noIndex, dm_name, temp_dm_id);
                }
            }
            catch(MySqlException)
            {
                MessageBox.Show("department init DB Fail !!!");
            }
            // last Rows
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = "";
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = "Total " + noIndex;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = "";

            reader.Close();
        }
        private void list_management_employee_DataGridViewInit()
        {
            int noIndex = 0;
            sql = "SELECT * FROM employee";
            try
            {
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();

                string e_status = "";
                string e_cf = "";
                string e_name = "";
                int e_dm_id = 0;
                string e_department = "";
                string e_position = "";

                // init Rows
                while (reader.Read())
                {
                    e_status = (string)reader["e_status"];
                    e_cf = (string)reader["e_cf"];
                    e_name = (string)reader["e_name"];
                    e_dm_id = (int)reader["e_dm_id"];
                    e_department = department_name[e_dm_id];
                    e_position = (string)reader["e_position"];
                    dataGridView2.Rows.Add(++noIndex, e_status, e_cf, e_name, e_department, e_position);
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("employee init DB Fail !!!");
            }
            // last Rows
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[0].Value = "";
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[1].Value = "";
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[2].Value = "";
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[3].Value = "Total " + noIndex;
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[4].Value = "";
            dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[5].Value = "";

            reader.Close();
        }
        // ------------------------- end list management TAB -------------------------

        // ------------------------- start recod TAB -------------------------
        private void label3_Paint(object sender, PaintEventArgs e)
        {
            // 3, 10, 11, 12
            ControlPaint.DrawBorder(e.Graphics, label3.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
            ControlPaint.DrawBorder(e.Graphics, label10.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
            ControlPaint.DrawBorder(e.Graphics, label11.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
            ControlPaint.DrawBorder(e.Graphics, label12.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
        }
        private void tp_record_Paint(object sender, PaintEventArgs e)
        {
            // record label boder darw
            tb_record_dename.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.FromArgb(0, 0, 192));
            Graphics g = e.Graphics;
            int variance = 1;
            g.DrawRectangle(p, new Rectangle(tb_record_dename.Location.X - variance, tb_record_dename.Location.Y - variance, tb_record_dename.Width + variance, tb_record_dename.Height + variance));

            tb_record_position.BorderStyle = BorderStyle.None;
            Graphics g2 = e.Graphics;
            g2.DrawRectangle(p, new Rectangle(tb_record_position.Location.X - variance, tb_record_position.Location.Y - variance, tb_record_position.Width + variance, tb_record_position.Height + variance));

            tb_record_name.BorderStyle = BorderStyle.None;
            Graphics g3 = e.Graphics;
            g3.DrawRectangle(p, new Rectangle(tb_record_name.Location.X - variance, tb_record_name.Location.Y - variance, tb_record_name.Width + variance, tb_record_name.Height + variance));

            tb_record_workday.BorderStyle = BorderStyle.None;
            Graphics g4 = e.Graphics;
            g4.DrawRectangle(p, new Rectangle(tb_record_workday.Location.X - variance, tb_record_workday.Location.Y - variance, tb_record_workday.Width + variance, tb_record_workday.Height + variance));
        }

        // ------------------------- end recod TAB -------------------------

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
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        // ------------------------- end click miss -------------------------
    }
}
