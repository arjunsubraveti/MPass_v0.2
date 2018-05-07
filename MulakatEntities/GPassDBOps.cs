using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MulakatEntities;
using System.Management;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace MulakatDataOps
{
       
    public class GPassDBOps : IGpassDB
    {
       
        private OleDbConnection conn;
        private OleDbCommand cmd;
        
        public GPassDBOps()
        {
            conn = conn ?? GetConnection();
            cmd = cmd ?? GetOleDbCommand();
            conn.Open();

        }

        /// <summary>
        /// Inserts data into Acc_Trans present in GP.mdb 
        /// </summary>
        /// <param name="gpassEntity"></param>
        /// <returns></returns>
        public int InsertGPassDB(GpassEntity gpassEntity)
        {

            try
            {
                
       
                cmd.CommandText = "INSERT into Acc_Trans (" +
                    "SystemID, Visit_date,Visit_time, MoneyDep, Pur_Visit, ArtSubmit, " +
                    "Visit_Name, Relation, Visit_ID, Visit_IDDet, Visit_Phone, Visit_Addr, " +
                    "Visit_Name1, Relation1, Visit_ID1, Visit_IDDet1, Visit_Phone1, Visit_Addr1, " +
                    "Visit_Name2, Relation2, Visit_ID2, Visit_IDDet2, Visit_Phone2, Visit_Addr2, " +
                    "Visit_Name3, Relation3, Visit_ID3, Visit_IDDet3, Visit_Phone3, Visit_Addr3, " +
                    "P_Name, P_FName, P_Type, DOA, CaseDet, PS, Dist, " +
                    "P_Name1, P_FName1, P_Type1, DOA1, CaseDet1, PS1, Dist1, " +
                    "P_Name2, P_FName2, P_Type2, DOA2, CaseDet2, PS2, Dist2, " +
                    "P_Name3, P_FName3, P_Type3, DOA3, CaseDet3, PS3, Dist3, Vis_Image ) VALUES (" +
                    "'"  +      gpassEntity.SystemUId           + "'," +
                    " '" +      gpassEntity.OnlyDate            + "', " +
                    "'"  +      gpassEntity.OnlyTime            + "', " +
                    "'"  +      gpassEntity.Money               + "', " +
                    "'"  +      gpassEntity.Purpose             + "', " +
                    "'"  +      gpassEntity.Articles            + "', " +
                    "'"  +      gpassEntity.VisitorName1      + "', " +
                    "'"  +      gpassEntity.VisitorName2      + "', " +
                    "'"  +      gpassEntity.VisitorName3      + "', " +
                    "'"  +      gpassEntity.VisitorName4      + "', " +
                    "'"  +      gpassEntity.Relation1         + "', " +
                    "'"  +      gpassEntity.Relation2         + "', " +
                    "'"  +      gpassEntity.Relation3         + "', " +
                    "'"  +      gpassEntity.Relation4         + "', " +
                    "'"  +      gpassEntity.IdProof1          + "', " +
                    "'"  +      gpassEntity.IdProof2          + "', " +
                    "'"  +      gpassEntity.IdProof3          + "', " +
                    "'"  +      gpassEntity.IdProof4          + "', " +
                    "'"  +      gpassEntity.Aadhaar1          + "', " +
                    "'"  +      gpassEntity.Aadhaar2          + "', " +
                    "'"  +      gpassEntity.Aadhaar3          + "', " +
                    "'"  +      gpassEntity.Aadhaar4          + "', " +
                    "'"  +      gpassEntity.Mobile1           + "', " +
                    "'"  +      gpassEntity.Mobile2           + "', " +
                    "'"  +      gpassEntity.Mobile3           + "', " +
                    "'"  +      gpassEntity.Mobile4           + "', " +
                    "'"  +      gpassEntity.Address1          + "', " +
                    "'"  +      gpassEntity.Address2          + "', " +
                    "'"  +      gpassEntity.Address3          + "', " +
                    "'"  +      gpassEntity.Address4          + "', " +
                    "'"  +      gpassEntity.PrisonerName1     + "', " +
                    "'"  +      gpassEntity.PrisonerName2     + "', " +
                    "'"  +      gpassEntity.PrisonerName3     + "', " +
                    "'"  +      gpassEntity.PrisonerName4     + "', " +
                    "'"  +      gpassEntity.FatherName1       + "', " +
                    "'"  +      gpassEntity.FatherName2       + "', " +
                    "'"  +      gpassEntity.FatherName3       + "', " +
                    "'"  +      gpassEntity.FatherName4       + "', " +
                    "'"  +      gpassEntity.UTxCT1            + "', " +
                    "'"  +      gpassEntity.UTxCT2            + "', " +
                    "'"  +      gpassEntity.UTxCT3            + "', " +
                    "'"  +      gpassEntity.UTxCT4            + "', " +
                    "'"  +      gpassEntity.DOA1              + "', " +
                    "'"  +      gpassEntity.DOA2              + "', " +
                    "'"  +      gpassEntity.DOA3              + "', " +
                    "'"  +      gpassEntity.DOA4              + "', " +
                    "'"  +      gpassEntity.Case1             + "', " +
                    "'"  +      gpassEntity.Case2             + "', " +
                    "'"  +      gpassEntity.Case3             + "', " +
                    "'"  +      gpassEntity.Case4             + "', " +
                    "'"  +      gpassEntity.PS1               + "', " +
                    "'"  +      gpassEntity.PS2               + "', " +
                    "'"  +      gpassEntity.PS3               + "', " +
                    "'"  +      gpassEntity.PS4               + "', " +
                    "'"  +      gpassEntity.District1         + "', " +
                    "'"  +      gpassEntity.District2         + "', " +
                    "'"  +      gpassEntity.District3         + "', " +
                    "'"  +      gpassEntity.District4         + "', " +
                    "'"  +      gpassEntity.PassImageData     + "') " ;
                cmd.Connection = conn;
                return cmd.ExecuteNonQuery();

            }
            catch (ManagementException e)
            {
                return -1;
            }

        }


        /// <summary>
        /// Returns a new OleDbConnection
        /// </summary>
        /// <returns></returns>
        private static OleDbConnection GetConnection()
        {
             //var str = ConfigurationManager.ConnectionStrings["test"].ToString();
            return new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\GP.mdb;User ID=admin;Jet OLEDB:Database Password=rjw3ak");
        }


        /// <summary>
        /// Returns a new OleDbCommand
        /// </summary>
        /// <returns></returns>
        private static OleDbCommand GetOleDbCommand()
        {
            return new OleDbCommand();
        }


        /// <summary>
        /// Retrieves latest Serial Number from DB
        /// </summary>
        /// <returns></returns>
        public long RetrieveSerialNumber()
        { 
            try
            {
                cmd.CommandText = "Select MAX(SNo) from Acc_Trans as serial_value";
                cmd.Connection = conn;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        reader.Read();
                        return (reader.IsDBNull(0) ? 1 : reader.GetInt32(0)+1);
                    }
                    else
                    {
                        return 1;
                    }
                }

            }

            catch(ManagementException e)
            {
                return -1;
            }   

        }


      

        /// <summary>
        /// Complex methof of generating unique systemID
        /// </summary>
        private void GenerateUniqueSysID()
        {

            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_Processor instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Architecture: {0}", queryObj["Architecture"]);
                    Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                    Console.WriteLine("Family: {0}", queryObj["Family"]);
                    Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }


        /// <summary>
        /// Retrieves MAC Address which can be used to identify a system uniquely. Not reliable, but pretty
        /// much satisfies the purpose fror this application.
        /// </summary>
        /// <returns></returns>
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                // Only consider Ethernet network interfaces
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

    }
}
