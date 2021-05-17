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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

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
        string tapName = ""; // Selected tabName
        bool registeMode = false; // Selected RegisterMode
        List<string> dataParseList = new List<string>(); // dataReceive Event data parsing
        string[] department_name = { "사장실", "임원진", "관리팀", "컨텐츠팀", "개발팀",
                                    "고객지원팀", "기획팀", "디자인팀", "업무지원팀" };

        Excel.Application excelApp = null; 
        Excel.Workbook workBook = null; 
        Excel.Worksheet workSheet1 = null;
        Excel.Worksheet workSheet2 = null;
        int wsIdx = 0;

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
            dgv_record.Columns[3].Name = "직급";
            dgv_record.Columns[4].Name = "출근시간";
            dgv_record.Columns[5].Name = "퇴근시간";
            dgv_record.Columns[6].Name = "출근구분";
            dgv_record.Columns[7].Name = "퇴근구분";
            dgv_record.Columns[8].Name = "연장근무시간";
            dgv_record.Columns[9].Name = "휴일근무시간";
            dgv_record.Columns[10].Name = "총근무시간";

            // employee registration retirement DataGridView init Columns
            dgv_retirement.ColumnCount = 6;
            dgv_retirement.Columns[0].Name = "이름";
            dgv_retirement.Columns[1].Name = "부서명";
            dgv_retirement.Columns[2].Name = "직급";
            dgv_retirement.Columns[3].Name = "입사일";
            dgv_retirement.Columns[4].Name = "퇴사일";
            dgv_retirement.Columns[5].Name = "근속기간";

            // monthly TnA status DataGridView init Columns
            dgv_monthly.ColumnCount = 9;
            dgv_monthly.Columns[0].Name = "부서명";
            dgv_monthly.Columns[1].Name = "이름";
            dgv_monthly.Columns[2].Name = "직급";
            dgv_monthly.Columns[3].Name = "지각횟수";
            dgv_monthly.Columns[4].Name = "조퇴횟수";
            dgv_monthly.Columns[5].Name = "결근횟수";
            dgv_monthly.Columns[6].Name = "연장 근무시간";
            dgv_monthly.Columns[7].Name = "휴일 근무시간";
            dgv_monthly.Columns[8].Name = "총 근무시간";

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                cmd = new MySqlCommand("", conn);
            }
            catch (MySqlException)
            {
                MessageBox.Show("MySQL Connection Exception Error !!!" + Environment.NewLine);
            }

            try
            {
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 115200;
                serialPort1.Open(); // 예외 처리 집어 넣을것
                serialPort1.DiscardOutBuffer();
                serialPort1.DiscardInBuffer();
                serialPort1.WriteLine("normalMODE" + Environment.NewLine);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("UART Open Execption Error !!!" + Environment.NewLine);
            }

            // list_management_DataGridViewInit From DB
            list_management_list_DataGridViewInit();
            list_management_employee_DataGridViewInit();
            // record_DataGridView From DB
            // label_record_search init
            string searchToday = DateTime.Now.ToString("yyyy-MM-dd");
            string query = "SELECT * FROM workRecord WHERE w_day = '";
            query += searchToday + "'";
            showRecodDGV(query);
            label_record_search.Text = "검색 내용 -> " + searchToday;

            showRetirementDGV();
            drawDailyTnAChart(searchToday.Substring(0, 4), searchToday.Substring(5, 2), searchToday.Substring(8, 2));
            showMonthlyDGV();
            dp_search_chart();

            label_manage_excel_save.Visible = false;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ReleaseObject(workBook);
            ReleaseObject(excelApp);
        }
        // ---------------------------------------- start tap control ----------------------------------------
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "tp_list_management":
                    tapName = "tp_list_management";
                    serialPort1.WriteLine("normalMODE" + Environment.NewLine);
                    break;
                case "tp_record":
                    tapName = "tp_record";
                    serialPort1.WriteLine("normalMODE" + Environment.NewLine);
                    break;
                case "tp_daily_TnA_status":
                    tapName = "tp_daily_TnA_status";
                    serialPort1.WriteLine("normalMODE" + Environment.NewLine);
                    break;
                case "tp_daily_TnA_chart":
                    tapName = "tp_daily_TnA_chart";
                    serialPort1.WriteLine("normalMODE" + Environment.NewLine);
                    break;
                case "tp_monthly_TnA_status":
                    tapName = "tp_monthly_TnA_status";
                    serialPort1.WriteLine("normalMODE" + Environment.NewLine);
                    break;
                case "tp_monthly_TnA_chart":
                    tapName = "tp_monthly_TnA_chart";
                    serialPort1.WriteLine("normalMODE" + Environment.NewLine);
                    break;
                case "tp_department_TnA_status":
                    tapName = "tp_department_TnA_status";
                    serialPort1.WriteLine("normalMODE" + Environment.NewLine);
                    break;
                case "tp_employee_registration":
                    tapName = "tp_employee_registration";
                    serialPort1.WriteLine("startRegMODE" + Environment.NewLine);
                    break;
                default:
                    break;
            }
        }

        // ---------------------------------------- end tap control ----------------------------------------

        // ------------------------------------------- start STM32 -> C# -------------------------------------------
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            datain = serialPort1.ReadLine();
            this.Invoke(new EventHandler(dataParse));
        }
        private void dataParse(object sender, EventArgs e)
        {
            if (tapName == "tp_employee_registration")
            {
                if (datain.Length != 10)
                {
                    serialPort1.WriteLine("regFAIL" + Environment.NewLine);
                    return;
                }
                dataParseList.Add("tp_registration");
            }
            else
            {
                if (datain.Length != 10)
                {
                    serialPort1.WriteLine("regFAIL" + Environment.NewLine);
                    return;
                }
                dataParseList.Add("normal_access");
            }
        }
        private void tp_registration()
        {
            sql = "SELECT COUNT(*) AS cnt FROM employee WHERE e_rfid = '";
            sql += datain + "'";
            int count = -1;
            try
            {
                cmd = new MySqlCommand(sql, conn);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException)
            {
                MessageBox.Show("employee COUNT(*) query exception !!!");
            }
            // RFID already exists -> unregister
            if (count == 1)
            {
                registeMode = false;
                label_registration_cardEnter.Text = "카드 입력 값 : 등록해제";
                serialPort1.WriteLine("unregMode" + Environment.NewLine);
                sql = "SELECT * FROM employee WHERE e_rfid = '";
                sql += datain + "'";
                string e_status = "";
                string e_cf = "";
                string e_name = "";
                int e_dm_id = 0;
                string e_position = "";

                try
                {
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    e_status = (string)reader["e_status"];
                    e_cf = (string)reader["e_cf"];
                    e_name = (string)reader["e_name"];
                    e_dm_id = (int)reader["e_dm_id"];
                    e_position = (string)reader["e_position"];

                    tb_registration_rfid.Text = datain;
                    tb_registration_status.Text = e_status;
                    tb_registration_classification.Text = e_cf;
                    tb_registration_name.Text = e_name;
                    tb_registration_dm_id.Text = string.Format("{0:D3}", e_dm_id);
                    tb_registration_position.Text = e_position;
                    reader.Close();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("employee SELECT * query exception !!!");
                }
            }
            else
            { // register
                registeMode = true;
                serialPort1.WriteLine("regMode" + Environment.NewLine);
                label_registration_cardEnter.Text = "카드 입력 값 : 사원등록";
                tb_registration_rfid.Text = datain;
                tb_registration_status.Text = "";
                tb_registration_classification.Text = "";
                tb_registration_name.Text = "";
                tb_registration_dm_id.Text = "";
                tb_registration_position.Text = "";
            }
        }
        private void normal_access()
        {
            // Make sure have access rights.
            sql = "SELECT COUNT(*) AS cnt FROM employee WHERE e_rfid = '";
            sql += datain + "'";
            int count = -1;
            try
            {
                cmd = new MySqlCommand(sql, conn);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException)
            {
                MessageBox.Show("employee COUNT(*) query exception !!!");
            }
            if(count < 1)
            {
                serialPort1.WriteLine("inAccessible" + Environment.NewLine);
                return;
            }
            // acces rights.
            // Datetime format
            DateTime today = DateTime.Now;
            string yyyy_MM_dd = DateTime.Now.ToString("yyyy-MM-dd");
            string w_workonTime = today.Hour + ":" + today.Minute + ":" + today.Second;

            string w_workoncf = "";
            string w_workoffcf = "";

            count = -1;
            // work_on ??? work_off ???
            sql = "SELECT COUNT(*) AS cnt FROM workrecord WHERE w_e_rfid = '";
            sql += datain + "' AND w_day = '" + yyyy_MM_dd + "'";
            try
            {
                cmd = new MySqlCommand(sql, conn);
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException)
            {
                MessageBox.Show("workrecord COUNT(*) query exception !!!");
            }
            // get name, departmentName, position FROM employee TABLE
            string e_name = "";
            int e_dm_id = 0;
            string e_position = "";
            sql = "SELECT e_name, e_dm_id, e_position FROM employee WHERE e_rfid = '";
            sql += datain + "'";
            try
            {
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                reader.Read();
                e_name = (string)reader["e_name"];
                e_dm_id = (int)reader["e_dm_id"];
                e_position = (string)reader["e_position"];
                reader.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("employee SELECT e_name, e_dm_id, e_position query exception !!!");
            }
            string query = "";
            // to be late, to leave early
            TimeSpan late_standard = new TimeSpan(9, 0, 0);
            TimeSpan leave_standard = new TimeSpan(17, 0, 0);
            TimeSpan enter_card_time = new TimeSpan(today.Hour, today.Minute, today.Second);
            TimeSpan diff_time = late_standard - enter_card_time;
            if(diff_time.TotalMinutes < 0)
            {
                w_workoncf = "지각";
            }
            else
            {
                w_workoncf = "";
            }
            diff_time = leave_standard - enter_card_time;
            string w_ew = "00:00:00";
            if (diff_time.TotalMinutes > 0)
            {
                w_workoffcf = "조퇴";
            }
            else if(diff_time.TotalMinutes < 0)
            {
                w_workoffcf = "연장";
                w_ew = "";
                w_ew += (diff_time.Hours * -1) + ":";
                w_ew += (diff_time.Minutes * -1) + ":";
                w_ew += (diff_time.Seconds * -1);
            }
            else
            {
                w_workoffcf = "";
            }
            // work on
            if (count == 0)
            {
                // INSERT INTO workRecord(w_e_rfid, w_dm_id, w_e_name, w_e_position, w_day, w_workonTime, w_workoffTime, w_workoncf, w_workoffcf, w_ew, w_hw, w_tw) 
                // VALUES('6a703fb491', 7, '김고수', '사원', '2021-05-11', '09:00:00', '17:00:00', NULL, NULL, '00:00:00', '00:00:00', '08:00:00');
                try
                {
                    sql = "INSERT INTO workRecord(w_e_rfid, w_dm_id, w_e_name, w_e_position, w_day, w_workonTime, w_workoffTime, w_workoncf, w_workoffcf, w_ew, w_hw, w_tw) VALUES('";
                    sql += datain + "', " + e_dm_id + ", '" + e_name + "', '" + e_position + "', '" + yyyy_MM_dd + "', '";
                    sql += w_workonTime + "', '00:00:00', ";
                    if(w_workoncf == "")
                    {
                        sql += "NULL, NULL, '00:00:00', '00:00:00', '00:00:00')";
                    }
                    else
                    {
                        sql += "'" + w_workoncf + "', NULL, '00:00:00', '00:00:00', '00:00:00')";
                    }
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    // recordDGV update
                    query = "SELECT * FROM workRecord WHERE w_day = '";
                    query += yyyy_MM_dd + "'";
                    showRecodDGV(query);
                }
                catch
                {
                    MessageBox.Show("INSERT INTO workRecord query exception !!!");
                }
            }
            else
            { // work off
                // total today working time calcul
                TimeSpan w_tw = new TimeSpan();
                TimeSpan temp_w_workonTime = new TimeSpan();
                try
                {
                    sql = "SELECT w_workonTime FROM workrecord WHERE w_e_rfid = '" + datain + "' AND ";
                    sql += "w_day = '" + yyyy_MM_dd + "'";
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    temp_w_workonTime = (TimeSpan)reader["w_workonTime"];
                    w_tw = enter_card_time - temp_w_workonTime;
                    reader.Close();
                }
                catch(MySqlException)
                {
                    MessageBox.Show("total today working time calcul SELECT query exception !!!");
                }
                // UPDATE workrecord SET w_workoffTime = '00:00:00'
                // WHERE w_e_rfid = '0000000011' AND w_day = '2021-05-11';
                try
                {
                    sql = "UPDATE workrecord SET w_workoffTime = '";
                    sql += w_workonTime + "', w_workoffcf = '" + w_workoffcf + "'";
                    sql += ", w_ew = '" + w_ew + "', w_tw = '" + w_tw + "' ";
                    sql += "WHERE w_e_rfid = '" + datain + "' AND w_day = '" + yyyy_MM_dd + "'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    // recordDGV update
                    query = "SELECT * FROM workRecord WHERE w_day = '";
                    query += yyyy_MM_dd + "'";
                    showRecodDGV(query);
                }
                catch
                {
                    MessageBox.Show("UPDATE workrecord query exception !!!");
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dataParseList.Count > 0)
            {
                if (dataParseList[0] == "tp_registration")
                {
                    dataParseList.RemoveAt(0);
                    tp_registration();
                }
                else if(dataParseList[0] == "normal_access")
                {
                    dataParseList.RemoveAt(0);
                    normal_access();
                }
            }
        }
        // ------------------------------------------- end STM32 -> C# -------------------------------------------

        // ---------------------------------------- start list management TAB ----------------------------------------
        private void list_management_list_DataGridViewInit()
        {
            int noIndex = 0;
            sql = "SELECT * FROM department";
            try
            {
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException)
            {
                reader.Close();
                MessageBox.Show("department init DB Fail !!!");
            }
            int dm_id = 0;
            string dm_name = "";
            // init Rows
            while (reader.Read())
            {
                dm_name = (string)reader["dm_name"];
                dm_id = (int)reader["dm_id"];
                dataGridView1.Rows.Add(++noIndex, dm_name, string.Format("{0:D3}", dm_id));
            }
            /*for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            { 
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }*/
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

                dataGridView2.Rows.Clear();
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
        // ---------------------------------------- end list management TAB ----------------------------------------

        // ---------------------------------------- start recod TAB ----------------------------------------
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

        private void showRecodDGV(string query)
        {
            // INSERT INTO workRecord(w_id, w_e_rfid, w_day, w_workonTime, w_workoffTime, w_workoncf, w_workoffcf, w_ew, w_hw, w_tw) 
            // VALUES(NULL, '0000000012', '2021-05-07', '00:00:00', '00:00:00', '휴가', '휴가', '00:00:00', '00:00:00', '00:00:00');
            sql = query;
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            string w_e_rfid = "";
            string w_e_name = "";
            int w_dm_id = 0;
            string e_department = "";
            string w_e_position = "";
            DateTime w_day = new DateTime();
            TimeSpan w_workonTime = new TimeSpan();
            TimeSpan w_workoffTime = new TimeSpan();
            string w_workoncf = "";
            string w_workoffcf = "";
            TimeSpan w_ew = new TimeSpan();
            TimeSpan w_hw = new TimeSpan();
            TimeSpan w_tw = new TimeSpan();

            dgv_record.Rows.Clear();
            // employee table 제외 
            while (reader.Read())
            {
                w_e_rfid = (string)reader["w_e_rfid"];
                w_day = (DateTime)reader["w_day"];
                w_e_name = (string)reader["w_e_name"];
                w_dm_id = (int)reader["w_dm_id"];
                e_department = department_name[w_dm_id];
                w_e_position = (string)reader["w_e_position"];
                w_workonTime = (TimeSpan)reader["w_workonTime"];
                w_workoffTime = (TimeSpan)reader["w_workoffTime"];
                if (reader["w_workoncf"] == DBNull.Value)
                {
                    w_workoncf = "";
                }
                else
                {
                    w_workoncf = (string)reader["w_workoncf"];
                }
                if (reader["w_workoffcf"] == DBNull.Value)
                {
                    w_workoffcf = "";
                }
                else
                {
                    w_workoffcf = (string)reader["w_workoffcf"];
                }
                w_ew = (TimeSpan)reader["w_ew"];
                w_hw = (TimeSpan)reader["w_hw"];
                w_tw = (TimeSpan)reader["w_tw"];
                dgv_record.Rows.Add(w_day.ToString("yyyy-MM-dd"), e_department, w_e_name, w_e_position, w_workonTime.ToString(@"hh\:mm"), w_workoffTime.ToString(@"hh\:mm"), w_workoncf, w_workoffcf, w_ew.ToString(@"hh\:mm"), w_hw.ToString(@"hh\:mm"), w_tw.ToString(@"hh\:mm"));
            }
            reader.Close();

        }
        private void btn_record_init1_Click(object sender, EventArgs e)
        {
            string searchToday = DateTime.Now.ToString("yyyy-MM-dd");
            string query = "SELECT * FROM workRecord WHERE w_day = '";
            query += searchToday + "'";
            showRecodDGV(query);
            label_record_search.Text = "검색 내용 -> " + searchToday;
        }
        private void btn_record_init2_Click(object sender, EventArgs e)
        {
            string searchToday = DateTime.Now.ToString("yyyy-MM-dd");
            string query = "SELECT * FROM workRecord WHERE w_day = '";
            query += searchToday + "'";
            showRecodDGV(query);
            label_record_search.Text = "검색 내용 -> " + searchToday;
        }
        private void btn_record_search1_Click(object sender, EventArgs e)
        {
            record_search_dgv();
        }
        private void btn_record_search2_Click(object sender, EventArgs e)
        {
            record_search_dgv();
        }
        private void record_search_dgv()
        {
            dgv_record.Rows.Clear();
            string query = "SELECT * FROM workRecord WHERE ";
            label_record_search.Text = "검색 내용 -> ";
            bool AND = false;
            if (tb_record_dename.Text != "")
            {
                List<string> li = department_name.ToList();
                int index = li.FindIndex(x => x.Contains(tb_record_dename.Text));
                query += "w_dm_id = " + index;
                AND = true;
                label_record_search.Text += "부서명 : " + department_name[index];
            }
            if (tb_record_name.Text != "")
            {
                if (AND)
                {
                    query += " AND ";
                }
                query += "w_e_name = '" + tb_record_name.Text + "'";
                AND = true;
                label_record_search.Text += "이름 : " + tb_record_name.Text;
            }
            if (tb_record_position.Text != "")
            {
                if (AND)
                {
                    query += " AND ";
                }
                query += "w_e_position = '" + tb_record_position.Text + "'";
                AND = true;
                label_record_search.Text += "직급 : " + tb_record_position.Text;
            }
            if (tb_record_workday.Text != "")
            {
                if (AND)
                {
                    query += " AND ";
                }
                query += "w_day = '" + tb_record_workday.Text + "'";
                label_record_search.Text += "근무일자 : " + tb_record_workday.Text;
            }
            if (!query.Contains("w_dm_id") && !query.Contains("w_e_name") && !query.Contains("w_e_position") && !query.Contains("w_day"))
            {
                string searchToday = DateTime.Now.ToString("yyyy-MM-dd");
                query = "SELECT * FROM workRecord WHERE w_day = '";
                query += searchToday + "'";
                showRecodDGV(query);
                label_record_search.Text = "검색 내용 -> " + searchToday;
            }
            else
            {
                showRecodDGV(query);
            }
        }
        // ---------------------------------------- end recod TAB ----------------------------------------

        // ---------------------------------------- start daily TnA chart ----------------------------------------
        private void drawDailyTnAChart(string year, string month, string day)
        {
            try
            {
                sql = "SELECT w_e_name, w_tw FROM workrecord WHERE w_day = '";
                sql += year + month + day + "'";
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
            }
            catch(MySqlException)
            {
                reader.Close();
                MessageBox.Show("drawChartDaily FROM workrecord Exception !!!");
            }
            List<string> w_e_name = new List<string>();
            TimeSpan w_tw = new TimeSpan();
            List<DateTime> totalWorkList = new List<DateTime>();

            while(reader.Read())
            {
                w_e_name.Add((string)reader["w_e_name"]);
                w_tw = (TimeSpan)reader["w_tw"];
                DateTime dt = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day), w_tw.Hours, w_tw.Minutes, w_tw.Seconds);
                totalWorkList.Add(dt);
            }
            daily_chart.Series.Clear();
            daily_chart.Series.Add("Series1");
            daily_chart.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            daily_chart.ChartAreas[0].AxisY.LabelStyle.Format = "HH:mm";
            daily_chart.ChartAreas[0].AxisX.Interval = 1;
            Random rnd = new Random();
            string point_label = "";

            for (int i = 0; i < w_e_name.Count; i++)
            {
                daily_chart.Series[0].Points.AddXY(w_e_name[i], totalWorkList[i]);
                daily_chart.Series[0].Points[i].Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                point_label = string.Format("{0:HH:mm}", totalWorkList[i]);
                daily_chart.Series[0].Points[i].Label = point_label;
                daily_chart.Series[0].Points[i].LabelForeColor = Color.DodgerBlue;
                daily_chart.Series[0].Points[i].Font = new Font("MD이솝체", 12, FontStyle.Bold);
            }

            reader.Close();
            label_daily_chart_search.Text = year + "년 " + month + "월 " + day + "일 총 근무 시간 현황";
        }
        private void search_daily_chart()
        {
            if (tb_daily_chart_year.Text == "" || tb_daily_chart_month.Text == "" || tb_daily_chart_day.Text == "")
            {
                MessageBox.Show("검색 값을 제대로 입력하세요 !!!");
                return;
            }
            string month = tb_daily_chart_month.Text;
            if (int.Parse(month) < 10 && month.Length < 2)
            {
                month = "0" + tb_daily_chart_month.Text;
            }
            string day = tb_daily_chart_day.Text;
            if (int.Parse(day) < 10 && day.Length < 2)
            {
                day = "0" + tb_daily_chart_day.Text;
            }
            drawDailyTnAChart(tb_daily_chart_year.Text, month, day);
        }
        private void btn_daily_chart_search1_Click(object sender, EventArgs e)
        {
            search_daily_chart();
        }
        private void btn_daily_chart_search2_Click(object sender, EventArgs e)
        {
            search_daily_chart();
        }
        // ---------------------------------------- end daily TnA chart ----------------------------------------

        // ---------------------------------------- start monthly TnA status ----------------------------------------
        List<string> e_id_list = new List<string>();
        private void showMonthlyDGV()
        {
            DateTime today = DateTime.Today;
            e_id_list.Clear();
            string from_year = today.Year.ToString();
            string from_month = "";
            if(today.Month < 10)
            {
                from_month = "0" + today.Month.ToString();
            }
            else
            {
                from_month = today.Month.ToString();
            }
            string from_month_sql = from_year + from_month + "01";
            string to_year = "";
            string to_month = "";
            if(today.Month == 12)
            {
                to_year = (today.Year + 1).ToString();
                to_month = "01";
            }
            else if(today.Month < 9) // 1 ~ 8
            {
                to_year = today.Year.ToString();
                to_month = "0" + (today.Month + 1).ToString();
            }
            else // (9 ~ 11)
            {
                to_year = today.Year.ToString();
                to_month = (today.Month + 1).ToString();
            }
            string to_month_sql = to_year + to_month + "01";

            sql = "SELECT e_rfid FROM employee";
            try
            {
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
                
                while(reader.Read())
                {
                    e_id_list.Add((string)reader["e_rfid"]);
                }
                reader.Close();
            }
            catch(MySqlException)
            {
                reader.Close();
                MessageBox.Show("Monthly SELECT e_rfid Exception !!! ");
            }
            // SELECT COUNT(CASE WHEN w_workoncf = '지각' THEN 1 END) AS cntLate, 
            //COUNT(CASE WHEN w_workoffcf = '조퇴' THEN 1 END) AS cntEarly, 
            //COUNT(CASE WHEN w_workoncf = '결근' THEN 1 END) AS cntOff, SUM(TIME_TO_SEC(w_ew)) AS sum_ew, 
            //SUM(TIME_TO_SEC(w_hw)) AS sum_hw, SUM(TIME_TO_SEC(w_tw)) AS sum_tw 
            //FROM workrecord WHERE w_e_rfid = '0000000007' AND w_day >= '20210501' AND w_day < '20210601';
            int cntLate = 0, cntEarly = 0, cntOff = 0;
            int sum_ew = 0, sum_hw = 0, sum_tw = 0, w_dm_id = 0;
            string w_e_name = "", w_e_position = "";
            dgv_monthly.Rows.Clear();
            // x / 3600 = hour, x / 60 % 60 = minute
            for (int i = 0; i < e_id_list.Count; i++)
            {
                sql = "SELECT w_dm_id, w_e_name, w_e_position, COUNT(CASE WHEN w_workoncf = '지각' THEN 1 END) AS cntLate, ";
                sql += "COUNT(CASE WHEN w_workoffcf = '조퇴' THEN 1 END) AS cntEarly, ";
                sql += "COUNT(CASE WHEN w_workoncf = '결근' THEN 1 END) AS cntOff, SUM(TIME_TO_SEC(w_ew)) AS sum_ew, ";
                sql += "SUM(TIME_TO_SEC(w_hw)) AS sum_hw, SUM(TIME_TO_SEC(w_tw)) AS sum_tw FROM workrecord WHERE w_e_rfid = '";
                sql += e_id_list[i] + "' AND w_day >= '" + from_month_sql + "' AND w_day < '" + to_month_sql + "'";
                try
                {
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    w_e_name = (string)reader["w_e_name"];
                    w_e_position = (string)reader["w_e_position"];
                    w_dm_id = Convert.ToInt32(reader["w_dm_id"]);
                    cntLate = Convert.ToInt32(reader["cntLate"]);
                    cntEarly = Convert.ToInt32(reader["cntEarly"]);
                    cntOff = Convert.ToInt32(reader["cntOff"]);
                    sum_ew = Convert.ToInt32(reader["sum_ew"]);
                    sum_hw = Convert.ToInt32(reader["sum_hw"]);
                    sum_tw = Convert.ToInt32(reader["sum_tw"]);
                    reader.Close();
                }
                catch (MySqlException)
                {
                    reader.Close();
                    MessageBox.Show("Monthly SELECT COUNT e_rfid Exception !!!");
                }
                dgv_monthly.Rows.Add(department_name[w_dm_id], w_e_name, w_e_position, cntLate, cntEarly, cntOff, sum_ew / 3600 + "시간 " + sum_ew /60 % 60 + "분", sum_hw / 3600 + "시간 " + sum_hw / 60 % 60 + "분", sum_tw / 3600 + "시간 " + sum_tw /60 % 60 + "분");
            }
            label_monthly_search.Text = "검색 기준 : " + from_year + "년 " + from_month + "월 기준";
            drawMonthlyTnAChart(from_year, from_month_sql, to_month_sql);
        }
        private void monthly_search_DGV()
        {
            if(tb_monthly_dpName.Text == "" && tb_monthly_month.Text == "" && tb_monthly_year.Text == "")
            {
                return;
            }
            DateTime today = DateTime.Today;

            string from_year = "";
            if(tb_monthly_year.Text == "")
            {
                from_year = today.Year.ToString();
            }
            else if(tb_monthly_year.Text.Length != 4)
            {
                from_year = "2021";
            }
            else
            {
                from_year = tb_monthly_year.Text;
            }

            string from_month = "";
            if(tb_monthly_month.Text == "")
            {
                if (today.Month < 10)
                {
                    from_month = "0" + today.Month.ToString();
                }
                else
                {
                    from_month = today.Month.ToString();
                }
            }
            else
            {
                if(int.Parse(tb_monthly_month.Text) < 10 && tb_monthly_month.Text.Length < 2)
                {
                    from_month = "0" + tb_monthly_month.Text;
                }
                else
                {
                    from_month = tb_monthly_month.Text;
                }
            }
            string from_month_sql = from_year + from_month + "01";

            string to_year = "";
            string to_month = "";
            if (int.Parse(from_month) == 12)
            {
                to_year = (int.Parse(from_year) + 1).ToString();
                to_month = "01";
            }
            else if (int.Parse(from_month) < 9) // 1 ~ 8
            {
                to_year = from_year;
                to_month = "0" + (int.Parse(from_month) + 1).ToString();
            }
            else // (9 ~ 11)
            {
                to_year = from_year;
                to_month = (int.Parse(from_month) + 1).ToString();
            }

            string to_month_sql = to_year + to_month + "01";
            if(tb_monthly_dpName.Text != "")
            {
                e_id_list.Clear();
                sql = "SELECT e_rfid FROM employee WHERE e_dm_id = ";
                List<string> li = department_name.ToList();
                int index = li.FindIndex(x => x.Contains(tb_monthly_dpName.Text));
                sql += index;
                try
                {
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        e_id_list.Add((string)reader["e_rfid"]);
                    }
                    reader.Close();
                }
                catch (MySqlException)
                {
                    reader.Close();
                    MessageBox.Show("Please enter the department name correctly !!!");
                }
            }
            else
            {
                e_id_list.Clear();
                sql = "SELECT e_rfid FROM employee";
                try
                {
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        e_id_list.Add((string)reader["e_rfid"]);
                    }
                    reader.Close();
                }
                catch (MySqlException)
                {
                    reader.Close();
                    MessageBox.Show("Monthly SELECT e_rfid Exception !!! ");
                }
            }
            
            // SELECT COUNT(CASE WHEN w_workoncf = '지각' THEN 1 END) AS cntLate, 
            //COUNT(CASE WHEN w_workoffcf = '조퇴' THEN 1 END) AS cntEarly, 
            //COUNT(CASE WHEN w_workoncf = '결근' THEN 1 END) AS cntOff, SUM(TIME_TO_SEC(w_ew)) AS sum_ew, 
            //SUM(TIME_TO_SEC(w_hw)) AS sum_hw, SUM(TIME_TO_SEC(w_tw)) AS sum_tw 
            //FROM workrecord WHERE w_e_rfid = '0000000007' AND w_day >= '20210501' AND w_day < '20210601';
            int cntLate = 0, cntEarly = 0, cntOff = 0;
            int sum_ew = 0, sum_hw = 0, sum_tw = 0, w_dm_id = 0;
            string w_e_name = "", w_e_position = "";
            dgv_monthly.Rows.Clear();
            // x / 3600 = hour, x / 60 % 60 = minute
            for (int i = 0; i < e_id_list.Count; i++)
            {
                sql = "SELECT w_dm_id, w_e_name, w_e_position, COUNT(CASE WHEN w_workoncf = '지각' THEN 1 END) AS cntLate, ";
                sql += "COUNT(CASE WHEN w_workoffcf = '조퇴' THEN 1 END) AS cntEarly, ";
                sql += "COUNT(CASE WHEN w_workoncf = '결근' THEN 1 END) AS cntOff, SUM(TIME_TO_SEC(w_ew)) AS sum_ew, ";
                sql += "SUM(TIME_TO_SEC(w_hw)) AS sum_hw, SUM(TIME_TO_SEC(w_tw)) AS sum_tw FROM workrecord WHERE w_e_rfid = '";
                sql += e_id_list[i] + "' AND w_day >= '" + from_month_sql + "' AND w_day < '" + to_month_sql + "'";
                try
                {
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    if(reader["w_e_name"] == DBNull.Value)
                    {
                        reader.Close();
                        continue;
                    }
                    w_e_name = (string)reader["w_e_name"];
                    w_e_position = (string)reader["w_e_position"];
                    w_dm_id = Convert.ToInt32(reader["w_dm_id"]);
                    cntLate = Convert.ToInt32(reader["cntLate"]);
                    cntEarly = Convert.ToInt32(reader["cntEarly"]);
                    cntOff = Convert.ToInt32(reader["cntOff"]);
                    sum_ew = Convert.ToInt32(reader["sum_ew"]);
                    sum_hw = Convert.ToInt32(reader["sum_hw"]);
                    sum_tw = Convert.ToInt32(reader["sum_tw"]);
                    reader.Close();
                }
                catch (MySqlException)
                {
                    reader.Close();
                    MessageBox.Show(sql + "          " + "Monthly SELECT COUNT e_rfid Exception !!!");
                }
                dgv_monthly.Rows.Add(department_name[w_dm_id], w_e_name, w_e_position, cntLate, cntEarly, cntOff, sum_ew / 3600 + "시간 " + sum_ew / 60 % 60 + "분", sum_hw / 3600 + "시간 " + sum_hw / 60 % 60 + "분", sum_tw / 3600 + "시간 " + sum_tw / 60 % 60 + "분");
            }
            label_monthly_search.Text = "검색 내용 : " + from_year + "년 " + from_month + "월 " + tb_monthly_dpName.Text;
            drawMonthlyTnAChart(from_year, from_month_sql, to_month_sql);
        }
        private void btn_monthly_search1_Click(object sender, EventArgs e)
        {
            monthly_search_DGV();
        }
        private void btn_monthly_search2_Click(object sender, EventArgs e)
        {
            monthly_search_DGV();
        }
        private void btn_monthly_init1_Click(object sender, EventArgs e)
        {
            showMonthlyDGV();
        }
        private void btn_monthly_init2_Click(object sender, EventArgs e)
        {
            showMonthlyDGV();
        }
        private void label23_Paint(object sender, PaintEventArgs e)
        {
            // 3, 10, 11, 12
            ControlPaint.DrawBorder(e.Graphics, label23.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
            ControlPaint.DrawBorder(e.Graphics, label22.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
            ControlPaint.DrawBorder(e.Graphics, label21.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
        }
        private void tp_monthly_TnA_status_Paint(object sender, PaintEventArgs e)
        {
            // monthly label boder darw
            tb_monthly_dpName.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.FromArgb(0, 0, 192));
            Graphics g = e.Graphics;
            int variance = 1;
            g.DrawRectangle(p, new Rectangle(tb_monthly_dpName.Location.X - variance, tb_monthly_dpName.Location.Y - variance, tb_monthly_dpName.Width + variance, tb_monthly_dpName.Height + variance));

            tb_monthly_month.BorderStyle = BorderStyle.None;
            Graphics g2 = e.Graphics;
            g2.DrawRectangle(p, new Rectangle(tb_monthly_month.Location.X - variance, tb_monthly_month.Location.Y - variance, tb_monthly_month.Width + variance, tb_monthly_month.Height + variance));

            tb_monthly_year.BorderStyle = BorderStyle.None;
            Graphics g3 = e.Graphics;
            g3.DrawRectangle(p, new Rectangle(tb_monthly_year.Location.X - variance, tb_monthly_year.Location.Y - variance, tb_monthly_year.Width + variance, tb_monthly_year.Height + variance));
        }
        // ---------------------------------------- end monthly TnA status ----------------------------------------

        // ---------------------------------------- start monthly TnA chart ----------------------------------------
        private void drawMonthlyTnAChart(string from_year, string from_month_sql, string to_month_sql)
        {
            // SELECT w_e_name, SUM(TIME_TO_SEC(w_tw)) AS sum_tw FROM workrecord 
            // WHERE w_day >= '20210501' AND w_day < '20210601' GROUP BY w_e_rfid;
            try
            {
                sql = "SELECT w_e_name, SUM(TIME_TO_SEC(w_tw)) AS sum_tw FROM workrecord ";
                sql += "WHERE w_day >= '" + from_month_sql + "' AND w_day < '" + to_month_sql + "' GROUP BY w_e_rfid";
                cmd.CommandText = sql;
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException)
            {
                reader.Close();
                MessageBox.Show("drawChartMonthly FROM workrecord Exception !!!");
            }
            List<string> w_e_name = new List<string>();
            List<int> sum_tw = new List<int>();

            while (reader.Read())
            {
                w_e_name.Add((string)reader["w_e_name"]);
                sum_tw.Add(Convert.ToInt32(reader["sum_tw"]) / 3600);
            }
            monthly_chart.Series.Clear();
            monthly_chart.Series.Add("Series1");
            monthly_chart.ChartAreas[0].AxisY.Minimum = 0;
            monthly_chart.ChartAreas[0].AxisY.Maximum = 220;
            monthly_chart.ChartAreas[0].AxisX.Interval = 1;
            Random rnd = new Random();

            for (int i = 0; i < w_e_name.Count; i++)
            {
                monthly_chart.Series[0].Points.AddXY(w_e_name[i], sum_tw[i]);
                monthly_chart.Series[0].Points[i].Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                monthly_chart.Series[0].Points[i].Label = sum_tw[i].ToString();
                monthly_chart.Series[0].Points[i].LabelForeColor = Color.DodgerBlue;
                monthly_chart.Series[0].Points[i].Font = new Font("MD이솝체", 12, FontStyle.Bold);
            }

            reader.Close();
            label_monthly_chart.Text = from_year + "년 " + from_month_sql.Substring(4, 2) + "월 총 근무시간 현황";
        }
        private void monthly_chart_search()
        {
            DateTime today = DateTime.Today;
            string from_year = "";
            if (tb_monthly_char_year.Text == "")
            {
                from_year = today.Year.ToString();
            }
            else if (tb_monthly_char_year.Text.Length != 4)
            {
                from_year = today.Year.ToString();
            }
            else
            {
                from_year = tb_monthly_char_year.Text;
            }

            string from_month = "";
            if (tb_monthly_char_month.Text == "")
            {
                if (today.Month < 10)
                {
                    from_month = "0" + today.Month.ToString();
                }
                else
                {
                    from_month = today.Month.ToString();
                }
            }
            else
            {
                if (int.Parse(tb_monthly_char_month.Text) < 10 && tb_monthly_char_month.Text.Length < 2)
                {
                    from_month = "0" + tb_monthly_char_month.Text;
                }
                else
                {
                    from_month = tb_monthly_char_month.Text;
                }
            }
            string from_month_sql = from_year + from_month + "01";

            string to_year = "";
            string to_month = "";
            if (int.Parse(from_month) == 12)
            {
                to_year = (int.Parse(from_year) + 1).ToString();
                to_month = "01";
            }
            else if (int.Parse(from_month) < 10) // 1 ~ 9
            {
                to_year = from_year;
                to_month = "0" + (int.Parse(from_month) + 1).ToString();
            }
            else // (10 ~ 11)
            {
                to_year = from_year;
                to_month = (int.Parse(from_month) + 1).ToString();
            }
            string to_month_sql = to_year + to_month + "01";
            drawMonthlyTnAChart(from_year, from_month_sql, to_month_sql);
        }

        private void btn_monthly_char2_Click(object sender, EventArgs e)
        {
            monthly_chart_search();
        }
        private void btn_monthly_char1_Click(object sender, EventArgs e)
        {
            monthly_chart_search();
        }
        private void label9_Paint(object sender, PaintEventArgs e)
        {
            // 9
            ControlPaint.DrawBorder(e.Graphics, label9.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
        }
        private void label6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label6.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
        }
        private void tp_monthly_TnA_chart_Paint(object sender, PaintEventArgs e)
        {
            tb_monthly_char_year.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.FromArgb(0, 0, 192));
            Graphics g = e.Graphics;
            int variance = 1;
            g.DrawRectangle(p, new Rectangle(tb_monthly_char_year.Location.X - variance, tb_monthly_char_year.Location.Y - variance, tb_monthly_char_year.Width + variance, tb_monthly_char_year.Height + variance));

            tb_monthly_char_month.BorderStyle = BorderStyle.None;
            Graphics g2 = e.Graphics;
            g2.DrawRectangle(p, new Rectangle(tb_monthly_char_month.Location.X - variance, tb_monthly_char_month.Location.Y - variance, tb_monthly_char_month.Width + variance, tb_monthly_char_month.Height + variance));
        }
        // ---------------------------------------- end monthly TnA chart ----------------------------------------

        // ---------------------------------------- start employee registration ----------------------------------------
        private void button1_Click(object sender, EventArgs e)
        { // btn_registration_reg
            if (!registeMode)
            { // unRegistration
                try
                {
                    // retirement table upload
                    // SELECT w_e_name, w_dm_id, w_e_position, MIN(w_day) AS start_date, 
                    // MAX(w_day) AS last_date FROM workrecord WHERE w_e_rfid = '6a703fb491';
                    sql = "SELECT MIN(w_day) AS start_date, MAX(w_day) AS last_date FROM workrecord WHERE w_e_rfid = '";
                    sql += tb_registration_rfid.Text + "'";
                    cmd.CommandText = sql;
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    string w_e_name = tb_registration_name.Text;
                    int w_dm_id = int.Parse(tb_registration_dm_id.Text);
                    string w_e_position = tb_registration_position.Text;
                    DateTime start_date = (DateTime)reader["start_date"];
                    DateTime last_date = (DateTime)reader["last_date"];
                    // period of continuous service calculation 
                    string str_start_date = start_date.ToString("yyyy-MM-dd");
                    string str_last_date = last_date.ToString("yyyy-MM-dd");
                    string[] tokens = str_start_date.Split('-');
                    DateTime diff_start = new DateTime(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));
                    tokens = str_last_date.Split('-');
                    DateTime diff_last = new DateTime(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]));
                    TimeSpan dateDiff = last_date - start_date;
                    int r_twd = (int)dateDiff.TotalDays;

                    reader.Close();

                    // INSERT INTO retirement(r_id, r_name, r_dm_id, r_position, r_wsd, r_ewd, r_twd) 
                    // VALUES(NULL, '송윤석', '개발팀', '부장', '1998-12-31', '2021-5-7', 8164);
                    sql = "INSERT INTO retirement(r_name, r_dm_id, r_position, r_wsd, r_ewd, r_twd) VALUES('";
                    sql += w_e_name + "', '" + department_name[w_dm_id] + "', '";
                    sql += w_e_position + "', '" + str_start_date + "', '";
                    sql += str_last_date + "', " + r_twd + ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    showRetirementDGV();

                    // delete
                    sql = "DELETE FROM workrecord WHERE w_e_rfid = '";
                    sql += tb_registration_rfid.Text + "'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    sql = "DELETE FROM employee WHERE e_rfid = '";
                    sql += tb_registration_rfid.Text + "'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    label_registration_cardEnter.Text = "등록해제 성공 !";
                    tb_registration_rfid.Text = "";
                    tb_registration_status.Text = "";
                    tb_registration_classification.Text = "";
                    tb_registration_name.Text = "";
                    tb_registration_dm_id.Text = "";
                    tb_registration_position.Text = "";
                    serialPort1.WriteLine("unregisterScs" + Environment.NewLine);

                    list_management_employee_DataGridViewInit();
                    record_search_dgv();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("unRegistration DELETE FAIL !!!");
                }
            }
            else
            { // registration
                try
                {
                    sql = "INSERT INTO employee(e_rfid, e_status, e_cf, e_name, e_dm_id, e_position) VALUES ('";
                    sql += tb_registration_rfid.Text + "', '" + tb_registration_status.Text + "', '";
                    sql += tb_registration_classification.Text + "', '" + tb_registration_name.Text + "', ";
                    sql += tb_registration_dm_id.Text + ", '" + tb_registration_position.Text + "')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    label_registration_cardEnter.Text = "사원등록 성공 !";
                    tb_registration_rfid.Text = "";
                    tb_registration_status.Text = "";
                    tb_registration_classification.Text = "";
                    tb_registration_name.Text = "";
                    tb_registration_dm_id.Text = "";
                    tb_registration_position.Text = "";
                    serialPort1.WriteLine("regScs" + Environment.NewLine);
                    dataGridView2.Rows.Clear();
                    list_management_employee_DataGridViewInit();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("registration INSERT FAIL !!!");
                }
            }
        }
        private void tp_employee_registration_Paint(object sender, PaintEventArgs e)
        {
            // draw textbox BorderLine
            tb_registration_classification.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.DodgerBlue);
            Graphics g = e.Graphics;
            int variance = 3;
            g.DrawRectangle(p, new Rectangle(tb_registration_classification.Location.X - variance, tb_registration_classification.Location.Y - variance, tb_registration_classification.Width + variance, tb_registration_classification.Height + variance));

            tb_registration_dm_id.BorderStyle = BorderStyle.None;
            Graphics g2 = e.Graphics;
            g2.DrawRectangle(p, new Rectangle(tb_registration_dm_id.Location.X - variance, tb_registration_dm_id.Location.Y - variance, tb_registration_dm_id.Width + variance, tb_registration_dm_id.Height + variance));

            tb_registration_name.BorderStyle = BorderStyle.None;
            Graphics g3 = e.Graphics;
            g3.DrawRectangle(p, new Rectangle(tb_registration_name.Location.X - variance, tb_registration_name.Location.Y - variance, tb_registration_name.Width + variance, tb_registration_name.Height + variance));

            tb_registration_position.BorderStyle = BorderStyle.None;
            Graphics g4 = e.Graphics;
            g4.DrawRectangle(p, new Rectangle(tb_registration_position.Location.X - variance, tb_registration_position.Location.Y - variance, tb_registration_position.Width + variance, tb_registration_position.Height + variance));

            tb_registration_rfid.BorderStyle = BorderStyle.None;
            Graphics g5 = e.Graphics;
            g5.DrawRectangle(p, new Rectangle(tb_registration_rfid.Location.X - variance, tb_registration_rfid.Location.Y - variance, tb_registration_rfid.Width + variance, tb_registration_rfid.Height + variance));

            tb_registration_status.BorderStyle = BorderStyle.None;
            Graphics g6 = e.Graphics;
            g6.DrawRectangle(p, new Rectangle(tb_registration_status.Location.X - variance, tb_registration_status.Location.Y - variance, tb_registration_status.Width + variance, tb_registration_status.Height + variance));
        }

        private void showRetirementDGV()
        {
            sql = "SELECT * FROM retirement";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();

            string r_name = "";
            string r_dm_id = "";
            string r_position = "";
            DateTime r_wsd = new DateTime();
            DateTime r_ewd = new DateTime();
            int r_twd = 0;

            dgv_retirement.Rows.Clear();
            while (reader.Read())
            {
                r_name = (string)reader["r_name"];
                r_dm_id = (string)reader["r_dm_id"];
                r_position = (string)reader["r_position"];
                r_wsd = (DateTime)reader["r_wsd"];
                r_ewd = (DateTime)reader["r_ewd"];
                r_twd = (int)reader["r_twd"];
                dgv_retirement.Rows.Add(r_name, r_dm_id, r_position, r_wsd.ToString("yyyy-MM-dd"), r_ewd.ToString("yyyy-MM-dd"), r_twd);
            }
            reader.Close();
        }

        // ---------------------------------------- end employee registration ----------------------------------------

        // ---------------------------------------- start department avg chart ----------------------------------------
        private void drawDpChart(string from_year, string from_month_sql, string to_month_sql)
        {
            int w_dm_id = 0, w_twcnt = 0, sum_tw = 0;
            int[] w_twcnt_arr = new int[department_name.Length];
            int[] sum_tw_arr = new int[department_name.Length];
            // SELECT w_dm_id, COUNT(CASE WHEN w_tw >= '00:00:00' THEN 1 END) AS w_twcnt, 
            // SUM(TIME_TO_SEC(w_tw)) AS sum_tw FROM workrecord WHERE w_day >= '20210501' 
            // AND w_day < '20210601' GROUP BY w_e_rfid ORDER BY w_dm_id;
            sql = "SELECT w_dm_id, COUNT(CASE WHEN w_tw >= '00:00:00' THEN 1 END) AS w_twcnt, ";
            sql += "SUM(TIME_TO_SEC(w_tw)) AS sum_tw FROM workrecord WHERE w_day >= '" + from_month_sql;
            sql += "' AND w_day < '" + to_month_sql + "' GROUP BY w_e_rfid ORDER BY w_dm_id";
            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                w_dm_id = Convert.ToInt32(reader["w_dm_id"]);
                w_twcnt = Convert.ToInt32(reader["w_twcnt"]);
                sum_tw = Convert.ToInt32(reader["sum_tw"]);
                if(w_twcnt_arr[w_dm_id] == 0)
                {
                    w_twcnt_arr[w_dm_id] = w_twcnt;
                    sum_tw_arr[w_dm_id] = sum_tw;
                }
                else
                {
                    w_twcnt_arr[w_dm_id] = w_twcnt_arr[w_dm_id] + w_twcnt;
                    sum_tw_arr[w_dm_id] = sum_tw_arr[w_dm_id] + sum_tw;
                }
            }
            try
            {

            }
            catch(MySqlException)
            {
                reader.Close();
                MessageBox.Show("department darw chart SELECT FROM workrecord FAIL !!!");
                return;
            }
            reader.Close();

            List<DateTime> totalWorkList = new List<DateTime>();
            for(int i = 0; i < w_twcnt_arr.Length; i++)
            {
                if(sum_tw_arr[i] == 0)
                {
                    DateTime temp = new DateTime(2021, 1, 1, 0, 0, 0);
                    totalWorkList.Add(temp);
                }
                else
                {
                    DateTime temp = new DateTime(2021, 1, 1, (int)((sum_tw_arr[i] / w_twcnt_arr[i]) / 3600), (int)((sum_tw_arr[i] / w_twcnt_arr[i]) / 60 % 60), 0);
                    totalWorkList.Add(temp);
                }
            }
            
            dp_avg_chart.Series.Clear();
            dp_avg_chart.Series.Add("Series1");
            dp_avg_chart.Series[0].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            dp_avg_chart.ChartAreas[0].AxisY.LabelStyle.Format = "HH:mm";
            dp_avg_chart.ChartAreas[0].AxisX.Interval = 1;
            Random rnd = new Random();
            string point_label = "";

            for (int i = 0; i < w_twcnt_arr.Length; i++)
            {
                dp_avg_chart.Series[0].Points.AddXY(department_name[i], totalWorkList[i]);
                dp_avg_chart.Series[0].Points[i].Color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                point_label = string.Format("{0:HH:mm}", totalWorkList[i]);
                dp_avg_chart.Series[0].Points[i].Label = point_label;
                dp_avg_chart.Series[0].Points[i].LabelForeColor = Color.DodgerBlue;
                dp_avg_chart.Series[0].Points[i].Font = new Font("MD이솝체", 12, FontStyle.Bold);
            }

            reader.Close();
            // 20210521
            label_dp_searchName.Text = from_year + "년 " + from_month_sql.Substring(4, 2) + "월 부서별 평균 근무시간 현황";
        }
        private void dp_search_chart()
        {
            DateTime today = DateTime.Today;
            string from_year = "";
            if (tb_dp_year.Text == "")
            {
                from_year = today.Year.ToString();
            }
            else if (tb_dp_year.Text.Length != 4)
            {
                from_year = today.Year.ToString();
            }
            else
            {
                from_year = tb_dp_year.Text;
            }

            string from_month = "";
            if (tb_dp_month.Text == "")
            {
                if (today.Month < 10)
                {
                    from_month = "0" + today.Month.ToString();
                }
                else
                {
                    from_month = today.Month.ToString();
                }
            }
            else
            {
                if (int.Parse(tb_dp_month.Text) < 10 && tb_dp_month.Text.Length < 2)
                {
                    from_month = "0" + tb_dp_month.Text;
                }
                else
                {
                    from_month = tb_dp_month.Text;
                }
            }
            string from_month_sql = from_year + from_month + "01";

            string to_year = "";
            string to_month = "";
            if (int.Parse(from_month) == 12)
            {
                to_year = (int.Parse(from_year) + 1).ToString();
                to_month = "01";
            }
            else if (int.Parse(from_month) < 10) // 1 ~ 9
            {
                to_year = from_year;
                to_month = "0" + (int.Parse(from_month) + 1).ToString();
            }
            else // (10 ~ 11)
            {
                to_year = from_year;
                to_month = (int.Parse(from_month) + 1).ToString();
            }
            string to_month_sql = to_year + to_month + "01";
            drawDpChart(from_year, from_month_sql, to_month_sql);
        }
        private void btn_dp_search1_Click(object sender, EventArgs e)
        {
            dp_search_chart();
        }
        private void btn_dp_search2_Click(object sender, EventArgs e)
        {
            dp_search_chart();
        }
        private void tp_department_TnA_status_Paint(object sender, PaintEventArgs e)
        {
            // draw textbox BorderLine
            tb_dp_year.BorderStyle = BorderStyle.None;
            Pen p = new Pen(Color.DodgerBlue);
            Graphics g = e.Graphics;
            int variance = 1;
            g.DrawRectangle(p, new Rectangle(tb_dp_year.Location.X - variance, tb_dp_year.Location.Y - variance, tb_dp_year.Width + variance, tb_dp_year.Height + variance));

            tb_dp_month.BorderStyle = BorderStyle.None;
            Graphics g2 = e.Graphics;
            g2.DrawRectangle(p, new Rectangle(tb_dp_month.Location.X - variance, tb_dp_month.Location.Y - variance, tb_dp_month.Width + variance, tb_dp_month.Height + variance));
        }
        private void label4_Paint(object sender, PaintEventArgs e)
        {
            // draw label BorderLine
            ControlPaint.DrawBorder(e.Graphics, label4.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
        }
        private void label8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, label8.DisplayRectangle, Color.FromArgb(0, 0, 192), ButtonBorderStyle.Solid);
        }
        // ---------------------------------------- end department avg chart ----------------------------------------

        // ---------------------------------------- start menu design ----------------------------------------
        private List<Label> menu;

        private void setMenuChgane(int index)
        {
            // daily TnA status delete... -> inex - 1
            if(index > 1)
            {
                index--;
            }
            // 100, 120, 150, 150, 150, 180, 170
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
        // ---------------------------------------- end menu design ----------------------------------------

        // ---------------------------------------- start C# -> Excel ----------------------------------------
        private void btn_list_manage_excel_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            string today_now = today.ToString("yyyy-MM-dd HH-mm-ss");
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // 바탕화면 경로 
            string path = Path.Combine(desktopPath, "근태관리현황 " + today_now + ".xlsx"); // 엑셀 파일 저장 경로 

            excelApp = new Excel.Application(); // 엑셀 어플리케이션 생성 
            workBook = excelApp.Workbooks.Add(); // 워크북 추가 
            label_manage_excel_save.Visible = true;
            label_manage_excel_save.Text = "엑셀로 저장중... 0%";

            createExcelTable(dataGridView1, "목록 관리");
            label_manage_excel_save.Text = "엑셀로 저장중... 10%";
            createExcelTable(dataGridView2, "사원 정보");
            label_manage_excel_save.Text = "엑셀로 저장중... 20%";
            createExcelTable(dgv_record, "일일 근태 기록");
            label_manage_excel_save.Text = "엑셀로 저장중... 30%";
            createExcelChart(daily_chart, "일일 근태 기록 차트", "일일 근무 기록");
            label_manage_excel_save.Text = "엑셀로 저장중... 40%";
            createExcelTable(dgv_monthly, "월 근태 기록");
            label_manage_excel_save.Text = "엑셀로 저장중... 50%";
            createExcelChart(monthly_chart, "월 근태 기록 차트", "월 근무 기록");
            label_manage_excel_save.Text = "엑셀로 저장중... 60%";
            createExcelChart(dp_avg_chart, "부서별 평균 근무 시간", "부서별 평균 근무 시간");
            label_manage_excel_save.Text = "엑셀로 저장중... 80%";
            createExcelTable(dgv_retirement, "퇴사자 명단");
            label_manage_excel_save.Text = "엑셀로 저장중... 90%";

            workBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault); // 엑셀 파일 저장 
            workBook.Close(true);
            label_manage_excel_save.Text = "엑셀로 저장중... 100%";
            excelApp.Quit();

            ReleaseObject(workSheet1);
            ReleaseObject(workBook);
            ReleaseObject(excelApp);
            label_manage_excel_save.Visible = false;
            MessageBox.Show("저장 완료 !!!");

        }
        private void createExcelTable(DataGridView dgv, string wsNname)
        {
            workSheet1 = null;
            int start_cell_y = 4, start_cell_x = 3, start_row_y = 5, start_row_x = 3, total_x = 0;
            try
            {
                workSheet1 = workBook.Worksheets.Add(Type.Missing, workBook.Worksheets[++wsIdx]); // 엑셀 첫번째 워크시트 가져오기 
                workSheet1.Name = wsNname;
                // cell
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    workSheet1.Cells[start_cell_y, start_cell_x + i] = dgv.Columns[i].Name;
                    if (i == dgv.Columns.Count - 1)
                    {
                        Excel.Range celMerge1 = workSheet1.Range[workSheet1.Cells[start_cell_y, start_cell_x], workSheet1.Cells[start_cell_y, start_cell_x + i]];
                        celMerge1.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        celMerge1.Cells.Font.Size = 14;
                        celMerge1.Cells.Font.Color = Color.White;
                        celMerge1.Cells.Font.Bold = true;
                        celMerge1.Cells.Font.Name = "맑은 고딕";
                        celMerge1.Interior.Color = Color.FromArgb(20, 25, 72);
                        celMerge1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }
                // rows
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv.Rows[i].Cells.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value == null)
                        {
                            workSheet1.Cells[start_row_y + i, start_row_x + j] = "";
                        }
                        else
                        {
                            workSheet1.Cells[start_row_y + i, start_row_x + j] = dgv.Rows[i].Cells[j].Value.ToString();
                        }
                        if (i == dgv.Rows.Count - 2 && j == dgv.Rows[i].Cells.Count - 1)
                        {
                            total_x = start_row_y + i + 1;
                            Excel.Range celMerge1 = workSheet1.Range[workSheet1.Cells[start_row_y, start_row_x], workSheet1.Cells[start_row_y + i, start_row_x + j]];
                            celMerge1.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            celMerge1.Cells.Font.Size = 12;
                            celMerge1.Cells.Font.Color = Color.Black;
                            celMerge1.Cells.Font.Bold = true;
                            celMerge1.Cells.Font.Name = "맑은 고딕";
                            celMerge1.Interior.Color = Color.LightYellow;
                            celMerge1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        }
                    }
                }
                // last rows
                workSheet1.Cells[total_x, start_row_y] = "Total " + (dgv.Rows.Count - 1).ToString();
                Excel.Range celMerge2 = workSheet1.Range[workSheet1.Cells[start_row_y + dgv.Rows.Count - 1, start_row_x], workSheet1.Cells[start_row_y + dgv.Rows.Count - 1, start_row_x + dgv.Rows[0].Cells.Count - 1]];
                celMerge2.Merge();
                celMerge2.Interior.Color = Color.FromArgb(20, 25, 72);
                celMerge2.Cells.Font.Size = 14;
                celMerge2.Cells.Font.Color = Color.White;
                celMerge2.Cells.Font.Bold = true;
                celMerge2.Cells.Font.Name = "맑은 고딕";
                celMerge2.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                workSheet1.Columns.AutoFit(); // 열 너비 자동 맞춤 
            }
            finally
            {
                ReleaseObject(workSheet1);
            }
        }
        private void createExcelChart(System.Windows.Forms.DataVisualization.Charting.Chart inputChart, string wsNname, string legend)
        {
            // daily_chart.Series[0].Points[i]
            workSheet1 = null;
            try
            {
                workSheet1 = workBook.Worksheets.Add(Type.Missing, workBook.Worksheets[++wsIdx]); // 엑셀 첫번째 워크시트 가져오기 
                workSheet1.Name = wsNname;
                // table
                workSheet1.Cells[1, 1] = "";
                workSheet1.Cells[2, 1] = legend;

                Excel.Range celMerge1 = workSheet1.Range[workSheet1.Cells[1, 1], workSheet1.Cells[2, 1]];
                celMerge1.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                celMerge1.Cells.Font.Size = 14;
                celMerge1.Cells.Font.Color = Color.White;
                celMerge1.Cells.Font.Bold = true;
                celMerge1.Cells.Font.Name = "맑은 고딕";
                celMerge1.Interior.Color = Color.FromArgb(20, 25, 72);
                celMerge1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                for (int i = 0; i < inputChart.Series[0].Points.Count; i++)
                {
                    workSheet1.Cells[1, i + 2] = inputChart.Series[0].Points[i].AxisLabel.ToString();
                    workSheet1.Cells[2, i + 2] = inputChart.Series[0].Points[i].Label.ToString();
                }

                Excel.Range celMerge2 = workSheet1.Range[workSheet1.Cells[1, 2], workSheet1.Cells[2, inputChart.Series[0].Points.Count + 1]];
                celMerge2.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                celMerge2.Cells.Font.Size = 12;
                celMerge2.Cells.Font.Color = Color.Black;
                celMerge2.Cells.Font.Bold = true;
                celMerge2.Cells.Font.Name = "맑은 고딕";
                celMerge2.Interior.Color = Color.LightYellow;
                celMerge2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                workSheet1.Columns.AutoFit(); // 열 너비 자동 맞춤 
                // chart
                Excel.Range chartRange;
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)workSheet1.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(50, 90, 700, 400);
                Excel.Chart chartPage = myChart.Chart;
                char end = Convert.ToChar(65 + (inputChart.Series[0].Points.Count + 1));
                chartRange = workSheet1.get_Range("A1", end + "2");
                chartPage.SetSourceData(chartRange, System.Reflection.Missing.Value);
                Excel.SeriesCollection m_SeriesColl = chartPage.SeriesCollection();

                Random rnd = new Random();
                for(int i = 0; i < inputChart.Series[0].Points.Count; i++)
                {
                    m_SeriesColl.Item(1).Points(i + 1).Format.Fill.ForeColor.RGB = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }

                chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
            }
            finally
            {
                ReleaseObject(workSheet1);
            }
        }
        static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj); // 액셀 객체 해제 
                    obj = null; 
                } 
            } 
            catch(Exception ex) 
            { 
                obj = null; 
                throw ex; 
            } 
            finally 
            { 
                GC.Collect(); // 가비지 수집 
            } 
        }

        // ---------------------------------------- end C# -> Excel ----------------------------------------

        // Reference address
        // https://program-day.tistory.com/18
        // https://blog.naver.com/r8jang/221624822165

        // ---------------------------------------- start click miss ---------------------------------------- 
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btn_daily_TnA_status_Click(object sender, EventArgs e)
        {
        }
        private void Tab_Menu_Back_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btn_record_excel_Click(object sender, EventArgs e)
        {

        }
        private void btn_monthly_excel_Click(object sender, EventArgs e)
        {

        }
        // ---------------------------------------- end click miss ----------------------------------------
    }
}
