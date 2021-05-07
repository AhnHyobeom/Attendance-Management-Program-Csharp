
namespace Attendance_Management_Program
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label_main_top_left = new System.Windows.Forms.Label();
            this.Tab_Back = new System.Windows.Forms.Panel();
            this.Tab_Menu_Back = new System.Windows.Forms.Panel();
            this.Tab_Menu_Select_Back = new System.Windows.Forms.Panel();
            this.Tab_Menu_Select_Bar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_daily_TnA_status = new System.Windows.Forms.Label();
            this.btn_daily_TnA_chart = new System.Windows.Forms.Label();
            this.btn_record = new System.Windows.Forms.Label();
            this.btn_monthly_TnA_status = new System.Windows.Forms.Label();
            this.btn_monthly_TnA_chart = new System.Windows.Forms.Label();
            this.btn_department_TnA_status = new System.Windows.Forms.Label();
            this.btn_employee_registration = new System.Windows.Forms.Label();
            this.btn_list_management = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_list_management = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tp_record = new System.Windows.Forms.TabPage();
            this.tp_daily_TnA_status = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.tp_daily_TnA_chart = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tp_monthly_TnA_status = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tp_monthly_TnA_chart = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tp_department_TnA_status = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.tp_employee_registration = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dgv_record = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_record_workday = new System.Windows.Forms.TextBox();
            this.tb_record_dename = new System.Windows.Forms.TextBox();
            this.tb_record_name = new System.Windows.Forms.TextBox();
            this.tb_record_position = new System.Windows.Forms.TextBox();
            this.btn_record_search1 = new System.Windows.Forms.Button();
            this.btn_record_search2 = new System.Windows.Forms.Button();
            this.btn_record_init2 = new System.Windows.Forms.Button();
            this.btn_record_init1 = new System.Windows.Forms.Button();
            this.Tab_Back.SuspendLayout();
            this.Tab_Menu_Back.SuspendLayout();
            this.Tab_Menu_Select_Back.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tp_list_management.SuspendLayout();
            this.tp_record.SuspendLayout();
            this.tp_daily_TnA_status.SuspendLayout();
            this.tp_daily_TnA_chart.SuspendLayout();
            this.tp_monthly_TnA_status.SuspendLayout();
            this.tp_monthly_TnA_chart.SuspendLayout();
            this.tp_department_TnA_status.SuspendLayout();
            this.tp_employee_registration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_record)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label_main_top_left
            // 
            this.label_main_top_left.BackColor = System.Drawing.Color.DodgerBlue;
            this.label_main_top_left.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_main_top_left.Font = new System.Drawing.Font("나눔손글씨 펜", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_main_top_left.ForeColor = System.Drawing.Color.White;
            this.label_main_top_left.Location = new System.Drawing.Point(0, 0);
            this.label_main_top_left.Name = "label_main_top_left";
            this.label_main_top_left.Size = new System.Drawing.Size(1177, 46);
            this.label_main_top_left.TabIndex = 0;
            this.label_main_top_left.Text = "   근태 현황관리 프로그램                                                                  " +
    "       SXQ 주식회사";
            this.label_main_top_left.Click += new System.EventHandler(this.label1_Click);
            // 
            // Tab_Back
            // 
            this.Tab_Back.Controls.Add(this.Tab_Menu_Back);
            this.Tab_Back.Controls.Add(this.tabControl1);
            this.Tab_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_Back.Location = new System.Drawing.Point(0, 46);
            this.Tab_Back.Name = "Tab_Back";
            this.Tab_Back.Size = new System.Drawing.Size(1177, 707);
            this.Tab_Back.TabIndex = 1;
            // 
            // Tab_Menu_Back
            // 
            this.Tab_Menu_Back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_Menu_Back.BackColor = System.Drawing.Color.DodgerBlue;
            this.Tab_Menu_Back.Controls.Add(this.Tab_Menu_Select_Back);
            this.Tab_Menu_Back.Controls.Add(this.panel1);
            this.Tab_Menu_Back.Controls.Add(this.btn_daily_TnA_status);
            this.Tab_Menu_Back.Controls.Add(this.btn_daily_TnA_chart);
            this.Tab_Menu_Back.Controls.Add(this.btn_record);
            this.Tab_Menu_Back.Controls.Add(this.btn_monthly_TnA_status);
            this.Tab_Menu_Back.Controls.Add(this.btn_monthly_TnA_chart);
            this.Tab_Menu_Back.Controls.Add(this.btn_department_TnA_status);
            this.Tab_Menu_Back.Controls.Add(this.btn_employee_registration);
            this.Tab_Menu_Back.Controls.Add(this.btn_list_management);
            this.Tab_Menu_Back.Location = new System.Drawing.Point(0, 0);
            this.Tab_Menu_Back.Name = "Tab_Menu_Back";
            this.Tab_Menu_Back.Size = new System.Drawing.Size(1177, 40);
            this.Tab_Menu_Back.TabIndex = 0;
            this.Tab_Menu_Back.Paint += new System.Windows.Forms.PaintEventHandler(this.Tab_Menu_Back_Paint);
            // 
            // Tab_Menu_Select_Back
            // 
            this.Tab_Menu_Select_Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.Tab_Menu_Select_Back.Controls.Add(this.Tab_Menu_Select_Bar);
            this.Tab_Menu_Select_Back.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Tab_Menu_Select_Back.Location = new System.Drawing.Point(0, 37);
            this.Tab_Menu_Select_Back.Name = "Tab_Menu_Select_Back";
            this.Tab_Menu_Select_Back.Size = new System.Drawing.Size(1177, 3);
            this.Tab_Menu_Select_Back.TabIndex = 1;
            // 
            // Tab_Menu_Select_Bar
            // 
            this.Tab_Menu_Select_Bar.BackColor = System.Drawing.Color.White;
            this.Tab_Menu_Select_Bar.Location = new System.Drawing.Point(0, 0);
            this.Tab_Menu_Select_Bar.Name = "Tab_Menu_Select_Bar";
            this.Tab_Menu_Select_Bar.Size = new System.Drawing.Size(80, 2);
            this.Tab_Menu_Select_Bar.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 10);
            this.panel1.TabIndex = 1;
            // 
            // btn_daily_TnA_status
            // 
            this.btn_daily_TnA_status.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_daily_TnA_status.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_daily_TnA_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_daily_TnA_status.Location = new System.Drawing.Point(220, 0);
            this.btn_daily_TnA_status.Name = "btn_daily_TnA_status";
            this.btn_daily_TnA_status.Size = new System.Drawing.Size(150, 37);
            this.btn_daily_TnA_status.TabIndex = 3;
            this.btn_daily_TnA_status.Text = "일일 근태현황";
            this.btn_daily_TnA_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_daily_TnA_status.Click += new System.EventHandler(this.btn_daily_TnA_status_Click);
            // 
            // btn_daily_TnA_chart
            // 
            this.btn_daily_TnA_chart.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_daily_TnA_chart.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_daily_TnA_chart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_daily_TnA_chart.Location = new System.Drawing.Point(370, 0);
            this.btn_daily_TnA_chart.Name = "btn_daily_TnA_chart";
            this.btn_daily_TnA_chart.Size = new System.Drawing.Size(150, 37);
            this.btn_daily_TnA_chart.TabIndex = 4;
            this.btn_daily_TnA_chart.Text = "일일 근태차트";
            this.btn_daily_TnA_chart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_daily_TnA_chart.Click += new System.EventHandler(this.btn_daily_TnA_chart_Click);
            // 
            // btn_record
            // 
            this.btn_record.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_record.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_record.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_record.Location = new System.Drawing.Point(100, 0);
            this.btn_record.Name = "btn_record";
            this.btn_record.Size = new System.Drawing.Size(120, 37);
            this.btn_record.TabIndex = 2;
            this.btn_record.Text = "출퇴근기록";
            this.btn_record.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_record.Click += new System.EventHandler(this.btn_record_Click);
            // 
            // btn_monthly_TnA_status
            // 
            this.btn_monthly_TnA_status.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_monthly_TnA_status.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_monthly_TnA_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_monthly_TnA_status.Location = new System.Drawing.Point(520, 0);
            this.btn_monthly_TnA_status.Name = "btn_monthly_TnA_status";
            this.btn_monthly_TnA_status.Size = new System.Drawing.Size(150, 37);
            this.btn_monthly_TnA_status.TabIndex = 5;
            this.btn_monthly_TnA_status.Text = "월별 근태현황";
            this.btn_monthly_TnA_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_monthly_TnA_status.Click += new System.EventHandler(this.btn_monthly_TnA_status_Click);
            // 
            // btn_monthly_TnA_chart
            // 
            this.btn_monthly_TnA_chart.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_monthly_TnA_chart.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_monthly_TnA_chart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_monthly_TnA_chart.Location = new System.Drawing.Point(670, 0);
            this.btn_monthly_TnA_chart.Name = "btn_monthly_TnA_chart";
            this.btn_monthly_TnA_chart.Size = new System.Drawing.Size(150, 37);
            this.btn_monthly_TnA_chart.TabIndex = 6;
            this.btn_monthly_TnA_chart.Text = "월별 근태차트";
            this.btn_monthly_TnA_chart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_monthly_TnA_chart.Click += new System.EventHandler(this.btn_monthly_TnA_chart_Click);
            // 
            // btn_department_TnA_status
            // 
            this.btn_department_TnA_status.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_department_TnA_status.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_department_TnA_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_department_TnA_status.Location = new System.Drawing.Point(820, 0);
            this.btn_department_TnA_status.Name = "btn_department_TnA_status";
            this.btn_department_TnA_status.Size = new System.Drawing.Size(180, 37);
            this.btn_department_TnA_status.TabIndex = 7;
            this.btn_department_TnA_status.Text = "부서별 근태차트";
            this.btn_department_TnA_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_department_TnA_status.Click += new System.EventHandler(this.btn_department_TnA_status_Click);
            // 
            // btn_employee_registration
            // 
            this.btn_employee_registration.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_employee_registration.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employee_registration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_employee_registration.Location = new System.Drawing.Point(1000, 0);
            this.btn_employee_registration.Name = "btn_employee_registration";
            this.btn_employee_registration.Size = new System.Drawing.Size(170, 37);
            this.btn_employee_registration.TabIndex = 8;
            this.btn_employee_registration.Text = "사원등록 / 해제";
            this.btn_employee_registration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_employee_registration.Click += new System.EventHandler(this.btn_employee_registration_Click);
            // 
            // btn_list_management
            // 
            this.btn_list_management.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_list_management.ForeColor = System.Drawing.Color.White;
            this.btn_list_management.Location = new System.Drawing.Point(0, 0);
            this.btn_list_management.Name = "btn_list_management";
            this.btn_list_management.Size = new System.Drawing.Size(100, 37);
            this.btn_list_management.TabIndex = 1;
            this.btn_list_management.Text = "목록관리";
            this.btn_list_management.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_list_management.Click += new System.EventHandler(this.btn_list_management_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_list_management);
            this.tabControl1.Controls.Add(this.tp_record);
            this.tabControl1.Controls.Add(this.tp_daily_TnA_status);
            this.tabControl1.Controls.Add(this.tp_daily_TnA_chart);
            this.tabControl1.Controls.Add(this.tp_monthly_TnA_status);
            this.tabControl1.Controls.Add(this.tp_monthly_TnA_chart);
            this.tabControl1.Controls.Add(this.tp_department_TnA_status);
            this.tabControl1.Controls.Add(this.tp_employee_registration);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1177, 707);
            this.tabControl1.TabIndex = 1;
            // 
            // tp_list_management
            // 
            this.tp_list_management.Controls.Add(this.dataGridView2);
            this.tp_list_management.Controls.Add(this.label1);
            this.tp_list_management.Controls.Add(this.dataGridView1);
            this.tp_list_management.Controls.Add(this.label2);
            this.tp_list_management.Location = new System.Drawing.Point(4, 25);
            this.tp_list_management.Margin = new System.Windows.Forms.Padding(2);
            this.tp_list_management.Name = "tp_list_management";
            this.tp_list_management.Padding = new System.Windows.Forms.Padding(2);
            this.tp_list_management.Size = new System.Drawing.Size(1169, 678);
            this.tp_list_management.TabIndex = 1;
            this.tp_list_management.Text = "목록관리";
            this.tp_list_management.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(70, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "■ 목록관리";
            // 
            // tp_record
            // 
            this.tp_record.Controls.Add(this.btn_record_init2);
            this.tp_record.Controls.Add(this.btn_record_init1);
            this.tp_record.Controls.Add(this.tb_record_position);
            this.tp_record.Controls.Add(this.tb_record_name);
            this.tp_record.Controls.Add(this.tb_record_dename);
            this.tp_record.Controls.Add(this.tb_record_workday);
            this.tp_record.Controls.Add(this.btn_record_search2);
            this.tp_record.Controls.Add(this.btn_record_search1);
            this.tp_record.Controls.Add(this.label12);
            this.tp_record.Controls.Add(this.label11);
            this.tp_record.Controls.Add(this.label10);
            this.tp_record.Controls.Add(this.label3);
            this.tp_record.Controls.Add(this.dgv_record);
            this.tp_record.Location = new System.Drawing.Point(4, 25);
            this.tp_record.Margin = new System.Windows.Forms.Padding(2);
            this.tp_record.Name = "tp_record";
            this.tp_record.Padding = new System.Windows.Forms.Padding(2);
            this.tp_record.Size = new System.Drawing.Size(1169, 678);
            this.tp_record.TabIndex = 0;
            this.tp_record.Text = "출퇴근기록";
            this.tp_record.UseVisualStyleBackColor = true;
            this.tp_record.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_record_Paint);
            // 
            // tp_daily_TnA_status
            // 
            this.tp_daily_TnA_status.Controls.Add(this.label9);
            this.tp_daily_TnA_status.Location = new System.Drawing.Point(4, 25);
            this.tp_daily_TnA_status.Margin = new System.Windows.Forms.Padding(2);
            this.tp_daily_TnA_status.Name = "tp_daily_TnA_status";
            this.tp_daily_TnA_status.Size = new System.Drawing.Size(1169, 678);
            this.tp_daily_TnA_status.TabIndex = 2;
            this.tp_daily_TnA_status.Text = "tabPage3";
            this.tp_daily_TnA_status.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(10, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(210, 30);
            this.label9.TabIndex = 5;
            this.label9.Text = "일일 근태현황";
            // 
            // tp_daily_TnA_chart
            // 
            this.tp_daily_TnA_chart.Controls.Add(this.label4);
            this.tp_daily_TnA_chart.Location = new System.Drawing.Point(4, 25);
            this.tp_daily_TnA_chart.Margin = new System.Windows.Forms.Padding(2);
            this.tp_daily_TnA_chart.Name = "tp_daily_TnA_chart";
            this.tp_daily_TnA_chart.Size = new System.Drawing.Size(1169, 678);
            this.tp_daily_TnA_chart.TabIndex = 3;
            this.tp_daily_TnA_chart.Text = "tabPage4";
            this.tp_daily_TnA_chart.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(10, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "일일근태차트";
            // 
            // tp_monthly_TnA_status
            // 
            this.tp_monthly_TnA_status.Controls.Add(this.label6);
            this.tp_monthly_TnA_status.Location = new System.Drawing.Point(4, 25);
            this.tp_monthly_TnA_status.Margin = new System.Windows.Forms.Padding(2);
            this.tp_monthly_TnA_status.Name = "tp_monthly_TnA_status";
            this.tp_monthly_TnA_status.Size = new System.Drawing.Size(1169, 678);
            this.tp_monthly_TnA_status.TabIndex = 4;
            this.tp_monthly_TnA_status.Text = "tabPage5";
            this.tp_monthly_TnA_status.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(10, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 30);
            this.label6.TabIndex = 4;
            this.label6.Text = "월별 근태현황";
            // 
            // tp_monthly_TnA_chart
            // 
            this.tp_monthly_TnA_chart.Controls.Add(this.label5);
            this.tp_monthly_TnA_chart.Location = new System.Drawing.Point(4, 25);
            this.tp_monthly_TnA_chart.Margin = new System.Windows.Forms.Padding(2);
            this.tp_monthly_TnA_chart.Name = "tp_monthly_TnA_chart";
            this.tp_monthly_TnA_chart.Size = new System.Drawing.Size(1169, 678);
            this.tp_monthly_TnA_chart.TabIndex = 5;
            this.tp_monthly_TnA_chart.Text = "tabPage6";
            this.tp_monthly_TnA_chart.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(10, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 30);
            this.label5.TabIndex = 3;
            this.label5.Text = "월별 근태차트";
            // 
            // tp_department_TnA_status
            // 
            this.tp_department_TnA_status.Controls.Add(this.label8);
            this.tp_department_TnA_status.Location = new System.Drawing.Point(4, 25);
            this.tp_department_TnA_status.Margin = new System.Windows.Forms.Padding(2);
            this.tp_department_TnA_status.Name = "tp_department_TnA_status";
            this.tp_department_TnA_status.Size = new System.Drawing.Size(1169, 678);
            this.tp_department_TnA_status.TabIndex = 6;
            this.tp_department_TnA_status.Text = "tabPage7";
            this.tp_department_TnA_status.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(30, 16);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 30);
            this.label8.TabIndex = 5;
            this.label8.Text = "부서별 근태차트";
            // 
            // tp_employee_registration
            // 
            this.tp_employee_registration.Controls.Add(this.label7);
            this.tp_employee_registration.Location = new System.Drawing.Point(4, 25);
            this.tp_employee_registration.Margin = new System.Windows.Forms.Padding(2);
            this.tp_employee_registration.Name = "tp_employee_registration";
            this.tp_employee_registration.Size = new System.Drawing.Size(1169, 678);
            this.tp_employee_registration.TabIndex = 7;
            this.tp_employee_registration.Text = "tabPage8";
            this.tp_employee_registration.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(10, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 30);
            this.label7.TabIndex = 5;
            this.label7.Text = "사원등록/ 해제";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(79, 174);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(381, 387);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(564, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "■ 사원 정보";
            // 
            // dataGridView2
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(573, 174);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(526, 415);
            this.dataGridView2.TabIndex = 3;
            // 
            // dgv_record
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dgv_record.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_record.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_record.BackgroundColor = System.Drawing.Color.White;
            this.dgv_record.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_record.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_record.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_record.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_record.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_record.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_record.EnableHeadersVisualStyles = false;
            this.dgv_record.Location = new System.Drawing.Point(27, 158);
            this.dgv_record.Name = "dgv_record";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_record.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_record.RowHeadersWidth = 51;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgv_record.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_record.RowTemplate.Height = 27;
            this.dgv_record.Size = new System.Drawing.Size(1120, 500);
            this.dgv_record.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "근무일자";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Paint += new System.Windows.Forms.PaintEventHandler(this.label3_Paint);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DodgerBlue;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(154, 41);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 33);
            this.label10.TabIndex = 7;
            this.label10.Text = "부서명";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Paint += new System.Windows.Forms.PaintEventHandler(this.label3_Paint);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DodgerBlue;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(283, 41);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 33);
            this.label11.TabIndex = 8;
            this.label11.Text = "이름";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.Paint += new System.Windows.Forms.PaintEventHandler(this.label3_Paint);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DodgerBlue;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(412, 41);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 33);
            this.label12.TabIndex = 9;
            this.label12.Text = "직급";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Paint += new System.Windows.Forms.PaintEventHandler(this.label3_Paint);
            // 
            // tb_record_workday
            // 
            this.tb_record_workday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_record_workday.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_record_workday.Location = new System.Drawing.Point(26, 74);
            this.tb_record_workday.Multiline = true;
            this.tb_record_workday.Name = "tb_record_workday";
            this.tb_record_workday.Size = new System.Drawing.Size(128, 31);
            this.tb_record_workday.TabIndex = 10;
            this.tb_record_workday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_record_dename
            // 
            this.tb_record_dename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_record_dename.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_record_dename.Location = new System.Drawing.Point(155, 74);
            this.tb_record_dename.Multiline = true;
            this.tb_record_dename.Name = "tb_record_dename";
            this.tb_record_dename.Size = new System.Drawing.Size(128, 31);
            this.tb_record_dename.TabIndex = 11;
            this.tb_record_dename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_record_name
            // 
            this.tb_record_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_record_name.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_record_name.Location = new System.Drawing.Point(284, 74);
            this.tb_record_name.Multiline = true;
            this.tb_record_name.Name = "tb_record_name";
            this.tb_record_name.Size = new System.Drawing.Size(128, 31);
            this.tb_record_name.TabIndex = 12;
            this.tb_record_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_record_position
            // 
            this.tb_record_position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_record_position.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_record_position.Location = new System.Drawing.Point(413, 74);
            this.tb_record_position.Multiline = true;
            this.tb_record_position.Name = "tb_record_position";
            this.tb_record_position.Size = new System.Drawing.Size(128, 31);
            this.tb_record_position.TabIndex = 13;
            this.tb_record_position.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_record_search1
            // 
            this.btn_record_search1.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_record_search1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_search1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_search1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_search1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_record_search1.Image = ((System.Drawing.Image)(resources.GetObject("btn_record_search1.Image")));
            this.btn_record_search1.Location = new System.Drawing.Point(600, 52);
            this.btn_record_search1.Name = "btn_record_search1";
            this.btn_record_search1.Size = new System.Drawing.Size(55, 43);
            this.btn_record_search1.TabIndex = 14;
            this.btn_record_search1.UseVisualStyleBackColor = false;
            // 
            // btn_record_search2
            // 
            this.btn_record_search2.BackColor = System.Drawing.Color.White;
            this.btn_record_search2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_search2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_search2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_search2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_record_search2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_record_search2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_record_search2.Location = new System.Drawing.Point(655, 52);
            this.btn_record_search2.Name = "btn_record_search2";
            this.btn_record_search2.Size = new System.Drawing.Size(129, 43);
            this.btn_record_search2.TabIndex = 15;
            this.btn_record_search2.Text = "검색하기";
            this.btn_record_search2.UseVisualStyleBackColor = false;
            // 
            // btn_record_init2
            // 
            this.btn_record_init2.BackColor = System.Drawing.Color.White;
            this.btn_record_init2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_init2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_init2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_init2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_record_init2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_record_init2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btn_record_init2.Location = new System.Drawing.Point(867, 52);
            this.btn_record_init2.Name = "btn_record_init2";
            this.btn_record_init2.Size = new System.Drawing.Size(129, 43);
            this.btn_record_init2.TabIndex = 17;
            this.btn_record_init2.Text = "원래대로";
            this.btn_record_init2.UseVisualStyleBackColor = false;
            // 
            // btn_record_init1
            // 
            this.btn_record_init1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(36)))), ((int)(((byte)(37)))));
            this.btn_record_init1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_init1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_init1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_record_init1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_record_init1.Image = ((System.Drawing.Image)(resources.GetObject("btn_record_init1.Image")));
            this.btn_record_init1.Location = new System.Drawing.Point(812, 52);
            this.btn_record_init1.Name = "btn_record_init1";
            this.btn_record_init1.Size = new System.Drawing.Size(55, 43);
            this.btn_record_init1.TabIndex = 16;
            this.btn_record_init1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1177, 753);
            this.Controls.Add(this.Tab_Back);
            this.Controls.Add(this.label_main_top_left);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Tab_Back.ResumeLayout(false);
            this.Tab_Menu_Back.ResumeLayout(false);
            this.Tab_Menu_Select_Back.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tp_list_management.ResumeLayout(false);
            this.tp_list_management.PerformLayout();
            this.tp_record.ResumeLayout(false);
            this.tp_record.PerformLayout();
            this.tp_daily_TnA_status.ResumeLayout(false);
            this.tp_daily_TnA_status.PerformLayout();
            this.tp_daily_TnA_chart.ResumeLayout(false);
            this.tp_daily_TnA_chart.PerformLayout();
            this.tp_monthly_TnA_status.ResumeLayout(false);
            this.tp_monthly_TnA_status.PerformLayout();
            this.tp_monthly_TnA_chart.ResumeLayout(false);
            this.tp_monthly_TnA_chart.PerformLayout();
            this.tp_department_TnA_status.ResumeLayout(false);
            this.tp_department_TnA_status.PerformLayout();
            this.tp_employee_registration.ResumeLayout(false);
            this.tp_employee_registration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_record)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label_main_top_left;
        private System.Windows.Forms.Panel Tab_Back;
        private System.Windows.Forms.Panel Tab_Menu_Back;
        private System.Windows.Forms.Label btn_daily_TnA_chart;
        private System.Windows.Forms.Panel Tab_Menu_Select_Back;
        private System.Windows.Forms.Panel Tab_Menu_Select_Bar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label btn_daily_TnA_status;
        private System.Windows.Forms.Label btn_record;
        private System.Windows.Forms.Label btn_list_management;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_list_management;
        private System.Windows.Forms.TabPage tp_record;
        private System.Windows.Forms.Label btn_employee_registration;
        private System.Windows.Forms.Label btn_department_TnA_status;
        private System.Windows.Forms.Label btn_monthly_TnA_status;
        private System.Windows.Forms.Label btn_monthly_TnA_chart;
        private System.Windows.Forms.TabPage tp_daily_TnA_status;
        private System.Windows.Forms.TabPage tp_daily_TnA_chart;
        private System.Windows.Forms.TabPage tp_monthly_TnA_status;
        private System.Windows.Forms.TabPage tp_monthly_TnA_chart;
        private System.Windows.Forms.TabPage tp_department_TnA_status;
        private System.Windows.Forms.TabPage tp_employee_registration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_record_dename;
        private System.Windows.Forms.TextBox tb_record_workday;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_record;
        private System.Windows.Forms.TextBox tb_record_position;
        private System.Windows.Forms.TextBox tb_record_name;
        private System.Windows.Forms.Button btn_record_search1;
        private System.Windows.Forms.Button btn_record_search2;
        private System.Windows.Forms.Button btn_record_init2;
        private System.Windows.Forms.Button btn_record_init1;
    }
}

