namespace RTOS通信上位机
{
    partial class 主界面
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(主界面));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.打开button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.本地端口comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.本地IPcomboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.协议类型comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.数据日志richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.发送设置groupBox2 = new System.Windows.Forms.GroupBox();
            this.周期发送时间numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.发送循环周期checkBox1 = new System.Windows.Forms.CheckBox();
            this.发送十六进制radioButton1 = new System.Windows.Forms.RadioButton();
            this.发送ASCII码radioButton1 = new System.Windows.Forms.RadioButton();
            this.填充用groupBox3 = new System.Windows.Forms.GroupBox();
            this.接收设置groupBox4 = new System.Windows.Forms.GroupBox();
            this.接收十六进制radioButton1 = new System.Windows.Forms.RadioButton();
            this.接收ASCII码radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.接收区清空button1 = new System.Windows.Forms.Button();
            this.发送区清空button1 = new System.Windows.Forms.Button();
            this.RTOS端口comboBox1 = new System.Windows.Forms.ComboBox();
            this.RTOS_IPcomboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.发送区textBox1 = new System.Windows.Forms.TextBox();
            this.发送button1 = new System.Windows.Forms.Button();
            this.发送定时器timer1 = new System.Windows.Forms.Timer(this.components);
            this.异常监控停止服务定时器timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.通用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.发送接收条数toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.接收字节toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.发送字节toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.底部状态条statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.复位计数toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.发送设置groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.周期发送时间numericUpDown1)).BeginInit();
            this.接收设置groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.底部状态条statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.打开button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.本地端口comboBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.本地IPcomboBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.协议类型comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 178);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地网络设置";
            // 
            // 打开button1
            // 
            this.打开button1.Location = new System.Drawing.Point(20, 142);
            this.打开button1.Name = "打开button1";
            this.打开button1.Size = new System.Drawing.Size(110, 30);
            this.打开button1.TabIndex = 15;
            this.打开button1.Text = "打开";
            this.打开button1.UseVisualStyleBackColor = true;
            this.打开button1.Click += new System.EventHandler(this.打开button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "（3）本地主机端口";
            // 
            // 本地端口comboBox3
            // 
            this.本地端口comboBox3.FormattingEnabled = true;
            this.本地端口comboBox3.Items.AddRange(new object[] {
            "8000",
            "8001",
            "8002",
            "8003",
            "8004",
            "8005"});
            this.本地端口comboBox3.Location = new System.Drawing.Point(17, 116);
            this.本地端口comboBox3.Name = "本地端口comboBox3";
            this.本地端口comboBox3.Size = new System.Drawing.Size(121, 20);
            this.本地端口comboBox3.TabIndex = 13;
            this.本地端口comboBox3.TextChanged += new System.EventHandler(this.本地端口comboBox3_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "（2）本地主机地址";
            // 
            // 本地IPcomboBox2
            // 
            this.本地IPcomboBox2.FormattingEnabled = true;
            this.本地IPcomboBox2.Location = new System.Drawing.Point(18, 77);
            this.本地IPcomboBox2.Name = "本地IPcomboBox2";
            this.本地IPcomboBox2.Size = new System.Drawing.Size(121, 20);
            this.本地IPcomboBox2.TabIndex = 11;
            this.本地IPcomboBox2.TextChanged += new System.EventHandler(this.本地IPcomboBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "（1）协议类型";
            // 
            // 协议类型comboBox1
            // 
            this.协议类型comboBox1.BackColor = System.Drawing.Color.White;
            this.协议类型comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.协议类型comboBox1.FormattingEnabled = true;
            this.协议类型comboBox1.Items.AddRange(new object[] {
            "UDP",
            "TCP客户端",
            "TCP服务端"});
            this.协议类型comboBox1.Location = new System.Drawing.Point(17, 37);
            this.协议类型comboBox1.Name = "协议类型comboBox1";
            this.协议类型comboBox1.Size = new System.Drawing.Size(121, 20);
            this.协议类型comboBox1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(173, 25);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(511, 333);
            this.tabControl2.TabIndex = 19;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.数据日志richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(503, 307);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "数据日志";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // 数据日志richTextBox1
            // 
            this.数据日志richTextBox1.BackColor = System.Drawing.Color.White;
            this.数据日志richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.数据日志richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.数据日志richTextBox1.Name = "数据日志richTextBox1";
            this.数据日志richTextBox1.ReadOnly = true;
            this.数据日志richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.数据日志richTextBox1.Size = new System.Drawing.Size(497, 301);
            this.数据日志richTextBox1.TabIndex = 17;
            this.数据日志richTextBox1.Text = "";
            // 
            // 发送设置groupBox2
            // 
            this.发送设置groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.发送设置groupBox2.Controls.Add(this.周期发送时间numericUpDown1);
            this.发送设置groupBox2.Controls.Add(this.label7);
            this.发送设置groupBox2.Controls.Add(this.发送循环周期checkBox1);
            this.发送设置groupBox2.Controls.Add(this.发送十六进制radioButton1);
            this.发送设置groupBox2.Controls.Add(this.发送ASCII码radioButton1);
            this.发送设置groupBox2.Location = new System.Drawing.Point(10, 364);
            this.发送设置groupBox2.Name = "发送设置groupBox2";
            this.发送设置groupBox2.Size = new System.Drawing.Size(155, 136);
            this.发送设置groupBox2.TabIndex = 26;
            this.发送设置groupBox2.TabStop = false;
            this.发送设置groupBox2.Text = "发送设置";
            // 
            // 周期发送时间numericUpDown1
            // 
            this.周期发送时间numericUpDown1.Location = new System.Drawing.Point(75, 102);
            this.周期发送时间numericUpDown1.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.周期发送时间numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.周期发送时间numericUpDown1.Name = "周期发送时间numericUpDown1";
            this.周期发送时间numericUpDown1.Size = new System.Drawing.Size(57, 21);
            this.周期发送时间numericUpDown1.TabIndex = 29;
            this.周期发送时间numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 31;
            this.label7.Text = "ms";
            // 
            // 发送循环周期checkBox1
            // 
            this.发送循环周期checkBox1.AutoSize = true;
            this.发送循环周期checkBox1.Location = new System.Drawing.Point(5, 104);
            this.发送循环周期checkBox1.Name = "发送循环周期checkBox1";
            this.发送循环周期checkBox1.Size = new System.Drawing.Size(72, 16);
            this.发送循环周期checkBox1.TabIndex = 2;
            this.发送循环周期checkBox1.Text = "循环周期";
            this.发送循环周期checkBox1.UseVisualStyleBackColor = true;
            this.发送循环周期checkBox1.CheckedChanged += new System.EventHandler(this.发送循环周期checkBox1_CheckedChanged);
            // 
            // 发送十六进制radioButton1
            // 
            this.发送十六进制radioButton1.AutoSize = true;
            this.发送十六进制radioButton1.Location = new System.Drawing.Point(78, 20);
            this.发送十六进制radioButton1.Name = "发送十六进制radioButton1";
            this.发送十六进制radioButton1.Size = new System.Drawing.Size(71, 16);
            this.发送十六进制radioButton1.TabIndex = 1;
            this.发送十六进制radioButton1.TabStop = true;
            this.发送十六进制radioButton1.Text = "十六进制";
            this.发送十六进制radioButton1.UseVisualStyleBackColor = true;
            this.发送十六进制radioButton1.CheckedChanged += new System.EventHandler(this.发送十六进制radioButton1_CheckedChanged);
            // 
            // 发送ASCII码radioButton1
            // 
            this.发送ASCII码radioButton1.AutoSize = true;
            this.发送ASCII码radioButton1.Location = new System.Drawing.Point(7, 21);
            this.发送ASCII码radioButton1.Name = "发送ASCII码radioButton1";
            this.发送ASCII码radioButton1.Size = new System.Drawing.Size(65, 16);
            this.发送ASCII码radioButton1.TabIndex = 0;
            this.发送ASCII码radioButton1.TabStop = true;
            this.发送ASCII码radioButton1.Text = "ASCII码";
            this.发送ASCII码radioButton1.UseVisualStyleBackColor = true;
            this.发送ASCII码radioButton1.CheckedChanged += new System.EventHandler(this.发送ASCII码radioButton1_CheckedChanged);
            // 
            // 填充用groupBox3
            // 
            this.填充用groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.填充用groupBox3.Location = new System.Drawing.Point(12, 343);
            this.填充用groupBox3.Name = "填充用groupBox3";
            this.填充用groupBox3.Size = new System.Drawing.Size(155, 13);
            this.填充用groupBox3.TabIndex = 27;
            this.填充用groupBox3.TabStop = false;
            this.填充用groupBox3.Text = "-";
            // 
            // 接收设置groupBox4
            // 
            this.接收设置groupBox4.Controls.Add(this.接收十六进制radioButton1);
            this.接收设置groupBox4.Controls.Add(this.接收ASCII码radioButton2);
            this.接收设置groupBox4.Location = new System.Drawing.Point(12, 207);
            this.接收设置groupBox4.Name = "接收设置groupBox4";
            this.接收设置groupBox4.Size = new System.Drawing.Size(155, 138);
            this.接收设置groupBox4.TabIndex = 27;
            this.接收设置groupBox4.TabStop = false;
            this.接收设置groupBox4.Text = "接收设置";
            // 
            // 接收十六进制radioButton1
            // 
            this.接收十六进制radioButton1.AutoSize = true;
            this.接收十六进制radioButton1.Location = new System.Drawing.Point(82, 22);
            this.接收十六进制radioButton1.Name = "接收十六进制radioButton1";
            this.接收十六进制radioButton1.Size = new System.Drawing.Size(71, 16);
            this.接收十六进制radioButton1.TabIndex = 3;
            this.接收十六进制radioButton1.TabStop = true;
            this.接收十六进制radioButton1.Text = "十六进制";
            this.接收十六进制radioButton1.UseVisualStyleBackColor = true;
            this.接收十六进制radioButton1.Click += new System.EventHandler(this.接收十六进制radioButton1_Click);
            // 
            // 接收ASCII码radioButton2
            // 
            this.接收ASCII码radioButton2.AutoSize = true;
            this.接收ASCII码radioButton2.Location = new System.Drawing.Point(11, 23);
            this.接收ASCII码radioButton2.Name = "接收ASCII码radioButton2";
            this.接收ASCII码radioButton2.Size = new System.Drawing.Size(65, 16);
            this.接收ASCII码radioButton2.TabIndex = 2;
            this.接收ASCII码radioButton2.TabStop = true;
            this.接收ASCII码radioButton2.Text = "ASCII码";
            this.接收ASCII码radioButton2.UseVisualStyleBackColor = true;
            this.接收ASCII码radioButton2.Click += new System.EventHandler(this.接收ASCII码radioButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.接收区清空button1);
            this.panel1.Controls.Add(this.发送区清空button1);
            this.panel1.Controls.Add(this.RTOS端口comboBox1);
            this.panel1.Controls.Add(this.RTOS_IPcomboBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tabControl3);
            this.panel1.Location = new System.Drawing.Point(176, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 138);
            this.panel1.TabIndex = 28;
            // 
            // 接收区清空button1
            // 
            this.接收区清空button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.接收区清空button1.Location = new System.Drawing.Point(448, 16);
            this.接收区清空button1.Name = "接收区清空button1";
            this.接收区清空button1.Size = new System.Drawing.Size(51, 23);
            this.接收区清空button1.TabIndex = 30;
            this.接收区清空button1.Text = "上清空";
            this.接收区清空button1.UseVisualStyleBackColor = true;
            this.接收区清空button1.Click += new System.EventHandler(this.接收区清空button1_Click);
            // 
            // 发送区清空button1
            // 
            this.发送区清空button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.发送区清空button1.Location = new System.Drawing.Point(398, 16);
            this.发送区清空button1.Name = "发送区清空button1";
            this.发送区清空button1.Size = new System.Drawing.Size(51, 23);
            this.发送区清空button1.TabIndex = 3;
            this.发送区清空button1.Text = "下清空";
            this.发送区清空button1.UseVisualStyleBackColor = true;
            this.发送区清空button1.Click += new System.EventHandler(this.发送区清空button1_Click);
            // 
            // RTOS端口comboBox1
            // 
            this.RTOS端口comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RTOS端口comboBox1.FormattingEnabled = true;
            this.RTOS端口comboBox1.Items.AddRange(new object[] {
            "8000",
            "8001",
            "8002",
            "8003",
            "8004",
            "8005"});
            this.RTOS端口comboBox1.Location = new System.Drawing.Point(330, 19);
            this.RTOS端口comboBox1.Name = "RTOS端口comboBox1";
            this.RTOS端口comboBox1.Size = new System.Drawing.Size(65, 20);
            this.RTOS端口comboBox1.TabIndex = 29;
            this.RTOS端口comboBox1.TextChanged += new System.EventHandler(this.RTOS端口comboBox1_TextChanged);
            // 
            // RTOS_IPcomboBox2
            // 
            this.RTOS_IPcomboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTOS_IPcomboBox2.FormattingEnabled = true;
            this.RTOS_IPcomboBox2.Items.AddRange(new object[] {
            "192.168.3.3"});
            this.RTOS_IPcomboBox2.Location = new System.Drawing.Point(147, 19);
            this.RTOS_IPcomboBox2.Name = "RTOS_IPcomboBox2";
            this.RTOS_IPcomboBox2.Size = new System.Drawing.Size(121, 20);
            this.RTOS_IPcomboBox2.TabIndex = 28;
            this.RTOS_IPcomboBox2.TextChanged += new System.EventHandler(this.RTOS_IPcomboBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "RTOS端口:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 25;
            this.label5.Text = "RTOS_IP:";
            // 
            // tabControl3
            // 
            this.tabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Location = new System.Drawing.Point(9, 21);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(496, 100);
            this.tabControl3.TabIndex = 27;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.发送区textBox1);
            this.tabPage3.Controls.Add(this.发送button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(488, 74);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "坐标填充";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // 发送区textBox1
            // 
            this.发送区textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.发送区textBox1.Location = new System.Drawing.Point(6, 3);
            this.发送区textBox1.Multiline = true;
            this.发送区textBox1.Name = "发送区textBox1";
            this.发送区textBox1.Size = new System.Drawing.Size(394, 68);
            this.发送区textBox1.TabIndex = 2;
            this.发送区textBox1.TextChanged += new System.EventHandler(this.发送区textBox1_TextChanged);
            this.发送区textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.发送区textBox1_KeyPress);
            // 
            // 发送button1
            // 
            this.发送button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.发送button1.Location = new System.Drawing.Point(407, 6);
            this.发送button1.Name = "发送button1";
            this.发送button1.Size = new System.Drawing.Size(75, 62);
            this.发送button1.TabIndex = 0;
            this.发送button1.Text = "发送";
            this.发送button1.UseVisualStyleBackColor = true;
            this.发送button1.Click += new System.EventHandler(this.发送button1_Click);
            // 
            // 发送定时器timer1
            // 
            this.发送定时器timer1.Tick += new System.EventHandler(this.发送定时器timer1_Tick);
            // 
            // 异常监控停止服务定时器timer1
            // 
            this.异常监控停止服务定时器timer1.Tick += new System.EventHandler(this.异常监控停止服务定时器timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.通用ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 25);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 通用ToolStripMenuItem
            // 
            this.通用ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.通用ToolStripMenuItem.Name = "通用ToolStripMenuItem";
            this.通用ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.通用ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.通用ToolStripMenuItem.Text = "通用(T)";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(71, 21);
            this.toolStripStatusLabel1.Text = "               |";
            // 
            // 发送接收条数toolStripStatusLabel2
            // 
            this.发送接收条数toolStripStatusLabel2.AutoSize = false;
            this.发送接收条数toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.发送接收条数toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.发送接收条数toolStripStatusLabel2.Name = "发送接收条数toolStripStatusLabel2";
            this.发送接收条数toolStripStatusLabel2.Size = new System.Drawing.Size(150, 21);
            this.发送接收条数toolStripStatusLabel2.Text = "发送/接收：0/0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(11, 21);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // 接收字节toolStripStatusLabel4
            // 
            this.接收字节toolStripStatusLabel4.AutoSize = false;
            this.接收字节toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.接收字节toolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.接收字节toolStripStatusLabel4.Name = "接收字节toolStripStatusLabel4";
            this.接收字节toolStripStatusLabel4.Size = new System.Drawing.Size(110, 21);
            this.接收字节toolStripStatusLabel4.Text = "接收字节：0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(11, 21);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // 发送字节toolStripStatusLabel6
            // 
            this.发送字节toolStripStatusLabel6.AutoSize = false;
            this.发送字节toolStripStatusLabel6.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.发送字节toolStripStatusLabel6.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.发送字节toolStripStatusLabel6.Name = "发送字节toolStripStatusLabel6";
            this.发送字节toolStripStatusLabel6.Size = new System.Drawing.Size(110, 21);
            this.发送字节toolStripStatusLabel6.Text = "发送字节：0";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(11, 21);
            this.toolStripSplitButton1.Text = "|";
            // 
            // 底部状态条statusStrip1
            // 
            this.底部状态条statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.发送接收条数toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.接收字节toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.发送字节toolStripStatusLabel6,
            this.toolStripSplitButton1,
            this.复位计数toolStripStatusLabel7});
            this.底部状态条statusStrip1.Location = new System.Drawing.Point(0, 503);
            this.底部状态条statusStrip1.Name = "底部状态条statusStrip1";
            this.底部状态条statusStrip1.Size = new System.Drawing.Size(684, 26);
            this.底部状态条statusStrip1.TabIndex = 25;
            this.底部状态条statusStrip1.Text = "statusStrip1";
            // 
            // 复位计数toolStripStatusLabel7
            // 
            this.复位计数toolStripStatusLabel7.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.复位计数toolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.复位计数toolStripStatusLabel7.Name = "复位计数toolStripStatusLabel7";
            this.复位计数toolStripStatusLabel7.Size = new System.Drawing.Size(60, 21);
            this.复位计数toolStripStatusLabel7.Text = "复位计数";
            this.复位计数toolStripStatusLabel7.Click += new System.EventHandler(this.复位计数toolStripStatusLabel7_Click);
            // 
            // 主界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 529);
            this.Controls.Add(this.发送设置groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.接收设置groupBox4);
            this.Controls.Add(this.填充用groupBox3);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.底部状态条statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "主界面";
            this.Text = "RTOS通信上位机";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.主界面_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.主界面_FormClosed);
            this.Load += new System.EventHandler(this.主界面_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.发送设置groupBox2.ResumeLayout(false);
            this.发送设置groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.周期发送时间numericUpDown1)).EndInit();
            this.接收设置groupBox4.ResumeLayout(false);
            this.接收设置groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.底部状态条statusStrip1.ResumeLayout(false);
            this.底部状态条statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button 打开button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox 本地端口comboBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox 本地IPcomboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox 协议类型comboBox1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox 数据日志richTextBox1;
        private System.Windows.Forms.GroupBox 发送设置groupBox2;
        private System.Windows.Forms.GroupBox 填充用groupBox3;
        private System.Windows.Forms.GroupBox 接收设置groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox RTOS端口comboBox1;
        private System.Windows.Forms.ComboBox RTOS_IPcomboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox 发送区textBox1;
        private System.Windows.Forms.Button 发送button1;
        private System.Windows.Forms.RadioButton 发送十六进制radioButton1;
        private System.Windows.Forms.RadioButton 发送ASCII码radioButton1;
        private System.Windows.Forms.RadioButton 接收十六进制radioButton1;
        private System.Windows.Forms.RadioButton 接收ASCII码radioButton2;
        private System.Windows.Forms.Button 接收区清空button1;
        private System.Windows.Forms.Button 发送区清空button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox 发送循环周期checkBox1;
        private System.Windows.Forms.NumericUpDown 周期发送时间numericUpDown1;
        private System.Windows.Forms.Timer 发送定时器timer1;
        private System.Windows.Forms.Timer 异常监控停止服务定时器timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 通用ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel 发送接收条数toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel 接收字节toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel 发送字节toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.StatusStrip 底部状态条statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel 复位计数toolStripStatusLabel7;
    }
}

