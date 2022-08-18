using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace RTOS通信上位机.数据库操作类文件
{
    

    class C数据库操作类
    {

        #region 全局变量
        public static OleDbConnection G_sql_数据库连接; //重点，数据库连接的对象
        //*************数据库对象，要连接数据库，
        public static string G_str_数据库路劲 = System.Windows.Forms.Application.StartupPath + @"\DB数据库\DB_TEST.accdb";
        //public static string G_str_数据库对象 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + G_str_数据库路劲 + "";  //Access2003的连接，mdb
        public static string G_str_数据库对象 = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + G_str_数据库路劲 + "";   //Access2007的连接，accdb

        #endregion

        #region 方法：建立数据库连接
        /// <summary>
        /// 方法：建立数据库连接
        /// </summary>
        /// <returns>连接的数据库</returns>
        // public static SqlConnection F数据库连接()
        public OleDbConnection F数据库连接()
        {
            G_sql_数据库连接 = new OleDbConnection(G_str_数据库对象);
            G_sql_数据库连接.Open();
            return G_sql_数据库连接;
        }

        #endregion

        #region 方法：关闭数据库连接，并销毁对象
        /// <summary>
        /// 方法：关闭数据库连接，并销毁对象
        /// </summary>
        public void F关闭数据库连接()
        {
            if (G_sql_数据库连接.State == ConnectionState.Open)
            {
                G_sql_数据库连接.Close();
                G_sql_数据库连接.Dispose();

            }

        }

        #endregion


        #region  方法：DateReader 读取数据库，查询
        /// <summary>
        /// 方法：DateReader 读取数据库
        /// </summary>
        /// <param name="M_str_SQL语句"> 要执行的SQL语句</param>
        /// <returns> OleDbDataReader 对象</returns>
        public OleDbDataReader F读取数据库(string M_str_SQL语句)
        {
            F数据库连接();    //打开数据库
            OleDbCommand P_cmd_数据库执行命令 = new OleDbCommand(M_str_SQL语句, G_sql_数据库连接);
            OleDbDataReader P_dr_读取数据 = P_cmd_数据库执行命令.ExecuteReader();


            return P_dr_读取数据;
        }

        #endregion

        #region  方法：执行数据库添加、修改、删除

        /// <summary>
        /// 方法：执行数据库添加、修改、删除
        /// </summary>
        /// <param name="M_str_SQL语句"></param>
        public void F数据库加_改_删(string M_str_SQL语句)
        {
            F数据库连接();    //打开数据库
            OleDbCommand P_cmd_数据库执行命令 = new OleDbCommand(M_str_SQL语句, G_sql_数据库连接);
            P_cmd_数据库执行命令.ExecuteNonQuery();
            P_cmd_数据库执行命令.Dispose();
            F关闭数据库连接();  //关闭数据库连接

        }

        #endregion

        #region 方法：通过DataSet数据集执行数据库添加、修改、删除

        /// <summary>
        /// 方法：通过DataSet数据集执行数据库添加、修改、删除
        /// </summary>
        /// <param name="M_str_SQL语句"> 要执行的SQL语句 </param>
        /// <param name="M_str_数据集表名"> 数据集表名 </param>
        /// <returns>数据集</returns>
        public DataSet F获取数据集表(string M_str_SQL语句, string M_str_数据集表名)
        {
            F数据库连接();
            OleDbDataAdapter P_da_数据适配器 = new OleDbDataAdapter(M_str_SQL语句, G_sql_数据库连接);
            DataSet P_ds_数据集 = new DataSet();
            P_da_数据适配器.Fill(P_ds_数据集, M_str_数据集表名);

            F关闭数据库连接();
            return P_ds_数据集;
        }

        #endregion



    }


}
