using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_API.Models
{
    public class Inventory
    {
    }
    public class InvConfirmationIn
    {
        public string TransID { get; set; }
        public string CreatedDate { get; set; }
        public string RotID { get; set; }
        public string UsrID { get; set; }
        public string UdpID { get; set; }

        public string Json { get; set; }
        public string JsonBatch { get; set; }
    }
    public class JsonData
    {
        public string PrdID { get; set; }
        public string HUOM { get; set; }
        public string HQTY { get; set; }
        public string LUOM { get; set; }

        public string LQTY { get; set; }
        public string PhyHUOM { get; set; }

        public string PhyHQTY { get; set; }
        public string PhyLUOM { get; set; }

        public string PhyLQTY { get; set; }

        public string DescHUOM { get; set; }

        public string DescHQTY { get; set; }
        public string DescLUOM { get; set; }

        public string DescLQTY { get; set; }

        public string Isvanstockitms { get; set; }

        public string IsExcessOrShortage { get; set; }


    }

    public class JsonBatchData
    {
        public string PrdID { get; set; }
        public string BatchNum { get; set; }
        public string BatchQty { get; set; }
        public string AdjQty { get; set; }
        public string PhyStk { get; set; }


    }
    public class InvConfirmationOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        
    }

    public class LoadConfirmIn
    {
        public string lih_ID { get; set; }
        public string XMLData { get; set; }
        public string emp_ID { get; set; }
        public string Status { get; set; }
        public string rot_ID { get; set; }
        public string udp_ID { get; set; }
        public string Signature { get; set; }

        public string Remarks { get; set; }
    }
    public class ItemData
    {
        public string lidID { get; set; }
        public string Adj_H_UOM { get; set; }
        public string Adj_H_Qty { get; set; }
        public string Adj_L_UOM { get; set; }

        public string Adj_L_Qty { get; set; }
        public string LI_H_UOM { get; set; }

        public string LI_H_Qty { get; set; }
        public string LI_L_UOM { get; set; }

        public string LI_L_Qty { get; set; }

        public string Final_H_UOM { get; set; }

        public string Final_L_UOM { get; set; }
        public string Final_H_Qty { get; set; }

        public string Final_L_Qty { get; set; }

        public string Opn_HUOM { get; set; }

        public string Opn_HQty { get; set; }

        public string Opn_LUOM { get; set; }

        public string Opn_LQty { get; set; }

        public string HigherPrice { get; set; }

        public string LowerPrice { get; set; }
        public string prdID { get; set; }


    }

    public class LoadConfirmOut
    {
        public string Res { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; } = "";

    }

    public class GetLORHeader
    {
        public string Description { get; set; }
        public string DocumentDate { get; set; }
        public string Reference { get; set; }
        public string RecordStatus { get; set; }
        public string DocumentType { get; set; }
        public string PostingDate { get; set; }
        public List<GetLORItemHeader> TransferDetails { get; set; }
    }
    public class GetLORItemHeader
    {
        public string LineNumber { get; set; }
        public string ItemNumber { get; set; }
        public string Description { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int QuantityTransferred { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Comments { get; set; }
        public int QuantityRequested { get; set; }
        public int ConversionFactorQtyRequested { get; set; }

        public List<getTransferDetailOptionalFields> TransferDetailOptionalFields { get; set; }
        public List<getTransferDetailSerialNumbers> TransferDetailSerialNumbers { get; set; }
        public List<GetLORBatchSerial> TransferDetailLotNumbers { get; set; }
    }
    public class getTransferDetailOptionalFields
    {
    }
    public class getTransferDetailSerialNumbers
    {
    }
    public class GetLORBatchSerial
    {

        public string LotNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int TransactionQuantity { get; set; }
        public int LotQuantityInStockingUOM { get; set; }



    }
    public class ERPResponseResult
    {
        public string ResCode { get; set; }
        public string ResExceptionMessage { get; set; }
        public JArray Body { get; set; }

    }
    public class ICTransferData
    {
        public ERPResponseResult result { get; set; }

    }
    public class BodyData
    {
        public string SequenceNumber { get; set; }
        public string TransactionNumber { get; set; }
        // Add more fields as needed
    }
}