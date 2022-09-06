using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using RTOS通信上位机.UDP类文件;
using RTOS通信上位机.文本操作文件;
using RTOS通信上位机.TCP类文件;
using System.Net.Sockets;
using System.Net;
using RTOS通信上位机.调用窗体;




namespace RTOS通信上位机
{
    public partial class 主界面 : Form
    {
        public 主界面()
        {
            InitializeComponent();
        }



        #region 全局变量
      
        UDP通信类 UDP通信类实例化1 = new UDP通信类();
        TCP通信类 TCP通信类实例化1 = new TCP通信类();
        private Thread G_thr_UDP接收线程1;
        private Thread G_thr_UDP运行线程1;
        private Thread G_thr_UDP发送线程1;
        private delegate void F委托调用控件();//声明委托,代理
        string G_str_UPD接收的消息 = "";
        string G_str_UPD发送的消息 = "";
        string G_str_发送成功的消息 = "";
        string G_str_本地IP = string.Empty;
        int G_int_本地主机端口 = 1234;
        string G_str_远程IP = "192.168.123.30";
        int G_int_远程主机端口 = 8000;
        bool G_bl_接收报文格式 = true;//true:ACSII ;false: 十六进制
        bool G_bl_发送报文格式 = true;//true:ACSII ;false: 十六进制
        int G_int_启动协议 = 0; //0：停止所有；10：UDP,20:TCP客户端；30:TCP服务端
        文本操作类 文本操作类实例化1 = new 文本操作类();
        int G_int_启动发送 = 0;//0:没有发送；1：启动发送
        int G_int_异常关闭服务 = 0; //0:没有异常；1：通信异常，关闭通信服务
        F_关于 F_关于实例化1 = new F_关于();  //创建关于的子窗体
        int G_int_发送条数 = 0;
        int G_int_接收条数 = 0;
        int G_int_发送字节数 = 0;
        int G_int_接收字节数 = 0;


        #endregion


        #region 窗体自身事件汇总


        #region 窗体初始化事件

        private void 主界面_Load(object sender, EventArgs e)
        {


           
            this.F获取本地IP地址();
            本地IPcomboBox2.SelectedIndex = 0;
            G_str_本地IP =本地IPcomboBox2.Text;
            本地端口comboBox3.Text = G_int_本地主机端口.ToString();
            RTOS_IPcomboBox2.Text = G_str_远程IP;
            RTOS端口comboBox1.Text = G_int_远程主机端口.ToString();

            发送ASCII码radioButton1.Checked = true; //默认是发送ASCII码格式
            接收ASCII码radioButton2.Checked = true;//默认是接收ASCII码格式
            协议类型comboBox1.SelectedIndex = 0; //默认为UDP，0：UDP,1:TCP客户端；2:TCP服务端
            //*****以下是创建与启动线程
             G_thr_UDP接收线程1 = new Thread(new ThreadStart(F_通信委托窗体控件刷新线程方法));  //创建UDP监听线程
            G_thr_UDP接收线程1.IsBackground = true;
            G_thr_UDP接收线程1.Start();
            G_thr_UDP运行线程1 = new Thread(new ThreadStart(F_通信接收线程方法));
            G_thr_UDP运行线程1.IsBackground = true;
            G_thr_UDP运行线程1.Start();
            G_thr_UDP发送线程1 = new Thread(new ThreadStart(F_通信发送线程方法));
            G_thr_UDP发送线程1.IsBackground = true;
            G_thr_UDP发送线程1.Start();
        }
        #endregion

        #region 窗体关闭前触发事件
        private void 主界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult P_dr_窗体对话框结果 = MessageBox.Show("是否退出系统？", "退出系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (P_dr_窗体对话框结果 == DialogResult.Yes)
            {
                e.Cancel = false;   //关闭窗体


            }
            else
            {

                e.Cancel = true;  //取消关闭

            }


        }
        #endregion

        #region 窗体关闭后触发事件
        private void 主界面_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 关闭窗体前，关闭通信服务
            if (打开button1.Text == "关闭")
            {
                this.打开button1_Click(sender, e);
            }

            //终止线程
            G_thr_UDP接收线程1.Abort();
            G_thr_UDP运行线程1.Abort();
            G_thr_UDP发送线程1.Abort();

        }
        #endregion


        #endregion



        #region  自定义方法






        /// <summary>
        /// 运行线程委托的方法
        /// </summary>
        private void F_通信委托窗体控件刷新线程方法()
        {


            
            while (true)
            {
                //将sleep和无限循环放在等待异步的外面
               Thread.Sleep(10); // 在死循环中一定要然线程休眠，不然电脑CPU占用率很高，会造成电脑系统卡死
                F线程委托方法();
               
            }
        }


        /// <summary>
        /// 线程委托可以操作窗体控件
        /// </summary>
        private void F线程委托方法()
        {


            #region 调用--》数据日志richTextBox1
            if (this.数据日志richTextBox1.InvokeRequired)//等待异步
            {
                F委托调用控件 fc = new F委托调用控件(F线程委托方法);
                this.Invoke(fc);//通过代理调用刷新方法
            }
            else
            {



                #region  通信消息接收与发送输出

               
                if (G_int_启动协议 > 0)
                {
                    //消息接收输出
                    if (G_str_UPD接收的消息 != string.Empty)
                    {

                        this.数据日志richTextBox1.SelectionColor = Color.Blue;
                        this.F数据日志输出刷新(G_str_UPD接收的消息);
                        G_str_UPD接收的消息 = string.Empty;
                        G_int_接收条数++;

                    }
                    //消息发送成功的输出
                    if (G_str_发送成功的消息 != string.Empty)
                    {
                        this.数据日志richTextBox1.SelectionColor = Color.Black;
                        this.F数据日志输出刷新(G_str_发送成功的消息);
                        G_str_发送成功的消息 = string.Empty;
                        G_int_发送条数++;
                    }


                }
                else
                {
                    G_str_UPD接收的消息 = string.Empty;
                    G_str_发送成功的消息 = string.Empty;

                }

                #endregion


                #region  发送与接收统计数

                发送接收条数toolStripStatusLabel2.Text = "发送/接收：" + G_int_发送条数.ToString() + "/" + G_int_接收条数.ToString();
                发送字节toolStripStatusLabel6 .Text = "发送字节:" + G_int_发送字节数.ToString();
                接收字节toolStripStatusLabel4.Text = "接收字节:" + G_int_接收字节数.ToString();

                #endregion




            }

            #endregion


           



        }

        /// <summary>
        /// UPD接听线程方法
        /// </summary>
        private void F_通信接收线程方法()
        {
            while (true )
            {
                Thread.Sleep(10); // 在死循环中一定要然线程休眠，不然电脑CPU占用率很高，会造成电脑系统卡死
                try
                {

                    #region  UDP监听接收消息
                    if (G_int_启动协议 == 10 )
                    {
                        
                        UDP通信类实例化1.F_UDP监听消息(G_str_本地IP, G_int_本地主机端口, ref G_str_UPD接收的消息,ref G_int_接收字节数, ref G_bl_接收报文格式,ref G_int_启动协议);
                       

                    }


                    #endregion

                    #region  TCP客户端监听接收消息

                    if (G_int_启动协议 == 20)
                    {
                         
                            TCP通信类实例化1.TCP客户端接收消息(G_str_本地IP, G_int_本地主机端口, G_str_远程IP, G_int_远程主机端口,ref G_str_UPD接收的消息, ref G_int_接收字节数, ref G_bl_接收报文格式,ref G_int_启动协议);

                   

                    }


                    #endregion

                    #region TCP服务端监听消息
                    if (G_int_启动协议 == 30)
                    {

                       
                        TCP通信类实例化1.TCP服务端接收消息(G_str_本地IP, G_int_本地主机端口, ref G_str_UPD接收的消息, ref G_int_接收字节数, ref G_bl_接收报文格式, ref G_int_启动协议);

                       

                    }


                    #endregion


                }
                catch (Exception ex1)
                {
                    G_int_异常关闭服务 = 1;
                    MessageBox.Show(ex1.Message);
                }
            }
        }


        private void F_通信发送线程方法()
        {
            while (true)
             {
                Thread.Sleep(10); // 在死循环中一定要然线程休眠，不然电脑CPU占用率很高，会造成电脑系统卡死
                try
                {

                    #region UDP发送消息
                    if (G_int_启动协议==10 && G_int_启动发送 ==1&& G_str_发送成功的消息==string.Empty)
                {
                  

                    //G_str_发送成功的消息 =
                    //    UDP通信类实例化1.F_UDP发送消息( G_str_远程IP, G_int_远程主机端口, G_str_UPD发送的消息, G_bl_发送报文格式);
                    G_str_发送成功的消息 =
                       UDP通信类实例化1.F_UDP发送消息(G_str_本地IP, G_int_本地主机端口, G_str_远程IP, G_int_远程主机端口, G_str_UPD发送的消息,ref G_int_发送字节数, G_bl_发送报文格式);

                    G_int_启动发送 = 0;
                    
                }

                #endregion

                #region TCP客户端发送消息
                if (G_int_启动协议 == 20 && G_int_启动发送 == 1)
                {
                   
                    TCP通信类实例化1.TCP客户端发送消息(G_str_远程IP, G_int_远程主机端口, G_str_UPD发送的消息,ref G_str_发送成功的消息, ref G_int_发送字节数, G_bl_发送报文格式);
                    G_int_启动发送 = 0;

                }
                #endregion

                #region TCP服务端发送消息
                if (G_int_启动协议 == 30 && G_int_启动发送 == 1)
                {

                    
                    TCP通信类实例化1.TCP服务端发送消息(G_str_UPD发送的消息, ref G_str_发送成功的消息, ref G_int_发送字节数, G_bl_发送报文格式);
                    G_int_启动发送 = 0;

                }

                    #endregion

                }
                catch (Exception ex1)
                {
                    G_int_异常关闭服务 = 1;
                    MessageBox.Show(ex1.Message);
                }

            }



        }


        private void F数据日志输出刷新(string M_str_输出内容)
        {


            //this.数据日志richTextBox1.Text = this.数据日志richTextBox1.Text + M_str_输出内容;  //不能用叠加的方式输出richTextBox
            this.数据日志richTextBox1.AppendText(M_str_输出内容);
            this.数据日志richTextBox1.SelectionStart = this.数据日志richTextBox1.TextLength;
                this.数据日志richTextBox1.ScrollToCaret(); //让richTextBox控件的滚动条跟随数据向下移动
                文本操作类实例化1.F运行日志输出(M_str_输出内容);
               


            


        }

        
        /// <summary>
        /// 获取本地IP地址
        /// </summary>
        public void F获取本地IP地址()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    本地IPcomboBox2.Items.Add(ip.ToString());
                  
                }
                                
            }

        }


        #endregion


        #region 窗体控件触发事件
        private void 打开button1_Click(object sender, EventArgs e)
        {

            try
            {
                #region 打开通信服务
                if (打开button1.Text=="打开")
                {
                    打开button1.Text = "关闭";
                    协议类型comboBox1.Enabled = false;
                    本地IPcomboBox2.Enabled = false;
                    本地端口comboBox3.Enabled = false;
                    异常监控停止服务定时器timer1.Interval = 1000;
                    异常监控停止服务定时器timer1.Enabled = true;
                    if (协议类型comboBox1.SelectedIndex == 0)  //UDP
                    { G_int_启动协议 = 10; } 
                    if (协议类型comboBox1.SelectedIndex == 1) // TCP客户端
                    {
                        G_int_启动协议 = 20;
                        RTOS_IPcomboBox2.Enabled = false;
                        RTOS端口comboBox1.Enabled = false;
                    }
                    if (协议类型comboBox1.SelectedIndex == 2) // TCP服务端
                    { G_int_启动协议 = 30; }

                }
                #endregion

                #region 关闭通信服务
                else
                {
                    #region 停止发送数据
                    if (this.发送button1.Text == "停止发送")
                    {
                        this.发送button1_Click(sender, e);

                    }


                    #endregion
                    
                    打开button1.Text = "打开";
                    G_int_启动协议 = 0;
                    G_int_启动发送 = 0;
                    协议类型comboBox1.Enabled = true ;
                    本地IPcomboBox2.Enabled = true;
                    本地端口comboBox3.Enabled = true;
                    异常监控停止服务定时器timer1.Enabled = false ;
                    RTOS_IPcomboBox2.Enabled = true;
                    RTOS端口comboBox1.Enabled = true;


                    #region 关闭UDP端口
                    if (UDP通信类实例化1.P_udp_客户端实例1 != null)
                    {
                        UDP通信类实例化1.P_int_UDP客户端连接状态 = 0;
                        UDP通信类实例化1.P_udp_客户端实例1.Close();
                        



                    }
                    #endregion

                    #region 关闭TCP客户端
                    if (TCP通信类实例化1.TCP_客户端 != null)
                    {
                        
                        TCP通信类实例化1.TCP_客户端.Close();
                    }
                    #endregion

                    #region 关闭TCP服务端
                    if (TCP通信类实例化1.P_TCP服务端 != null)
                    {
                        
                        TCP通信类实例化1.P_TCP服务端.Stop();
                        if (TCP通信类实例化1.P_接入服务端的TCP客户端 != null)
                        {
                           TCP通信类实例化1.P_接入服务端的TCP客户端.Close();

                        }
                    }
                    #endregion

                }

                #endregion


            }
            catch (Exception  ex1)
            {
                MessageBox.Show(ex1.Message);
            }


        }

        private void 接收ASCII码radioButton2_Click(object sender, EventArgs e)
        {

            if (接收ASCII码radioButton2.Checked)
            {
                G_bl_接收报文格式 = true;
                

            }
            
        }

        private void 接收十六进制radioButton1_Click(object sender, EventArgs e)
        {
            if (接收十六进制radioButton1.Checked)
            {
                G_bl_接收报文格式 = false;
                
            }
        }
        private void 本地端口comboBox3_TextChanged(object sender, EventArgs e)
        {
            G_int_本地主机端口 = Convert.ToInt32(本地端口comboBox3.Text);
            
        }


        private void 发送区清空button1_Click(object sender, EventArgs e)
        {
            发送区textBox1.Text = "";
        }

        private void 接收区清空button1_Click(object sender, EventArgs e)
        {
            数据日志richTextBox1.Text = "";
        }
        private void 发送button1_Click(object sender, EventArgs e)
        {

            #region 满足发送条件,允许发送数据

            if (打开button1.Text=="关闭" && 发送区textBox1.Text !="")
            {
                G_int_启动发送 = 1;

                if (发送循环周期checkBox1.Checked)
                {
                    if (发送button1.Text=="发送")
                    {
                        发送button1.Text = "停止发送";
                        发送设置groupBox2.Enabled = false;
                        发送区textBox1.Enabled = false;
                        RTOS_IPcomboBox2.Enabled = false;
                        RTOS端口comboBox1.Enabled = false;
                        发送定时器timer1.Interval = (int)周期发送时间numericUpDown1.Value;
                        发送定时器timer1.Enabled = true;
                        发送区清空button1.Enabled = false;


                    }
                    else
                    {
                        发送button1.Text = "发送";
                        发送设置groupBox2.Enabled = true ;
                        发送区textBox1.Enabled = true;
                        RTOS_IPcomboBox2.Enabled = true;
                        RTOS端口comboBox1.Enabled = true;
                        发送定时器timer1.Enabled = false;
                        发送区清空button1.Enabled = true;
                    }


                }

                
            }
            #endregion

            #region 不满足发送条件,弹出报警提示

            if (打开button1.Text != "关闭")
            {
                MessageBox.Show("网络还没有连接，发送失败！");
            }

            if (发送区textBox1.Text == "")
            {
                MessageBox.Show("发送数据不能为空！");

            }
            #endregion

        }


        private void 本地IPcomboBox2_TextChanged(object sender, EventArgs e)
        {
              G_str_本地IP= 本地IPcomboBox2.Text;
        }

        private void RTOS_IPcomboBox2_TextChanged(object sender, EventArgs e)
        {
            G_str_远程IP=RTOS_IPcomboBox2.Text ;
        }
        private void RTOS端口comboBox1_TextChanged(object sender, EventArgs e)
        {
            G_int_远程主机端口=Convert.ToInt32(RTOS端口comboBox1.Text); ;
        }

        private void 发送区textBox1_TextChanged(object sender, EventArgs e)
        {
            G_str_UPD发送的消息 = 发送区textBox1.Text;

        }

        //KeyPress 事件不能由非字符键引发；但是非字符键能够引发 KeyDown 和 KeyUp 事件。
        
        private void 发送区textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (发送十六进制radioButton1.Checked) //如果发送十六进制被选中，只能输入空格和十六进制数
            {
               
                //  e.Handled 的设置值为true时，不允许输入
                e.Handled = !(("0123456789ABCDEF ".IndexOf(char.ToUpper(e.KeyChar)) >= 0) || e.KeyChar == '\b');
               
            }
        }

        
        private void 发送ASCII码radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(发送ASCII码radioButton1.Checked)
            {
            发送区textBox1.Text=UDP通信类实例化1.F十六进制字符串转国标字符串(发送区textBox1.Text);
                G_bl_发送报文格式 = true;
            }
        }


        private void 发送十六进制radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (发送十六进制radioButton1.Checked)
            {
                发送区textBox1.Text = UDP通信类实例化1.F国标字符串转十六进制字符串(发送区textBox1.Text);
                G_bl_发送报文格式 = false;
            }
        }


        private void 发送循环周期checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (发送循环周期checkBox1.Checked)
            {
                周期发送时间numericUpDown1.Enabled = false;
            }
            else
            {
                周期发送时间numericUpDown1.Enabled = true;

            }


        }
        private void 发送定时器timer1_Tick(object sender, EventArgs e)
        {
            if (G_int_启动发送 == 0)
            {
                G_int_启动发送 = 1;
            }
            

        }

        private void 异常监控停止服务定时器timer1_Tick(object sender, EventArgs e)
        {
            if (G_int_异常关闭服务 == 1)
            {
                G_int_异常关闭服务 = 0;
                if (this.打开button1.Text=="关闭")
                {
                    this.打开button1_Click(sender, e);
                }
               
            }

        }

        #region 菜单控件
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //C#避免重复打开一个窗体
            if (F_关于实例化1.IsDisposed)
            {
                F_关于实例化1 = new F_关于();
                F_关于实例化1.Show();
            }
            else
            {
                F_关于实例化1.Show();
            }
            

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //退出窗体
            Application.Exit();
        }
        #endregion

        #region 底部状态条
        private void 复位计数toolStripStatusLabel7_Click(object sender, EventArgs e)
        {
             G_int_发送条数 = 0;
             G_int_接收条数 = 0;
             G_int_发送字节数 = 0;
             G_int_接收字节数 = 0;
        }

        #endregion
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {


          

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        
    }
}
