using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBhelper类封装起来
{
    public static class DBhelper
    {

        //连接到本地数据库里面首先连好服务器名称叫DESKTOP-8U89UEQ，然后数据库名字叫db_news，后面是windows连接
        static string constr = "server =DESKTOP-8U89UEQ;database = 犹豫模糊语言术语集;Trusted_Connection=SSPI";
        static SqlConnection conn;



        //第 1 个方法是初始化链接对象
        public static void initConn()
        {
            conn = new SqlConnection(constr);
            conn.Open();
        }

        //第 2 个方法是实现查询,括号里面的string sqlstr传入的是   SQL语句最后查询完之后返回数据ds
        public static DataSet GetDataSet(string sqlstr)
        {
            initConn();
            //适配器定义的是实现数据的操作,第二个参数是连接对象
            SqlDataAdapter dat = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            dat.Fill(ds);
            conn.Close();
            return ds;
        }

        //第 3 个方法是实现增删改查
        public static bool InsertUpdateDal(string sqlstr)
        {
            initConn();
            SqlCommand comm = new SqlCommand(sqlstr, conn);
            int n = comm.ExecuteNonQuery();
            conn.Close();
            if (n == 1)
            {
                return true;

            }

            else
            {
                return false;
            }
            

        }

        //第4个方法求个数
        public static int Count(string sqlstr)
        {
            //https://blog.csdn.net/wk122348545/article/details/2972783
            initConn();
            SqlCommand countCmd = conn.CreateCommand();
            countCmd.CommandText = sqlstr;
            int num = (int)countCmd.ExecuteScalar();
            countCmd.Dispose();
            conn.Close();
            return num;
        }


    }
}
