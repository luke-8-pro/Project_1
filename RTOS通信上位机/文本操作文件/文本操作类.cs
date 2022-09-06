using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RTOS通信上位机.文本操作文件
{
    
    class 文本操作类
    {

        #region  全局变量
        public static int G_int_日志文本个数 = 10; //默认10个
        public static string G_str_当前程序路径 = System.Windows.Forms.Application.StartupPath;
        public static string G_str_日志文件名 = "运行日志";
        public static string G_str_日志文件所在文件夹 = G_str_当前程序路径 + "\\" + G_str_日志文件名;
        public static string G_str_当前运行日志文本名称 = "当前运行日志.txt";
        public static string G_str_旧日志备份名称 = "旧日志备份";
        public static string G_str_文本格式 = ".txt";
        public static string G_str_旧日志备份1文本名称 = "旧日志备份1.txt";
        public static int G_str_日志文本指定容量MB = 1; //默认是1MB

        #endregion


        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="M_str_文本路径上级目录">文本所在的文件夹的路径</param>
        /// <param name="M_str_文本名称">文本名称与后缀名</param>
        public void F创建文本(string M_str_文本路径上级目录, string M_str_文本名称)
        {
            string P_str_文本名称与路径 = M_str_文本路径上级目录 + "\\" + M_str_文本名称;
            if (File.Exists(P_str_文本名称与路径) == false)
            {
                if (Directory.Exists(M_str_文本路径上级目录) == false)  //文件夹不存在就创建文件夹
                {
                    Directory.CreateDirectory(M_str_文本路径上级目录);

                }

                FileStream fs_文件流 = File.Create(P_str_文本名称与路径);  //用文件流的方式创建文本可以用其他线程读写文本
                fs_文件流.Close(); //记得要关闭，不然一直占用文本

            }

        }

        /// <summary>
        /// 删除文本
        /// </summary>
        /// <param name="M_str_文本路径上级目录">文本所在的文件夹的路径</param>
        /// <param name="M_str_文本名称">文本名称与后缀名</param>
        public void F删除文本(string M_str_文本路径上级目录, string M_str_文本名称)
        {
            string P_str_文本名称与路径 = M_str_文本路径上级目录 + "\\" + M_str_文本名称;
            if (File.Exists(P_str_文本名称与路径))
            {
                File.Delete(P_str_文本名称与路径);

            }

        }

        /// <summary>
        /// 重命名文本
        /// </summary>
        /// <param name="M_str_文本路径上级目录">文本所在的文件夹的路径</param>
        /// <param name="M_str_原来文本名称">原来文本名称</param>
        /// <param name="M_str_新命名文本名称">新命名文本名称</param>
        public void F重命名文本(string M_str_文本路径上级目录, string M_str_原来文本名称, string M_str_新命名文本名称)
        {
            string P_str_原来文本名称与路径 = M_str_文本路径上级目录 + "\\" + M_str_原来文本名称;
            string P_str_新命名文本名称与路径 = M_str_文本路径上级目录 + "\\" + M_str_新命名文本名称;
            if (File.Exists(P_str_原来文本名称与路径) && File.Exists(P_str_新命名文本名称与路径) == false)
            {
                File.Move(P_str_原来文本名称与路径, P_str_新命名文本名称与路径);

            }

        }


        /// <summary>
        /// 遍历替换文本
        /// </summary>
        public void F遍历替换()
        {
            string P_str_编号最大旧日志文本名称 = G_str_旧日志备份名称 + Convert.ToString(G_int_日志文本个数 - 1) + G_str_文本格式;
            this.F删除文本(G_str_日志文件所在文件夹, P_str_编号最大旧日志文本名称);
            string P_str_原来文本名称 = "";
            string P_str_新命名文本名称 = "";
            for (int P_int_当前编号 = G_int_日志文本个数 - 1; P_int_当前编号 > 1; P_int_当前编号--)
            {
                P_str_原来文本名称 = G_str_旧日志备份名称 + Convert.ToString(P_int_当前编号 - 1) + G_str_文本格式;
                P_str_新命名文本名称 = G_str_旧日志备份名称 + Convert.ToString(P_int_当前编号) + G_str_文本格式;
                this.F重命名文本(G_str_日志文件所在文件夹, P_str_原来文本名称, P_str_新命名文本名称);


            }

            this.F重命名文本(G_str_日志文件所在文件夹, G_str_当前运行日志文本名称, G_str_旧日志备份1文本名称);


            this.F创建文本(G_str_日志文件所在文件夹, G_str_当前运行日志文本名称);



        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="M_str_文本路径上级目录">文本所在的文件夹的路径</param>
        /// <param name="M_str_文本名称">文本名称与后缀名</param>
        /// <returns></returns>
        public string F获取文本容量大小(string M_str_文本路径上级目录, string M_str_文本名称)
        {
            string P_str_文本名称与路径 = M_str_文本路径上级目录 + "\\" + M_str_文本名称;
            string size = "0";
            FileInfo F文件信息实例化1 = new FileInfo(P_str_文本名称与路径);
            long P_int_文件长度 = F文件信息实例化1.Length;
            if (P_int_文件长度 < 1024)
            {
                size = string.Format("{0:N0}", P_int_文件长度) + "B";
            }
            else if (P_int_文件长度 > 1024)
            {
                if (P_int_文件长度 < 1048576)
                {
                    size = string.Format("{0:N1}", P_int_文件长度 / 1024) + "KB";
                }
                else
                {
                    size = string.Format("{0:N2}", P_int_文件长度 / 1048576) + "MB";
                }
            }

            return size;
        }


        /// <summary>
        /// 文件容量大于指定容量就为true
        /// </summary>
        /// <param name="M_str_文本路径上级目录">文本所在的文件夹的路径</param>
        /// <param name="M_str_文本名称">文本名称与后缀名</param>
        /// <param name="M_int_指定容量大小MB">单位MB，指定文件多少MB</param>
        /// <returns></returns>
        public bool F文件容量大于指定容量(string M_str_文本路径上级目录, string M_str_文本名称, int M_int_指定容量大小MB)
        {
            bool P_bl_比较结果 = false;
            string P_str_文本名称与路径 = M_str_文本路径上级目录 + "\\" + M_str_文本名称;
            if (File.Exists(P_str_文本名称与路径))
            {
                FileInfo F文件信息实例化1 = new FileInfo(P_str_文本名称与路径);
                long P_int_文件长度 = F文件信息实例化1.Length;

                if (Convert.ToInt32(P_int_文件长度 / 1048576) >= M_int_指定容量大小MB)
                {
                    P_bl_比较结果 = true;
                }
            }

            return P_bl_比较结果;
        }


        /// <summary>
        /// 写入文本日志
        /// </summary>
        /// <param name="M_str_文本路径上级目录">文本所在的文件夹的路径</param>
        /// <param name="M_str_文本名称">文本名称与后缀名</param>
        /// <param name="M_str_日志内容">输出日志内容</param>
        public void F文本写入日志(string M_str_文本路径上级目录, string M_str_文本名称, string M_str_日志内容)
        {

            if (Directory.Exists(M_str_文本路径上级目录) == false)  //文件夹不存在就创建文件夹
            {
                Directory.CreateDirectory(M_str_文本路径上级目录);

            }

            string P_str_文本名称与路径 = M_str_文本路径上级目录 + "\\" + M_str_文本名称;
            StreamWriter P_sw_写入文件流 = new StreamWriter(P_str_文本名称与路径, true);
            P_sw_写入文件流.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + M_str_日志内容);
            P_sw_写入文件流.Close();
            P_sw_写入文件流.Dispose();

        }


        public void F运行日志输出(string M_str_日志内容)
        {



            if (this.F文件容量大于指定容量(G_str_日志文件所在文件夹, G_str_当前运行日志文本名称, G_str_日志文本指定容量MB))
            {
                this.F遍历替换();

            }

            this.F文本写入日志(G_str_日志文件所在文件夹, G_str_当前运行日志文本名称, M_str_日志内容);

        }






    }


}
