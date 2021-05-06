
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
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
            this.tp_record = new System.Windows.Forms.TabPage();
            this.tp_daily_TnA_status = new System.Windows.Forms.TabPage();
            this.tp_daily_TnA_chart = new System.Windows.Forms.TabPage();
            this.tp_monthly_TnA_status = new System.Windows.Forms.TabPage();
            this.tp_monthly_TnA_chart = new System.Windows.Forms.TabPage();
            this.tp_department_TnA_status = new System.Windows.Forms.TabPage();
            this.tp_employee_registration = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DodgerBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("나눔손글씨 펜", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1378, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "   근태 현황관리 프로그램                                               SXQ 주식회사";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Tab_Back
            // 
            this.Tab_Back.Controls.Add(this.Tab_Menu_Back);
            this.Tab_Back.Controls.Add(this.tabControl1);
            this.Tab_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_Back.Location = new System.Drawing.Point(0, 55);
            this.Tab_Back.Margin = new System.Windows.Forms.Padding(4);
            this.Tab_Back.Name = "Tab_Back";
            this.Tab_Back.Size = new System.Drawing.Size(1378, 989);
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
            this.Tab_Menu_Back.Margin = new System.Windows.Forms.Padding(4);
            this.Tab_Menu_Back.Name = "Tab_Menu_Back";
            this.Tab_Menu_Back.Size = new System.Drawing.Size(1378, 48);
            this.Tab_Menu_Back.TabIndex = 0;
            this.Tab_Menu_Back.Paint += new System.Windows.Forms.PaintEventHandler(this.Tab_Menu_Back_Paint);
            // 
            // Tab_Menu_Select_Back
            // 
            this.Tab_Menu_Select_Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.Tab_Menu_Select_Back.Controls.Add(this.Tab_Menu_Select_Bar);
            this.Tab_Menu_Select_Back.Location = new System.Drawing.Point(0, 45);
            this.Tab_Menu_Select_Back.Margin = new System.Windows.Forms.Padding(4);
            this.Tab_Menu_Select_Back.Name = "Tab_Menu_Select_Back";
            this.Tab_Menu_Select_Back.Size = new System.Drawing.Size(1378, 3);
            this.Tab_Menu_Select_Back.TabIndex = 1;
            // 
            // Tab_Menu_Select_Bar
            // 
            this.Tab_Menu_Select_Bar.BackColor = System.Drawing.Color.White;
            this.Tab_Menu_Select_Bar.Location = new System.Drawing.Point(0, 0);
            this.Tab_Menu_Select_Bar.Margin = new System.Windows.Forms.Padding(4);
            this.Tab_Menu_Select_Bar.Name = "Tab_Menu_Select_Bar";
            this.Tab_Menu_Select_Bar.Size = new System.Drawing.Size(100, 3);
            this.Tab_Menu_Select_Bar.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(4, 65);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1470, 12);
            this.panel1.TabIndex = 1;
            // 
            // btn_daily_TnA_status
            // 
            this.btn_daily_TnA_status.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_daily_TnA_status.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_daily_TnA_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_daily_TnA_status.Location = new System.Drawing.Point(220, 0);
            this.btn_daily_TnA_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btn_daily_TnA_status.Name = "btn_daily_TnA_status";
            this.btn_daily_TnA_status.Size = new System.Drawing.Size(150, 45);
            this.btn_daily_TnA_status.TabIndex = 3;
            this.btn_daily_TnA_status.Text = "일일 근태현황";
            this.btn_daily_TnA_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_daily_TnA_status.Click += new System.EventHandler(this.btn_daily_TnA_status_Click);
            // 
            // btn_daily_TnA_chart
            // 
            this.btn_daily_TnA_chart.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_daily_TnA_chart.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_daily_TnA_chart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_daily_TnA_chart.Location = new System.Drawing.Point(370, 0);
            this.btn_daily_TnA_chart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btn_daily_TnA_chart.Name = "btn_daily_TnA_chart";
            this.btn_daily_TnA_chart.Size = new System.Drawing.Size(150, 45);
            this.btn_daily_TnA_chart.TabIndex = 4;
            this.btn_daily_TnA_chart.Text = "일일 근태차트";
            this.btn_daily_TnA_chart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_daily_TnA_chart.Click += new System.EventHandler(this.btn_daily_TnA_chart_Click);
            // 
            // btn_record
            // 
            this.btn_record.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_record.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_record.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_record.Location = new System.Drawing.Point(100, 0);
            this.btn_record.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btn_record.Name = "btn_record";
            this.btn_record.Size = new System.Drawing.Size(120, 45);
            this.btn_record.TabIndex = 2;
            this.btn_record.Text = "출퇴근기록";
            this.btn_record.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_record.Click += new System.EventHandler(this.btn_record_Click);
            // 
            // btn_monthly_TnA_status
            // 
            this.btn_monthly_TnA_status.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_monthly_TnA_status.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_monthly_TnA_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_monthly_TnA_status.Location = new System.Drawing.Point(520, 0);
            this.btn_monthly_TnA_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btn_monthly_TnA_status.Name = "btn_monthly_TnA_status";
            this.btn_monthly_TnA_status.Size = new System.Drawing.Size(150, 45);
            this.btn_monthly_TnA_status.TabIndex = 5;
            this.btn_monthly_TnA_status.Text = "월별 근태현황";
            this.btn_monthly_TnA_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_monthly_TnA_status.Click += new System.EventHandler(this.btn_monthly_TnA_status_Click);
            // 
            // btn_monthly_TnA_chart
            // 
            this.btn_monthly_TnA_chart.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_monthly_TnA_chart.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_monthly_TnA_chart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_monthly_TnA_chart.Location = new System.Drawing.Point(670, 0);
            this.btn_monthly_TnA_chart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btn_monthly_TnA_chart.Name = "btn_monthly_TnA_chart";
            this.btn_monthly_TnA_chart.Size = new System.Drawing.Size(150, 45);
            this.btn_monthly_TnA_chart.TabIndex = 6;
            this.btn_monthly_TnA_chart.Text = "월별 근태차트";
            this.btn_monthly_TnA_chart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_monthly_TnA_chart.Click += new System.EventHandler(this.btn_monthly_TnA_chart_Click);
            // 
            // btn_department_TnA_status
            // 
            this.btn_department_TnA_status.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_department_TnA_status.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_department_TnA_status.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_department_TnA_status.Location = new System.Drawing.Point(820, 0);
            this.btn_department_TnA_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btn_department_TnA_status.Name = "btn_department_TnA_status";
            this.btn_department_TnA_status.Size = new System.Drawing.Size(180, 45);
            this.btn_department_TnA_status.TabIndex = 7;
            this.btn_department_TnA_status.Text = "부서별 근태차트";
            this.btn_department_TnA_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_department_TnA_status.Click += new System.EventHandler(this.btn_department_TnA_status_Click);
            // 
            // btn_employee_registration
            // 
            this.btn_employee_registration.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_employee_registration.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employee_registration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btn_employee_registration.Location = new System.Drawing.Point(1000, 0);
            this.btn_employee_registration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btn_employee_registration.Name = "btn_employee_registration";
            this.btn_employee_registration.Size = new System.Drawing.Size(170, 45);
            this.btn_employee_registration.TabIndex = 8;
            this.btn_employee_registration.Text = "사원등록 / 해제";
            this.btn_employee_registration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_employee_registration.Click += new System.EventHandler(this.btn_employee_registration_Click);
            // 
            // btn_list_management
            // 
            this.btn_list_management.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_list_management.ForeColor = System.Drawing.Color.White;
            this.btn_list_management.Location = new System.Drawing.Point(0, 0);
            this.btn_list_management.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btn_list_management.Name = "btn_list_management";
            this.btn_list_management.Size = new System.Drawing.Size(100, 45);
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
            this.tabControl1.Location = new System.Drawing.Point(-4, 18);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1378, 966);
            this.tabControl1.TabIndex = 1;
            // 
            // tp_list_management
            // 
            this.tp_list_management.Controls.Add(this.label2);
            this.tp_list_management.Location = new System.Drawing.Point(4, 28);
            this.tp_list_management.Name = "tp_list_management";
            this.tp_list_management.Padding = new System.Windows.Forms.Padding(3);
            this.tp_list_management.Size = new System.Drawing.Size(1370, 934);
            this.tp_list_management.TabIndex = 1;
            this.tp_list_management.Text = "목록관리";
            this.tp_list_management.UseVisualStyleBackColor = true;
            // 
            // tp_record
            // 
            this.tp_record.Controls.Add(this.label3);
            this.tp_record.Location = new System.Drawing.Point(4, 28);
            this.tp_record.Name = "tp_record";
            this.tp_record.Padding = new System.Windows.Forms.Padding(3);
            this.tp_record.Size = new System.Drawing.Size(1370, 934);
            this.tp_record.TabIndex = 0;
            this.tp_record.Text = "출퇴근기록";
            this.tp_record.UseVisualStyleBackColor = true;
            // 
            // tp_daily_TnA_status
            // 
            this.tp_daily_TnA_status.Controls.Add(this.label9);
            this.tp_daily_TnA_status.Location = new System.Drawing.Point(4, 28);
            this.tp_daily_TnA_status.Name = "tp_daily_TnA_status";
            this.tp_daily_TnA_status.Size = new System.Drawing.Size(1370, 934);
            this.tp_daily_TnA_status.TabIndex = 2;
            this.tp_daily_TnA_status.Text = "tabPage3";
            this.tp_daily_TnA_status.UseVisualStyleBackColor = true;
            // 
            // tp_daily_TnA_chart
            // 
            this.tp_daily_TnA_chart.Controls.Add(this.label4);
            this.tp_daily_TnA_chart.Location = new System.Drawing.Point(4, 28);
            this.tp_daily_TnA_chart.Name = "tp_daily_TnA_chart";
            this.tp_daily_TnA_chart.Size = new System.Drawing.Size(1370, 934);
            this.tp_daily_TnA_chart.TabIndex = 3;
            this.tp_daily_TnA_chart.Text = "tabPage4";
            this.tp_daily_TnA_chart.UseVisualStyleBackColor = true;
            // 
            // tp_monthly_TnA_status
            // 
            this.tp_monthly_TnA_status.Controls.Add(this.label6);
            this.tp_monthly_TnA_status.Location = new System.Drawing.Point(4, 28);
            this.tp_monthly_TnA_status.Name = "tp_monthly_TnA_status";
            this.tp_monthly_TnA_status.Size = new System.Drawing.Size(1370, 934);
            this.tp_monthly_TnA_status.TabIndex = 4;
            this.tp_monthly_TnA_status.Text = "tabPage5";
            this.tp_monthly_TnA_status.UseVisualStyleBackColor = true;
            // 
            // tp_monthly_TnA_chart
            // 
            this.tp_monthly_TnA_chart.Controls.Add(this.label5);
            this.tp_monthly_TnA_chart.Location = new System.Drawing.Point(4, 28);
            this.tp_monthly_TnA_chart.Name = "tp_monthly_TnA_chart";
            this.tp_monthly_TnA_chart.Size = new System.Drawing.Size(1370, 934);
            this.tp_monthly_TnA_chart.TabIndex = 5;
            this.tp_monthly_TnA_chart.Text = "tabPage6";
            this.tp_monthly_TnA_chart.UseVisualStyleBackColor = true;
            // 
            // tp_department_TnA_status
            // 
            this.tp_department_TnA_status.Controls.Add(this.label8);
            this.tp_department_TnA_status.Location = new System.Drawing.Point(4, 28);
            this.tp_department_TnA_status.Name = "tp_department_TnA_status";
            this.tp_department_TnA_status.Size = new System.Drawing.Size(1370, 934);
            this.tp_department_TnA_status.TabIndex = 6;
            this.tp_department_TnA_status.Text = "tabPage7";
            this.tp_department_TnA_status.UseVisualStyleBackColor = true;
            // 
            // tp_employee_registration
            // 
            this.tp_employee_registration.Controls.Add(this.label7);
            this.tp_employee_registration.Location = new System.Drawing.Point(4, 28);
            this.tp_employee_registration.Name = "tp_employee_registration";
            this.tp_employee_registration.Size = new System.Drawing.Size(1370, 934);
            this.tp_employee_registration.TabIndex = 7;
            this.tp_employee_registration.Text = "tabPage8";
            this.tp_employee_registration.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "목록관리";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "출퇴근기록";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "일일근태차트";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(12, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 36);
            this.label5.TabIndex = 3;
            this.label5.Text = "월별 근태차트";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(12, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 36);
            this.label6.TabIndex = 4;
            this.label6.Text = "월별 근태현황";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(12, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 36);
            this.label7.TabIndex = 5;
            this.label7.Text = "사원등록/ 해제";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(38, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(287, 36);
            this.label8.TabIndex = 5;
            this.label8.Text = "부서별 근태차트";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(12, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(250, 36);
            this.label9.TabIndex = 5;
            this.label9.Text = "일일 근태현황";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 1044);
            this.Controls.Add(this.Tab_Back);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}

