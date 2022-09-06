using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;



namespace RTOS通信上位机.UDP类文件
{
    class UDP通信类
    {


        #region 全局变量

        public UdpClient P_udp_客户端实例1;
        public int P_int_UDP客户端连接状态 = 0; //0:没有建立连接；1：已经建立连接

        #endregion


        /// <summary>
        /// 返回值单路广播UDP监听消息,方法1
        /// </summary>
        /// <param name="M_int_本地端口">监听的端口号</param>
        /// <param name="M_bl_输出格式">true：ASCII码输出；false:十六进制输出</param>
        /// <returns></returns>
        public String F_UDP监听消息(string M_str_本地IP, int M_int_本地端口,bool M_bl_输出格式)
        {
            String M_str_接收消息输出="";
             string  M_str_接收直接数据 = "";
            string M_str_报文格式标识 = "";

            

                // P_udp_客户端实例1 = new UdpClient(M_int_本地端口);
                // P_udp_客户端实例1 = new UdpClient(M_int_本地端口, AddressFamily.InterNetwork);

                P_udp_客户端实例1 = new UdpClient(new IPEndPoint(IPAddress.Parse(M_str_本地IP), M_int_本地端口));
                // P_udp_客户端实例1 = new UdpClient(new IPEndPoint(IPAddress.Parse("192.168.123.30"), M_int_本地端口));
                //设置远程主机，(IPAddress.Any, 0)代表接收所有IP所有端口发送的数据
                IPEndPoint P_ipe_远程网络IP设备 = new IPEndPoint(IPAddress.Any, 0);
            
            


            try
            { 
            Byte[] P_bts_接收数据流 = P_udp_客户端实例1.Receive(ref P_ipe_远程网络IP设备);
                if (M_bl_输出格式)
                {
                    // M_str_接收直接数据 = Encoding.ASCII.GetString(P_bts_接收数据流);
                    M_str_接收直接数据 = Encoding.GetEncoding("gb2312").GetString(P_bts_接收数据流);
                    M_str_报文格式标识 = "ASCII码";
                }
                else
                {
                    M_str_接收直接数据 = this.F字节型转换成十六进制字符串(P_bts_接收数据流);
                    M_str_报文格式标识 = "十六进制码";
                }

                M_str_接收消息输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+ "]" + "接收"+ M_str_报文格式标识  + "来自" 
                    + P_ipe_远程网络IP设备.Address.ToString()+":"+ P_ipe_远程网络IP设备.Port.ToString() + ">\n"
                    + M_str_接收直接数据 + "\n" + "\n";
               P_udp_客户端实例1.Close();
            }
            catch
            {
            P_udp_客户端实例1.Close();
              
            }


            return M_str_接收消息输出;
            

            
            
        }




        /// <summary>
        /// 实参替代形参的输出监听消息，方法2
        /// </summary>
        /// <param name="M_str_本地IP"></param>
        /// <param name="M_int_本地端口"></param>
        /// <param name="M_str_接收消息输出"></param>
        /// <param name="M_bl_输出格式"></param>
        /// <param name="M_int_启用"></param>
        public void F_UDP监听消息(string M_str_本地IP, int M_int_本地端口,ref String M_str_接收消息输出,ref int M_int_接收字节数, ref bool M_bl_输出格式,ref int M_int_启用)
        {
            
            string M_str_接收直接数据 = "";
            string M_str_报文格式标识 = "";
            P_udp_客户端实例1 = new UdpClient(new IPEndPoint(IPAddress.Parse(M_str_本地IP), M_int_本地端口));
           
            IPEndPoint P_ipe_远程网络IP设备 = new IPEndPoint(IPAddress.Any, 0);
            P_int_UDP客户端连接状态 = 1;
            try
            {

                 while (M_int_启用>0)
                {

                    Thread.Sleep(10); // 在死循环中一定要然线程休眠，不然电脑CPU占用率很高，会造成电脑系统卡死
                    if(M_str_接收消息输出 == string.Empty)
                    { 
                    M_str_接收直接数据 = "";
                    M_str_报文格式标识 = "";
                    Byte[] P_bts_接收数据流 = P_udp_客户端实例1.Receive(ref P_ipe_远程网络IP设备);
                        if (M_bl_输出格式)
                        {
                            // M_str_接收直接数据 = Encoding.ASCII.GetString(P_bts_接收数据流);
                            M_str_接收直接数据 = Encoding.GetEncoding("gb2312").GetString(P_bts_接收数据流);
                            M_str_报文格式标识 = "ASCII码";
                        }
                        else
                        {
                            M_str_接收直接数据 = this.F字节型转换成十六进制字符串(P_bts_接收数据流);
                            M_str_报文格式标识 = "十六进制码";
                        }

                        M_str_接收消息输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "接收" + M_str_报文格式标识 + "来自"
                            + P_ipe_远程网络IP设备.Address.ToString() + ":" + P_ipe_远程网络IP设备.Port.ToString() + ">\n"
                            + M_str_接收直接数据 + "\n" + "\n";
                        M_int_接收字节数 = M_int_接收字节数 + P_bts_接收数据流.Length;
                    }

                }
                P_int_UDP客户端连接状态 = 0;
                P_udp_客户端实例1.Close();
                

            }
            catch
            {
                P_int_UDP客户端连接状态 = 0;
                P_udp_客户端实例1.Close();
                

            }


           




        }




        /// <summary>
        /// UDP发送消息，方法1，与监听消息方法1配合用
        /// </summary>
        /// <param name="M_str_本地IP"></param>
        /// <param name="M_int_本地端口"></param>
        /// <param name="M_str_远程IP"></param>
        /// <param name="M_int_RTOS端口"></param>
        /// <param name="M_str_发送内容"></param>
        /// <param name="M_bl_发送格式"></param>
        /// <returns></returns>
        public string F_UDP发送消息(string M_str_本地IP, int M_int_本地端口, string M_str_远程IP, int M_int_RTOS端口,string M_str_发送内容,ref int M_int_发送成功字节, bool M_bl_发送格式)
        {

            UdpClient P_udp_发送端 = new UdpClient(M_int_本地端口, AddressFamily.InterNetwork);
            
            int P_int_发送成功标志 = 0; //大于0就是发送成功的了。
            String M_str_发送消息输出 = "";
            Byte[] P_bts_发送数据流;
            string M_str_报文格式标识 = "";
            if (M_bl_发送格式) //M_bl_发送格式 true:为ASCII码；false:为十六进制码
            {
                
                P_bts_发送数据流 = this.F国标字符串转字节型(M_str_发送内容);
                M_str_报文格式标识 = "ASCII码";
            }
            else
            {
                P_bts_发送数据流 = this.F十六进制字符串转成字节型(M_str_发送内容);
                M_str_报文格式标识 = "十六进制码";
            }

           // Byte[] P_bts_发送数据流 = Encoding.ASCII.GetBytes("Is anybody there");

            P_int_发送成功标志= P_udp_发送端.Send(P_bts_发送数据流, P_bts_发送数据流.Length, M_str_远程IP, M_int_RTOS端口);
            if (P_int_发送成功标志>0)
            {
                M_str_发送消息输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "发送" + M_str_报文格式标识 + "去往"
                    + M_str_远程IP + ":" + M_int_RTOS端口.ToString() + ">\n"
                    + M_str_发送内容 + "\n" + "\n";
                M_int_发送成功字节 = M_int_发送成功字节 + P_int_发送成功标志;
            }
            P_udp_发送端.Close();

            return M_str_发送消息输出;

        }


        /// <summary>
        /// UDP发送消息，方法2，与监听消息方法2配合用
        /// </summary>
        /// <param name="M_str_远程IP"></param>
        /// <param name="M_int_RTOS端口"></param>
        /// <param name="M_str_发送内容"></param>
        /// <param name="M_bl_发送格式"></param>
        /// <returns></returns>
        public string F_UDP发送消息( string M_str_远程IP, int M_int_RTOS端口, string M_str_发送内容, bool M_bl_发送格式)
        {

            

            int P_int_发送成功标志 = 0; //大于0就是发送成功的了。
            String M_str_发送消息输出 = "";
            Byte[] P_bts_发送数据流;
            string M_str_报文格式标识 = "";
            if (M_bl_发送格式) //M_bl_发送格式 true:为ASCII码；false:为十六进制码
            {

                P_bts_发送数据流 = this.F国标字符串转字节型(M_str_发送内容);
                M_str_报文格式标识 = "ASCII码";
            }
            else
            {
                P_bts_发送数据流 = this.F十六进制字符串转成字节型(M_str_发送内容);
                M_str_报文格式标识 = "十六进制码";
            }


            if (P_int_UDP客户端连接状态 ==1 && P_udp_客户端实例1 != null)
            {
                P_int_发送成功标志 = P_udp_客户端实例1.Send(P_bts_发送数据流, P_bts_发送数据流.Length, M_str_远程IP, M_int_RTOS端口);
            }

                if (P_int_发送成功标志 > 0)
            {
                M_str_发送消息输出 = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]" + "发送" + M_str_报文格式标识 + "去往"
                    + M_str_远程IP + ":" + M_int_RTOS端口.ToString() + ">\n"
                    + M_str_发送内容 + "\n" + "\n";
            }
           

            return M_str_发送消息输出;

        }






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
        public string ByteToString(byte[] InBytes, int len)
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
        /// <returns></returns>
        public string F字节型转国标字符串(byte[] M_by_数据流)
        {
            string P_str_转换后的字符输出 = "";
             P_str_转换后的字符输出 = Encoding.GetEncoding("gb2312").GetString(M_by_数据流);

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
        public  string F十六进制字符串转国标字符串(string M_str_十六进制字符串)
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





    }
}
