using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MulakatEntities
{
    public class GpassEntity
    {
        public GpassEntity()
        {
            SystemUId =   (
                             from nic in NetworkInterface.GetAllNetworkInterfaces()
                             where nic.OperationalStatus == OperationalStatus.Up
                             select nic.GetPhysicalAddress().ToString()
                        ).FirstOrDefault();

            IsInsertFinished = false;
            IsIncorrectData = false;

        }

        public long SerialNumber { get; set; }
        public string SystemUId { get; set; }
        public string OnlyTime { get; set; }
        public string OnlyDate { get; set; }

        //Purpose of Visit
        public string Purpose { get; set; }

        //Articles carried by visitors for the Prisoner
        public string Articles { get; set; }

        //Money deposited by the Visitor for the Prisoner
        public string Money { get; set; }

        public string PrisonerName4 { get; set; }

        public string VisitorName4 { get; set; }
        public string FatherName4 { get; set; }
        public string District4 { get; set; }
        public string Relation4 { get; set; }
        public string IdProof4 { get; set; }
        public string Address4 { get; set; }

        //Under Trial or Convict
        public string UTxCT4 { get; set; }

        //Date of Arrival of Prisoner
        public string DOA4 { get; set; }

        //Case type of Prisoner - Criminal, Civil etc.
        public string Case4 { get; set; }

        //Police Station Name
        public string PS4 { get; set; }

        //Aadhaar or other Details
        public string Aadhaar4 {get;set;}

        //Mobile number of visitors
        public string Mobile4 { get; set; }


        public string PrisonerName1 { get; set; }
        public string VisitorName1 { get; set; }
        public string FatherName1 { get; set; }
        public string District1 { get; set; }
        public string Relation1 { get; set; }
        public string IdProof1 { get; set; }
        public string Address1 { get; set; }
        public string UTxCT1 { get; set; }
        public string DOA1 { get; set; }
        public string Case1 { get; set; }
        public string PS1 { get; set; }
        public string Aadhaar1 { get; set; }
        public string Mobile1 { get; set; }

        public string PrisonerName2 { get; set; }
        public string VisitorName2 { get; set; }
        public string FatherName2 { get; set; }
        public string District2 { get; set; }
        public string Relation2 { get; set; }
        public string IdProof2 { get; set; }
        public string Address2 { get; set; }
        public string UTxCT2 { get; set; }
        public string DOA2 { get; set; }
        public string Case2 { get; set; }
        public string PS2 { get; set; }
        public string Aadhaar2 { get; set; }
        public string Mobile2 { get; set; }


        public string PrisonerName3 { get; set; }
        public string VisitorName3 { get; set; }
        public string FatherName3 { get; set; }
        public string District3 { get; set; }
        public string Relation3 { get; set; }
        public string IdProof3 { get; set; }
        public string Address3 { get; set; }
        public string UTxCT3 { get; set; }
        public string DOA3 { get; set; }
        public string Case3 { get; set; }
        public string PS3 { get; set; }
        public string Aadhaar3 { get; set; }
        public string Mobile3 { get; set; }
        public byte[] PassImageData { get; set; }

        //Indicators for contextual purposes
        public bool IsInsertFinished { get; set; }
        public bool IsIncorrectData { get; set; }
        public int TotalEntries { get; set; }


        
    }
}
