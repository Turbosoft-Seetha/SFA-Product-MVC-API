using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models.ApprovalHelper
{
    public class Journeyplanseq
    {
    }


    public class JourneyplanseqHeaderIn
    {
        public string Status_Value { get; set; }



    }

    public class PostJourneyplanseqData
    {
        public string UserId { get; set; }

        public string JSONString { get; set; }

        



    }
    public class PostJourneyplanseqDataS
    {
        public string jps_ID { get; set; }






    }

    public class PostJourneyplanseqStatus
    {
        public string Status { get; set; }

        public string ArStatus { get; set; }





    }


    public class JourneyplanseqHeaderOut
    {
        public string jps_ID { get; set; }

        public string jps_PrevSeq { get; set; }
        public string jps_CurrentSeq { get; set; }
        public string CreatedDate { get; set; }
        public string rot_Code { get; set; }
        public string Route { get; set; }
        public string cus_Name { get; set; }
        public string cus_Code { get; set; }
        public string rsn_Name { get; set; }
        public string Status { get; set; }
        public string UserID { get; set; }
        public string rotID { get; set; }
        public string Arcus_Name { get; set; }
        public string ArStatus { get; set; }

    }



    public class PostJourneyplanseqrejectData
    {
        public string UserId { get; set; }

        public string JSONString { get; set; }





    }
    public class PostJourneyplanseqrejectDatas
    {
        public string jps_ID { get; set; }






    }

    public class PostJourneyplanseqrejectStatus
    {
        public string Status { get; set; }

        public string ArStatus { get; set; }




    }

}