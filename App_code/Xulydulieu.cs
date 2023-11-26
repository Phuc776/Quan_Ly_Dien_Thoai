using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Quan_Ly_Dien_Thoai.App_code
{
    internal class Xulydulieu
    {
        SqlConnection con;
        SqlDataAdapter adapter;
        public Xulydulieu()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=localhost;Initial Catalog=QuanLyDienThoai;Integrated Security=True";
        }
        private void MoKetNoi()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        private void DongKetNoi()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        public DataTable getTable(String SQL)
        {
            DataTable tb = null;
            try
            {
                this.MoKetNoi();
                SqlDataAdapter adp = new SqlDataAdapter(SQL, con);
                tb = new DataTable();
                adp.Fill(tb);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.DongKetNoi();
            }
            return tb;
        }
        public DataTable getTable(String nameprocedurce, SqlParameter[] pr)
        {
            DataTable tb = null;
            try
            {
                this.MoKetNoi();
                tb = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nameprocedurce;
                if (pr != null)
                    cmd.Parameters.AddRange(pr);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(tb);
            }
            catch (Exception ex)
            { }
            finally
            {
                this.DongKetNoi();
            }
            return tb;
        }
        public void getDataSet(ref DataSet ds, String SQL)
        {
            ds.Tables.Add(this.getTable(SQL));
        }
        public void getDataSet(ref DataSet ds, String nameprocedurce, SqlParameter[] pr)
        {
            ds.Tables.Add(this.getTable(nameprocedurce, pr));
        }
        /// <summary>
        /// Đối tượng command thực thi lệnh SQL 
        /// </summary>
        /// <param name="SQL">SQL:insert, update, Delete</param>
        /// <returns>K(<>0, =0) trong đó <>0 thành công và =0 lỗi khi thực thi </returns>
        public int Execute(string SQL)
        {
            int k = 0;
            try
            {
                this.MoKetNoi();
                SqlCommand cmd = new SqlCommand(SQL, this.con);
                k = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.DongKetNoi();
            }
            return k;
        }

        public void loadXML(string[] TableNames)
        {
            this.MoKetNoi();
            foreach (string TableName in TableNames)
            {
                string sql = "Select * from " + TableName;
                SqlDataAdapter ad = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable(TableName);
                ad.Fill(dt);
                dt.WriteXml(Application.StartupPath + "\\" + TableName + ".xml", XmlWriteMode.WriteSchema);

                //SqlCommand cmd = new SqlCommand($"SELECT * FROM {TableName}", con);
                //SqlDataReader reader = cmd.ExecuteReader();

                //if (reader.HasRows)
                //{
                //    XmlWriterSettings xmlSettings = new XmlWriterSettings
                //    {
                //        Indent = true

                //    };
                //    XmlWriter xmlWriter = XmlWriter.Create($"{TableName}.xml", xmlSettings);

                //    xmlWriter.WriteStartDocument(true);
                //    xmlWriter.WriteStartElement(TableName + "S");

                //    while (reader.Read())
                //    {
                //        xmlWriter.WriteStartElement(TableName);

                //        for (int i = 0; i < reader.FieldCount; i++)
                //        {
                //            xmlWriter.WriteStartElement(reader.GetName(i));
                //            xmlWriter.WriteValue(reader[i].ToString());
                //            xmlWriter.WriteEndElement();
                //        }

                //        xmlWriter.WriteEndElement();
                //    }

                //    xmlWriter.WriteEndElement();
                //    xmlWriter.WriteEndDocument();
                //    xmlWriter.Close();
                //}
                //reader.Close();
                //cmd.Dispose();
            }
            this.DongKetNoi();
        }
        public DataTable getXMLDataSet(string filename)
        {
            DataTable dt = new DataTable();
            string FilePath = Application.StartupPath + "\\" + filename;
            if (File.Exists(FilePath))
            {

                DataSet ds = new DataSet();
                FileStream fsReadXML = new FileStream(FilePath, System.IO.FileMode.Open);
                ds.ReadXml(fsReadXML);
                DataView dv = new DataView(ds.Tables[0]);
                dt = dv.Table;
                fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File XML '" + filename + "' không tồn tại");
            }

            return dt;
        }

        public void loadTables(String[] tableNames) {
            foreach (String tableName in tableNames)
            {
                String path = @"" + tableName + ".xml";
                DataTable dataTable = getXMLDataSet(path);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string sql = "insert into " + tableName + " values(";
                    for (int j = 0; j < dataTable.Columns.Count - 1; j++)
                    {
                        sql += "N'" + dataTable.Rows[i][j].ToString().Trim() + "',";
                    }
                    sql += "N'" + dataTable.Rows[i][dataTable.Columns.Count - 1].ToString().Trim() + "'";
                    sql += ")";
                    Execute(sql);
                }
            }
        }


    }
}
