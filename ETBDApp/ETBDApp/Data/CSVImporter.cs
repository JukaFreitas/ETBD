namespace ETBDApp.Data
{
    public class CSVImporter
    {
        public void Import()
        {
            /*using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0046VVQ\SQLEXPRESS; Integrate Security = true"))
            {
                conn.Open();
                using (StreamReader reader = new StreamReader(@"C:\Users\Juka\Documents\ETBD\ETBDDb.csv)"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        
                        var values = line.Split(',');
                        

                        var sql = "INSERT INTO ETBD.dbo.Category VALUES('" + values[1] + ")";
                        
                        var cmd = new SqlCommand(); 
                        cmd.CommandText = sql;
                        cmd.CommandType = System.Data.CommandType.Text; 
                        cmd.Connection = conn;
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }*/
        }
    }
}

                   