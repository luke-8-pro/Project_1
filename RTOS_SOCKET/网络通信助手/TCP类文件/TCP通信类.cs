using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;





namespace RTOS通信上位机.TCP类文件
{
    class TCP通信类
    {

        #region 全局变量

        #region TCP客户端使用的全局变量
        IPAddress P_服务端IP;
       public  TcpClient TCP_客户端;
       public  NetworkStream P_客户端NWS_网络数据流;


        #endregion

        #region TCP服务端使用的全局变量
       public  TcpListener P_TCP服务端 ;
        public TcpClient P_接入服务端的TCP客户端;
        NetworkStream P_服务端NWS_网络数据流;
        #endregion

        #endregion




        #region TCP客户端

        #region TCP客户端接收消息
        public void TCP客户端接收消息(string M_str_本地客户端IP,int M_str_本地客户端口,
            string M_str_服务端IP,int M_str_服务端端口, ref string M_str_接收消息输出, ref int M_int_接收字节数, ref bool M_bl_接收数据格式,ref int M_int_启用)
        {
            
            P_服务端IP = IPAddress.Parse(M_str_服务端IP);
               // TCP_客户端 = new TcpClient(new IPEndPoint(IPAddress.Parse(M_str_本地客户端IP), M_str_本地客户端口));
               TCP_客户端 = new TcpClient();
               
              TCP_客户端.Connect(P_服务端IP, M_str_服务端端口);//必须与服务端给定的端口号一致
                string M_str_接收直接数据;
                // 连接后，客户端要发送数据给服务端 要发送和接收数据，
                // 请使用 GetStream 方法来获取一个 NetworkStream。 
                //调用 NetworkStream 的 Write 和 Read 方法与远程主机之间发送和接收数据。
                P_客户端NWS_网络数据流 = TCP_客户端.GetStream();
            try
            {
                while (M_int_启用 > 0 )
                {
                    Thread.Sleep(10); // 在死循环中一定要然线程休眠，不然电脑CPU占用率很高，会造成电脑系统卡死
                    if (M_str_接收消息输出 == "")
                    {
                        Byte[] P_bts_接收数据流 = new Byte[8192];
                        int P_int_接收字节数 = 0;
                        P_int_接收字节数 = P_客户端NWS_网络数据流.Read(P_bts_接收数据流, 0, P_bts_接收数据流.Length);
                        if (P_int_接收字节数 == 0) { break; }  //当收到服务端断开时推出循环体
                        M_int_接收字节数 = M_int_接收字节数 + P_int_接收字节数;
                        string M_str_报文格式标识 = "";
                        if (M_bl_接收数据格式)
                        {

                            M_str_接收直接数据 = this.F字节型转国标字符串(P_bts_接收数据流, 0, P_int_接收字节数);
                            M_str_报文格式标识 = "ASCII码";
                        }
                        else
                        {
                            M_str_接收直接数据 = this.F字节型转换成十六进制字符串(P_bts_接收数据流, P_int_接收字节数);
                            M_str_报文格式标识 = "十六进制码";
                        }

                        M_str_接收消息输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + M_str_报文格式标识 + "来自"
                            + M_str_服务端IP + ":" + M_str_服务端端口.ToString() + ">\n"
                            + M_str_接收直接数据 + "\n" + "\n";
                    }
                }

                TCP_客户端.Close();
                P_客户端NWS_网络数据流.Close();
            }
            catch
            {
                TCP_客户端.Close();
                P_客户端NWS_网络数据流.Close();
            }

        }
        #endregion

        #region TCP客户端发送消息
       public void TCP客户端发送消息(string M_str_服务端IP, int M_str_服务端端口, string M_str_发送内容, ref string M_str_发送内容输出, ref int M_int_发送成功字节, bool M_bl_发送数据格式)
        {

            if (M_str_发送内容输出 ==string .Empty)
            { 
            Byte[] P_bts_发送数据流;
            string M_str_发送报文格式标识 = "";
            if (M_bl_发送数据格式) //M_bl_发送格式 true:为ASCII码；false:为十六进制码
            {

                P_bts_发送数据流 = this.F国标字符串转字节型(M_str_发送内容);
                M_str_发送报文格式标识 = "ASCII码";
            }
            else
            {
                P_bts_发送数据流 = this.F十六进制字符串转成字节型(M_str_发送内容);
                M_str_发送报文格式标识 = "十六进制码";
            }


            P_客户端NWS_网络数据流.Write(P_bts_发送数据流, 0, P_bts_发送数据流.Length);

            M_str_发送内容输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "发送" + M_str_发送报文格式标识 + "去往"
                    + M_str_服务端IP + ":" + M_str_服务端端口.ToString() + ">\n"
                    + M_str_发送内容 + "\n" + "\n";
                M_int_发送成功字节 = M_int_发送成功字节 + P_bts_发送数据流.Length;
            }

        }
        #endregion


        #endregion




        #region TCP服务端

        #region TCP服务端接收消息
        public void TCP服务端接收消息(string M_str_本地服务端IP, int M_str_本地服务端端口, ref string M_str_接收消息输出, ref int M_int_接收字节数, ref bool M_bl_接收数据格式, ref int M_int_启用)
        {

            P_TCP服务端= new TcpListener(new IPEndPoint(IPAddress.Parse(M_str_本地服务端IP), M_str_本地服务端端口));
            P_TCP服务端.Start(); //开始监听客户端请求
            Byte[] P_bts_接收数据流 = new Byte[8192];
            string M_str_接收直接数据=string.Empty ;
            try
            {
             P_接入服务端的TCP客户端 = P_TCP服务端.AcceptTcpClient();
            
            P_服务端NWS_网络数据流 = P_接入服务端的TCP客户端.GetStream();

            M_str_接收消息输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + "来自"
                        + (P_接入服务端的TCP客户端.Client.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" +
                        (P_接入服务端的TCP客户端.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">"
                        + "有客户端请求连接，连接已建立！" + "\n" + "\n";
            

            
                while (M_int_启用 > 0 )
                {
                    Thread.Sleep(10); // 在死循环中一定要然线程休眠，不然电脑CPU占用率很高，会造成电脑系统卡死
                    if (M_str_接收消息输出 == string.Empty)
                    {
                        int P_int_接收字节数 = 0;
                        P_int_接收字节数 = P_服务端NWS_网络数据流.Read(P_bts_接收数据流, 0, P_bts_接收数据流.Length);
                        if (P_int_接收字节数 == 0)  //当收到服务端断开时推出循环体
                        {
                            M_str_接收消息输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + "来自"
                            + (P_接入服务端的TCP客户端.Client.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" +
                            (P_接入服务端的TCP客户端.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">"
                            + "客户端已退出连接！" + "\n" + "\n";
                            break;
                        }
                        M_int_接收字节数 = M_int_接收字节数 + P_int_接收字节数;
                        string M_str_报文格式标识 = "";
                        if (M_bl_接收数据格式)
                        {

                            M_str_接收直接数据 = this.F字节型转国标字符串(P_bts_接收数据流, 0, P_int_接收字节数);
                            M_str_报文格式标识 = "ASCII码";
                        }
                        else
                        {
                            M_str_接收直接数据 = this.F字节型转换成十六进制字符串(P_bts_接收数据流, P_int_接收字节数);
                            M_str_报文格式标识 = "十六进制码";
                        }
                        M_str_接收消息输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + M_str_报文格式标识 + "来自"
                        + (P_接入服务端的TCP客户端.Client.RemoteEndPoint as IPEndPoint).Address.ToString() + ":" +
                        (P_接入服务端的TCP客户端.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">\n"
                        + M_str_接收直接数据 + "\n" + "\n";
                    }

                }

                P_接入服务端的TCP客户端.Close();
                P_TCP服务端.Stop();
                P_服务端NWS_网络数据流.Close();
            }
            catch
            {
                if (P_接入服务端的TCP客户端 != null)
                { 
                P_接入服务端的TCP客户端.Close();
                }
                P_TCP服务端.Stop();
                if(P_服务端NWS_网络数据流 != null)
                { 
                P_服务端NWS_网络数据流.Close();
                }
            }

        }

        #endregion

        #region TCP服务端发送消息
        public void TCP服务端发送消息(string M_str_发送内容, ref string M_str_发送内容输出, ref int M_int_发送成功字节, bool M_bl_发送数据格式)
        {
            if (M_str_发送内容输出 == string.Empty)
            {
                Byte[] P_bts_发送数据流;
                string M_str_发送报文格式标识 = "";
                if (M_bl_发送数据格式) //M_bl_发送格式 true:为ASCII码；false:为十六进制码
                {

                    P_bts_发送数据流 = this.F国标字符串转字节型(M_str_发送内容);
                    M_str_发送报文格式标识 = "ASCII码";
                }
                else
                {
                    P_bts_发送数据流 = this.F十六进制字符串转成字节型(M_str_发送内容);
                    M_str_发送报文格式标识 = "十六进制码";
                }


                P_服务端NWS_网络数据流.Write(P_bts_发送数据流, 0, P_bts_发送数据流.Length);

                M_str_发送内容输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "发送" + M_str_发送报文格式标识 + "去往"
                        + (P_接入服务端的TCP客户端.Client.RemoteEndPoint as IPEndPoint).Address.ToString() 
                        + ":" + (P_接入服务端的TCP客户端.Client.RemoteEndPoint as IPEndPoint).Port.ToString() + ">\n"
                        + M_str_发送内容 + "\n" + "\n";
                M_int_发送成功字节 = M_int_发送成功字节 + P_bts_发送数据流.Length;

            }

        }

        #endregion

        #endregion



        #region  字符转换方法


        /// <summary>
        /// 把字节型转换成十六进制字符串
        /// </summary>
        /// <param name="InBytes"></param>
        /// <returns></returns>
        public string F字节型转换成十六进制字符串(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                StringOut = StringOut + String.Format("{0:X2} ", InByte);
            }
            return StringOut;
        }
        /// <summary>
        /// 把指定长度的字节型转换成十六进制字符串
        /// </summary>
        /// <param name="InBytes">要转换的字节数组流</param>
        /// <param name="len">字节数组流长度</param>
        /// <returns>十六进制字符串</returns>
        public string F字节型转换成十六进制字符串(byte[] InBytes, int len)
        {
            string StringOut = "";
            for (int i = 0; i < len; i++)
            {
                StringOut = StringOut + String.Format("{0:X2} ", InBytes[i]);
            }
            return StringOut;
        }

        /// <summary>
        /// 把十六进制字符串转换成字节型
        /// </summary>
        /// <param name="M_str_十六进制字符串">要转换的十六进制字符串</param>
        /// <returns></returns>
        public byte[] F十六进制字符串转成字节型(string M_str_十六进制字符串)
        {
            string P_str_去空格的字符串 = M_str_十六进制字符串.Replace(" ", "");
            string P_str_去空格凑偶数字符串 = "";

            if ((P_str_去空格的字符串.Length % 2) > 0)
            {
                P_str_去空格凑偶数字符串 = P_str_去空格的字符串.Insert(P_str_去空格的字符串.Length - 1, "0");
            }
            else
            {

                P_str_去空格凑偶数字符串 = P_str_去空格的字符串;
            }


            byte[] P_bt_字节流数组 = new byte[(int)P_str_去空格凑偶数字符串.Length / 2];
            for (int i = 0, j = 0; j <= P_str_去空格凑偶数字符串.Length - 2; j = j + 2, i++)
            {
                P_bt_字节流数组[i] = Convert.ToByte(P_str_去空格凑偶数字符串.Substring(j, 2), 16);

            }

            return P_bt_字节流数组;


        }

        
        /// <summary>
        /// 把字节型转为gb2312字符串
        /// </summary>
        /// <param name="M_by_数据流">要转换的字节数组流</param>
        /// <returns>国标字符串</returns>
        public string F字节型转国标字符串(byte[] M_by_数据流)
        {
            string P_str_转换后的字符输出 = "";
            P_str_转换后的字符输出 = Encoding.GetEncoding("gb2312").GetString(M_by_数据流);

            return P_str_转换后的字符输出;
        }


        /// <summary>
        /// 把指定长度的字节型转为gb2312字符串
        /// </summary>
        /// <param name="M_by_数据流">要转换的字节数组流</param>
        /// <param name="M_int_第一个要解码的字节的索引">第一个要解码的字节的索引</param>
        /// <param name="M_int_要解码的字节数">要解码的字节数</param>
        /// <returns>国标字符串</returns>
        public string F字节型转国标字符串(byte[] M_by_数据流,int M_int_第一个要解码的字节的索引,int M_int_要解码的字节数)
        {
            string P_str_转换后的字符输出 = "";
            P_str_转换后的字符输出 = Encoding.GetEncoding("gb2312").GetString(M_by_数据流, M_int_第一个要解码的字节的索引, M_int_要解码的字节数);

            return P_str_转换后的字符输出;
        }


        /// <summary>
        /// 把国标字符串转字节型
        /// </summary>
        /// <param name="M_str_国标字符串">要转换的国标字符串</param>
        /// <returns>字节型</returns>
        public byte[] F国标字符串转字节型(string M_str_国标字符串)
        {
            byte[] P_bt_字节流1 = Encoding.GetEncoding("gb2312").GetBytes(M_str_国标字符串);

            return P_bt_字节流1;
        }


        /// <summary>
        /// 把十六进制字符串转国标字符串
        /// </summary>
        /// <param name="M_str_十六进制字符串">要转换的十六进制字符串</param>
        /// <returns>返回国标字符串</returns>
        public string F十六进制字符串转国标字符串(string M_str_十六进制字符串)
        {

            string P_str_国标字符串 = "";
            P_str_国标字符串 = this.F字节型转国标字符串(this.F十六进制字符串转成字节型(M_str_十六进制字符串));

            return P_str_国标字符串;
        }


        /// <summary>
        /// 国标字符串转十六进制字符串
        /// </summary>
        /// <param name="M_str_国标字符串">国标字符串</param>
        /// <returns>十六进制字符串</returns>
        public string F国标字符串转十六进制字符串(string M_str_国标字符串)
        {

            string P_str_十六进制字符串 = this.F字节型转换成十六进制字符串(this.F国标字符串转字节型(M_str_国标字符串));

            return P_str_十六进制字符串;
        }


        #endregion




    }
}
