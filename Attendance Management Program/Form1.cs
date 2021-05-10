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
        string tapName = ""; // Selected tabName
        bool registeMode = false; // Selected RegisterMode
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
            dgv_record.Columns[3].Name = "직급";
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
            // record_DataGridView From DB
            // label_record_search init
            string searchToday = DateTime.Now.ToString("yyyy-MM-dd");
            string query = "SELECT * FROM workRecord WHERE w_day = '";
            query += searchToday + "'";
            showRecodDGV(query);
            label_record_search.Text = "검색 내용 -> " + searchToday;
        }

        // -------------------------------- start tap control --------------------------------
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "tp_list_management":
                    tapName = "tp_list_management";
                    break;
                case "tp_record":
                    tapName = "tp_record";
                    break;
                case "tp_daily_TnA_status":
                    tapName = "tp_daily_TnA_status";
                    break;
                case "tp_daily_TnA_chart":
                    tapName = "tp_daily_TnA_chart";
                    break;
                case "tp_monthly_TnA_status":
                    tapName = "tp_monthly_TnA_status";
                    break;
                case "tp_monthly_TnA_chart":
                    tapName = "tp_monthly_TnA_chart";
                    break;
                case "tp_department_TnA_status":
                    tapName = "tp_department_TnA_status";
                    break;
                case "tp_employee_registration":
                    tapName = "tp_employee_registration";
                    serialPort1.WriteLine("startRegMODE" + Environment.NewLine);
                    break;
                default:
                    break;
            }
        }

        // -------------------------------- end tap control --------------------------------

        // ------------------------------------------- start STM32 -> C# -------------------------------------------
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            datain = serialPort1.ReadLine();
            this.Invoke(new EventHandler(dataParse));
        }
        private void dataParse(object sender, EventArgs e)
        {
            if(tapName == "tp_employee_registration")
            {
                if (datain.Length != 10)
                {
                    serialPort1.WriteLine("regFAIL" + Environment.NewLine);
                    return;
                }
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
                    catch(MySqlException)
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
        }
        // ------------------------------------------- end STM32 -> C# -------------------------------------------

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
                // init Rows
                while (reader.Read())
                {
                    dm_name = (string)reader["dm_name"];
                    dm_id = (int)reader["dm_id"];
                    dataGridView1.Rows.Add(++noIndex, dm_name, string.Format("{0:D3}", dm_id));
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
        // ------------------------- end recod TAB -------------------------

        // ---------------------------------------- start employee registration ----------------------------------------
        private void button1_Click(object sender, EventArgs e)
        { // btn_registration_reg
            if(!registeMode)
            { // unRegistration
                try
                {
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
                    dataGridView2.Rows.Clear();
                    list_management_employee_DataGridViewInit();
                }
                catch(MySqlException)
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
        //INSERT INTO employee(e_rfid, e_status, e_cf, e_name, e_dm_id, e_position) 
        //VALUES('0000000000', '재직', '정규직', '이기훈', 0, '대표이사');

        // ---------------------------------------- end employee registration ----------------------------------------

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
