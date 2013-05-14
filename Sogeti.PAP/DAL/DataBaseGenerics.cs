using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sogeti.PAP.DAL
{
    public static class DataBaseGenerics
    {
        //private static string ConnectionString = "Data Source=IE-05-11-11-517;Initial Catalog=Sogeti.PAP;Integrated Security=True";
        private static string ConnectionString = "Data Source=Eclairette;Initial Catalog=Sogeti.PAP;Integrated Security=True";
        //private static string ConnectionString = "Server=tcp:bgz7gh668b.database.windows.net,1433;Database=sogeti.pap;User ID=abdul.abbasi@bgz7gh668b;Password=SogetiIreland16;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

        #region Select Methods
        public static DataSet GetData(string query, CommandType type)
        {
            return GetData(query, null, type, QueryType.Select_Statement);
        }

        public static DataSet GetData(string query, SqlParameter param, CommandType type)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(param);

            return GetData(query, paramList, type, QueryType.Select_Statement);
        }

        public static DataSet GetData(string query, List<SqlParameter> paramList, CommandType cmdType, QueryType queryType)
        {
            DataSet dsData = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    return dsData;
                }


                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = query;
                        cmd.CommandType = cmdType;
                        cmd.Parameters.Clear();

                        if (paramList != null)
                        {
                            foreach (SqlParameter param in paramList)
                            {
                                cmd.Parameters.Add(param);
                            }
                        }

                        try
                        {
                            using (SqlDataAdapter daAdapter = new SqlDataAdapter())
                            {
                                daAdapter.SelectCommand = cmd;
                                daAdapter.Fill(dsData);
                            }

                            return dsData;
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                    catch (SqlException ex)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }

        }
        #endregion

        #region InsertMethods
        public static int InsertData(string query, CommandType cmdType)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            return InsertData(query, paramList, cmdType);
        }

        public static int InsertData(string query, SqlParameter param, CommandType cmdType)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(param);

            return InsertData(query, paramList, CommandType.Text);
        }

        public static int InsertData(string query, List<SqlParameter> paramList, CommandType cmdType)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    return -1;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = cmdType;
                    cmd.CommandText = query;
                    cmd.Parameters.Clear();
                    if (paramList != null)
                    {
                        foreach (SqlParameter param in paramList)
                        {
                            //cmd.CommandText += " " + param.ParameterName + ",";
                            cmd.Parameters.Add(param);
                        }
                    }

                    //if (cmd.CommandText.EndsWith(","))
                    //    cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        #endregion
    }
}
